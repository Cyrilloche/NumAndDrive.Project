using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Areas.UserArea.ViewModels.Driver;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;
using System.Net;
using System.Text.Json.Nodes;

namespace NumAndDrive.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class DriverController : Controller
    {
        private readonly IFilterRepository _filterRepository;
        private readonly IActivationDayRepository _activationDayRepository;
        private readonly UserManager<User> _userManager;
        private readonly IAddressRepository _addressRepository;
        private readonly ITravelRepository _travelRepository;
        private readonly ITravelFilterRepository _travelFilterRepository;
        private readonly ITravelActivationDayRepository _travelActivationDayRepository;
        private readonly ISchoolRepository _schoolRepository;

        public DriverController(IFilterRepository filterRepository, IActivationDayRepository activationDayRepository, UserManager<User> userManager, IAddressRepository addressRepository, ITravelRepository travelRepository, ITravelFilterRepository travelFilterRepository, ITravelActivationDayRepository travelActivationDayRepository, ISchoolRepository schoolRepository)
        {
            _filterRepository = filterRepository;
            _activationDayRepository = activationDayRepository;
            _userManager = userManager;
            _addressRepository = addressRepository;
            _travelRepository = travelRepository;
            _travelFilterRepository = travelFilterRepository;
            _travelActivationDayRepository = travelActivationDayRepository;
            _schoolRepository = schoolRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateGoTravel()
        {
            var filters = await _filterRepository.GetAllFiltersAsync();
            var activationDays = await _activationDayRepository.GetAllActivationDaysAsync();
            var schools = await _schoolRepository.GetAllSchoolsAsync();

            var datasToDisplay = new CreateTravelViewModel
            {
                SelectedFilters = filters.ToList(),
                SelectedDays = activationDays.ToList(),
                Schools = schools.ToList()
            };
            return View(datasToDisplay);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Address> GetAddressFromAPI(string addressResearch)
        {
            string url = @"https://api-adresse.data.gouv.fr/search/?q=";

            string[] wordsFromUserEntry = addressResearch.Split(' ');

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

                foreach(JsonNode node in features)
                {
                    address.City = node["properties"]["city"].ToString();
                    address.PostalCode = node["properties"]["postcode"].ToString();
                    address.Street = node["properties"]["name"].ToString();
                }

                return address;

            }
            catch (WebException ex)
            {
                throw new WebException("Error during the process.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTravel(CreateTravelViewModel datas)
        {
            if (!ModelState.IsValid)
                return View(datas);

            var user = await _userManager.GetUserAsync(HttpContext.User);
            Address departureAddress = await GetAddressFromAPI(datas.DepartureAddress);
            Address arrivalAddress = await GetAddressFromAPI(datas.ArrivalAddress);

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

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateReturnTravel()
        {
            var filters = await _filterRepository.GetAllFiltersAsync();
            var activationDays = await _activationDayRepository.GetAllActivationDaysAsync();

            var datasToDisplay = new CreateTravelViewModel
            {
                SelectedFilters = filters.ToList(),
                SelectedDays = activationDays.ToList()
            };
            return View(datasToDisplay);
        }
    }
}
