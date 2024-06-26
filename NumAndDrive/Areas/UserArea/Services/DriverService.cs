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
        private readonly IReservationRepository _reservationRepository;

        public DriverService(IFilterRepository filterRepository, IActivationDayRepository activationDayRepository, UserManager<User> userManager, IAddressRepository addressRepository, ITravelRepository travelRepository, ITravelFilterRepository travelFilterRepository, ITravelActivationDayRepository travelActivationDayRepository, ISchoolRepository schoolRepository, ICurrentUserService currentUserService, NumAndDriveContext context, AddressUtilities addressUtilities, IReservationRepository reservationRepository)
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
            _reservationRepository = reservationRepository;
        }

        public async Task<bool> CreateTravelAsync(CreateTravelViewModel datas)
        {
            var user = await _currentUserService.GetCurrentUserAsync();
            bool isSucess = false;

            if (IsAuthorizeToCreateANewTravel(user))
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
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
                        CreationDate = DateTime.Now
                    };

                    newTravel = AssociateAddressToTravel(newTravel, datas, personnalAddressSaved);

                    await _travelRepository.CreateTravelAsync(newTravel);
                    await _travelActivationDayRepository.CreateNewTravelActivationDayAsync(newTravel, datas.SelectedDays.ToList());
                    await _travelFilterRepository.CreateNewTravelFilterAsync(newTravel, datas.SelectedFilters.ToList());

                    await transaction.CommitAsync();
                    isSucess = true;
                    user.CountCreatedTravel++;
                    await _userManager.UpdateAsync(user);
                    return isSucess;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return isSucess;
                }
            }
            return isSucess;
        }

        public async Task FillDriverIndexViewModel(DriverIndexViewModel model)
        {
            var userId = _currentUserService.GetCurrentUserId();
            var activationDays = await _activationDayRepository.GetAllActivationDaysAsync();
            var travels = await _travelRepository.GetTravelsByPublisherId(userId);

            model.Days = activationDays;
            model.Travels = travels;

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

        public async Task FillCustomizeTravelViewModel(CustomizeTravelViewModel model, int travelId)
        {
            var activationDays = await _activationDayRepository.GetAllActivationDaysAsync();
            var travel = await _travelRepository.GetTravelByIdAsync(travelId);
            var reservations = await _reservationRepository.GetReservationByTravelIdAsync(travelId);

            var acceptedUsers = reservations.Where(r => r.Acceptation == true);
            var waitingUsers = reservations.Where(r => r.AwaitingResponse == true);


            model.Days = activationDays.ToList();
            model.Travel = travel;
            model.AcceptedUsers = acceptedUsers.ToList();
            model.WaitingUsers = waitingUsers.ToList();

        }

        private TimeOnly DefineArrivalTime(TimeOnly departureTime, int travelTimeInSeconds)
        {
            int travelTimeInMinutes = travelTimeInSeconds / 60;
            return departureTime.AddMinutes(travelTimeInMinutes);
        }

        private bool IsAuthorizeToCreateANewTravel(User user)
        {
            int maximumTravel = 2;
            return user.CountCreatedTravel <= maximumTravel;
        }

        private Travel AssociateAddressToTravel(Travel newTravel, CreateTravelViewModel datas, Address personnalAddress)
        {
            if (datas.IsAReturnTravel)
            {
                newTravel.DepartureAddressId = datas.SchoolAddressId;
                newTravel.ArrivalAddressId = personnalAddress.AddressId;
            }
            else
            {
                newTravel.DepartureAddressId = personnalAddress.AddressId;
                newTravel.ArrivalAddressId = datas.SchoolAddressId;
            }

            return newTravel;
        }

        public async Task AcceptReservationAsync(int travelId, string userId)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(travelId, userId);

            if (reservation != null)
            {
                reservation.ResponseDate = DateTime.Now;
                reservation.Acceptation = true;
                reservation.AwaitingResponse = false;

                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    await _reservationRepository.UpdateReservationAsync(reservation);
                    reservation.Travel.AvailablePlace -= 1;
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }

        }
    }
}
