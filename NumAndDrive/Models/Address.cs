namespace NumAndDrive.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public double[] Coordinates { get; set; } = new double[2];
        public ICollection<Travel> DepartureTravel { get; set; } = [];
        public ICollection<Travel> ArrivalTravel { get; set; } = [];
        public ICollection<TravelStopPoint> TravelStopPoints { get; set; } = [];
        public ICollection<School> Schools { get; set; } = [];

        public override string ToString()
        {
            return Street + " " + PostalCode + " " + City; 
        }
    }
}
