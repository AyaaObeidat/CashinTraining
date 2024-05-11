using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.LocationDtos
{
    public class LocationCreateParameters
    {

        [Required(ErrorMessage = "Address text is required.")]
        public string AddressText { get;  set; }

        [Required(ErrorMessage = "Address direction is required.")]
        public string AddressDirection { get;  set; } 
    }
}
