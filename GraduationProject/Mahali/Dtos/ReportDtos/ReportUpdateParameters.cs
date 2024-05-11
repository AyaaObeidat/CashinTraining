using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ReportDtos
{
    public class ReportUpdateParameters
    {
        public Guid Id { get; set; }
        public string ReportText { get;  set; } 
    }
}
