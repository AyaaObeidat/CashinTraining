using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.ReportDtos
{
    public class ReportCreateParameters
    {
        [Required]
        public string ReportText { get;  set; } 
        public string ShopName {  get; set; }   
    }
}
