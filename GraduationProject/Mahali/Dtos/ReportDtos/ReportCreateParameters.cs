using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ReportDtos
{
    public class ReportCreateParameters
    {
        [Required]
        public string ReportText { get; private set; } = null!;
        public Guid AdminId { get; private set; }
        public Guid ShopId { get; private set; }
    }
}
