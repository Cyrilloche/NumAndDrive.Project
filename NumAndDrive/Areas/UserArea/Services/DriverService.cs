using Microsoft.AspNetCore.Identity;
using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.Driver;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;
using NumAndDrive.Services.Interfaces;
using System.Net;
using System.Text.Json.Nodes;

namespace NumAndDrive.Areas.UserArea.Services
{
    public class DriverService : IDriverService
    {
        private readonly IFilterRepository _filterRepository;
        private readonly IActivationDayRepository _activationDayRepository;
        private readonly UserManager<User> _userManager;
        private readonly IAddressRepository _addressRepository;
        private readonly ITravelRepository _travelRepository;
        private readonly ITravelFilterRepository _travelFilterRepository;
        private readonly ITravelActivationDayRepository _travelActivationDayRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly NumAndDriveContext _context;

        public DriverService(IFilterRepository filterRepository, IActivationDayRepository activationDayRepository, UserManager<User> userManager, IAddressRepository addressRepository, ITravelRepository travelRepository, ITravelFilterRepository travelFilterRepository, ITravelActivationDayRepository travelActivationDayRepository, ISchoolRepository schoolRepository, ICurrentUserService currentUserService, NumAndDriveContext context)
        {
            _filterRepository = filterRepository;
            _activationDayRepository = activationDayRepository;
            _userManager = userManager;
            _addressRepository = addressRepository;
            _travelRepository = travelRepository;
            _travelFilterRepository = travelFilterRepository;
            _travelActivationDayRepository = travelActivationDayRepository;
            _schoolRepository = schoolRepository;
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<bool> CreateTravelAsync(CreateTravelViewModel datas)
        {
            bool isSucess = false;
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _currentUserService.GetCurrentUserAsync();
                Address departureAddress = await FormatAddressWithAPIAsync(datas.DepartureAddress);
                Address arrivalAddress = await FormatAddressWithAPIAsync(datas.ArrivalAddress);

                Address departureAddressSaved = await _addressRepository.CreateAddressAsync(departureAddress);
                Address arrivalAddressSaved = await _addressRepository.CreateAddressAsync(arrivalAddress);

                Travel newTravel = new Travel
                {
                    PublisherUserId = user.Id,
                    TimeDeparture = datas.DepartureTime,
                    AvailablePlace = datas.AvailablePlacesInCar,
                    CreationDate = DateTime.Now,
                    DepartureAddressId = departureAddressSaved.AddressId,
                    ArrivalAddressId = arrivalAddressSaved.AddressId
                };
                await _travelRepository.CreateTravelAsync(newTravel);
                await _travelActivationDayRepository.CreateNewTravelActivationDayAsync(newTravel, datas.SelectedDays.ToList());
                await _travelFilterRepository.CreateNewTravelFilterAsync(newTravel, datas.SelectedFilters.ToList());

                await transaction.CommitAsync();
                isSucess = true;
                return isSucess;
            }
            catch
            {
                await transaction.RollbackAsync();
                return isSucess;
            }
        }

        public async Task FillCreateTravelViewModelAsync(CreateTravelViewModel model)
        {
            var filters = await _filterRepository.GetAllFiltersAsync();
            var activationDays = await _activationDayRepository.GetAllActivationDaysAsync();
            var schools = await _schoolRepository.GetAllSchoolsAsync();

            model.SelectedDays = activationDays.ToList();
            model.SelectedFilters = filters.ToList();
            model.Schools = schools.ToList();
        }

        public async Task<Address> FormatAddressWithAPIAsync(string researchedAddress)
        {
            string url = @"https://api-adresse.data.gouv.fr/search/?q=";

            string[] wordsFromUserEntry = researchedAddress.Split(' ');

            foreach (var word in wordsFromUserEntry)
            {
                url += word + '+';
            }

            try
            {
                using var webclient = new WebClient();
                string jsonString = webclient.DownloadString(url);

                JsonObject jsonObject = JsonNode.Parse(jsonString).AsObject();
                JsonArray features = jsonObject["features"].AsArray();
                Address address = new Address();

                foreach (JsonNode node in features)
                {
                    address.City = node["properties"]["city"].ToString();
                    address.PostalCode = node["properties"]["postcode"].ToString();
                    address.Street = node["properties"]["name"].ToString();
                }

                return address;

            }
            catch (WebException)
            {
                throw new WebException("Error during the process.");
            }
        }
    }
}
