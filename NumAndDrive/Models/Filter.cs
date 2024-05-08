namespace NumAndDrive.Models
{
    public class Filter
    {
        public int FilterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set; } = false;
        public ICollection<TravelFilter> TravelFilters { get; set; } = [];
    }
}
