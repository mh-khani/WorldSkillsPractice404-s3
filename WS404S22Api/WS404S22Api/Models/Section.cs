namespace WS404S22Api.Models
{
    public class Section
    {
        public int SectionId { get; set; }

        public string SectionName { get; set; }
        public int Price { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }

    }
}
