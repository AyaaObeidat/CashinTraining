using Mahali.Models;

namespace Mahali.Dtos.ProductDtos
{
    public class ProductUpdateParameters
    {
        public Guid Id { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }
        public int NewQuantity { get; set; }
        public decimal NewPrice { get; set; }
        public string NewImageUri { get; set; }
    }
}
