namespace Mahali.Dtos.ReportDtos
{
    public class ReportListItems
    {
        public Guid ShopId { get; set; }
        public string ReportText { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
