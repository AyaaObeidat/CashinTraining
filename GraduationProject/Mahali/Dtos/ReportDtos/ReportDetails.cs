using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ReportDtos
{
    public class ReportDetails
    {
        public Guid Id { get; set; }
        public string ReportText { get;  set; }
        public DateTime LastModifiedTime { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public Guid AdminId { get;  set; }
        public Guid ShopId { get;  set; }
    }
}
