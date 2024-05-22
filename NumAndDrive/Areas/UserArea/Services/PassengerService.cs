using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.Passenger;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

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
            var travels = await _travelRepository.GetAllTravelsAsync();

            model.Days = activationDays.ToList();
            model.Travels = travels.ToList();
        }
    }
}
