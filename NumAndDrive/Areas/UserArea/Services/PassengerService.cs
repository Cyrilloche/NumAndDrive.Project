﻿using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.Passenger;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;
using System.Globalization;
using System.Text;

namespace NumAndDrive.Areas.UserArea.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IActivationDayRepository _activationDaysRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly ITravelRepository _travelRepository;

        public PassengerService(IActivationDayRepository activationDaysRepository, ISchoolRepository schoolRepository, ITravelRepository travelRepository)
        {
            _activationDaysRepository = activationDaysRepository;
            _schoolRepository = schoolRepository;
            _travelRepository = travelRepository;
        }

        public async Task DisplayPassengerHomePage(PassengerIndexViewModel model)
        {
            var activationDays = await _activationDaysRepository.GetAllActivationDaysAsync();
            var travels = await _travelRepository.GetTwoMostRecentTravel();
            var schools = await _schoolRepository.GetAllSchoolsAsync();

            model.Days = activationDays.ToList();
            model.Travels = travels.ToList();
            model.Schools = schools.ToList();
        }
        public async Task<ResearchViewModel> DisplayResultOfResearch(PassengerIndexViewModel datas)
        {
            var travels = await ResearchAvailableTravels(datas.ResearchedCity, datas.SchoolAdressId);
            var days = await _activationDaysRepository.GetAllActivationDaysAsync();

            var model = new ResearchViewModel();

            if(travels.Any())
            {
                model.Travels = travels.ToList();
                model.Days = days.ToList();
            }
            else
            {
                model.NotFound = true;
            }

            return model;

        }

        public async Task<IEnumerable<Travel>> ResearchAvailableTravels(string userEntry, int userSchoolId)
        {
            var travels = await _travelRepository.GetAllTravelsAsync();
            string searchedCityNormalized = NormalizeStringToCompare(userEntry);

            var availableTravel = travels
                .Where(t => NormalizeStringToCompare(t.PersonnalAdress.City).Contains(searchedCityNormalized) && t.SchoolAddressId == userSchoolId);

            return availableTravel;
        }

        public static string NormalizeStringToCompare(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text.ToUpper();
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public async Task FillTravelDetailsPartialView(TravelDetailsPartialViewModel model, int travelId)
        {
            model.Days = await _activationDaysRepository.GetAllActivationDaysAsync();
            model.Travel = await _travelRepository.GetTravelByIdAsync(travelId);
        }
    }
}