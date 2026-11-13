namespace WS404S22Api.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PlaceId { get; set; }

        public int VisitorCount { get; set; }
        public int FreeCount { get; set; }

        public DateTime VisitAt { get; set; }
        public DateTime ReleaseAt { get; set; }

        public int TotalPrice { get; set; }
        public string Barcode { get; set; } = "";

        public List<TicketSection> TicketSections { get; set; } = new List<TicketSection>();

    }
}
