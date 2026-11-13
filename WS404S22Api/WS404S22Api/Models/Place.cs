namespace WS404S22Api.Models
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public int BasePrice { get; set; }

        public string Code { get; set; } = "";
        public int Capacity { get; set; }
        public int VisitorMinutes { get; set; }

        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
