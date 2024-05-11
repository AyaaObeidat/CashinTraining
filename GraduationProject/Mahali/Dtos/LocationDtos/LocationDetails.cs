using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.LocationDtos
{
    public class LocationDetails
    {
        public Guid Id { get; set; }
        public string AddressText { get;  set; } 
        public string AddressDirection { get;  set; } 
        public Guid ShopId { get;  set; }

    }
}
