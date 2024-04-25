namespace NumAndDrive.Models
{
    public class Adress
    {
        public int AdressId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public ICollection<Travel> DepartureTravel { get; set; } = [];
        public ICollection<Travel> ArrivalTravel { get; set; } = [];
        public ICollection<TravelStopPoint> TravelStopPoints { get; set; } = [];
        public int CurrentSchoolId { get; set; }
        public School CurrentSchool { get; set; }
    }
}
