﻿using Microsoft.AspNetCore.Identity;
using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.Driver;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;
using NumAndDrive.Services.Interfaces;
using NumAndDrive.Utilities;
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
        private readonly AddressUtilities _addressUtilities;

        public DriverService(IFilterRepository filterRepository, IActivationDayRepository activationDayRepository, UserManager<User> userManager, IAddressRepository addressRepository, ITravelRepository travelRepository, ITravelFilterRepository travelFilterRepository, ITravelActivationDayRepository travelActivationDayRepository, ISchoolRepository schoolRepository, ICurrentUserService currentUserService, NumAndDriveContext context, AddressUtilities addressUtilities)
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
            _addressUtilities = addressUtilities;
        }

        public async Task<bool> CreateTravelAsync(CreateTravelViewModel datas)
        {
            bool isSucess = false;
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _currentUserService.GetCurrentUserAsync();
                Address personnalAddress = await _addressUtilities.FormatAddressWithAPIAsync(datas.PersonnalAddress);

                Address personnalAddressSaved = await _addressRepository.CreateAddressAsync(personnalAddress);

                Address schoolAddress = await _addressRepository.GetAddressByIdAsync(datas.SchoolAddressId);

                int travelTime = await _addressUtilities.CalculateTravelTimeAsync(personnalAddress.Coordinates, schoolAddress.Coordinates);

                TimeOnly arrivalTime = DefineArrivalTime(datas.DepartureTime, travelTime);

                Travel newTravel = new Travel
                {
                    PublisherUserId = user.Id,
                    DepartureTime = datas.DepartureTime,
                    ArrivalTime = arrivalTime,
                    AvailablePlace = datas.AvailablePlacesInCar,
                    CreationDate = DateTime.Now,
                    DepartureAddressId = personnalAddressSaved.AddressId,
                    ArrivalAddressId = datas.SchoolAddressId
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

        private TimeOnly DefineArrivalTime(TimeOnly departureTime, int travelTimeInSeconds)
        {
            int travelTimeInMinutes = travelTimeInSeconds / 60;
            return departureTime.AddMinutes(travelTimeInMinutes);
        }
    }
}
