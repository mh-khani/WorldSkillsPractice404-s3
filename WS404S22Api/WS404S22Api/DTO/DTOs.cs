using WS404S22Api.Models;

namespace WS404S22Api.DTO
{
    public class LoginRequest
    {
        public string nationalCode { get; set; }
        public string password { get; set; }
    }
    public class DashboardRequest
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public TimeOnly Time { get; set; }
    }


    public class PlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Remaining { get; set; }
        public int Sold { get; set; }
        public int BasePrice { get; set; }
        public List<SectionDTO> Sections { get; set; } = new();
    }

    public class SectionDTO
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int Price { get; set; }
    }

    public class PlacesRequest
    {
        public int page { get; set; }
        public int size { get; set; }
        public int total { get; set; }
        public int pages { get; set; }
        public List<PlaceDTO> items { get; set; }
    }
    public class BuyRequest
    {
        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public int VisitorCount { get; set; }
        public List<int> SectionIds { get; set; } = new();
    }
    public class BuyRequestResponse
    {
        public int id { get; set; }
        public string barcode { get; set; }
        public int Price { get; set; }
        public string error { get; set; }

    }
    public class TicketSectionDetail
    {
        public string SectionName { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
    }
    public class PrintDTO
    {
        public string PlaceName { get; set; }
        public int NumberOfTickets { get; set; }
        public List<TicketSectionDetail> SectionDetailss { get; set; } = new();
        public int Total { get; set; }
        public string Barcode { get; set; }
    }

    
}
