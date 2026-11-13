namespace WS404S22Api.Models
{
    public class TicketSection
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
       
    }
}
