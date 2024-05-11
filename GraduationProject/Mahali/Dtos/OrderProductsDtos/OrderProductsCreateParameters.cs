﻿using System.ComponentModel.DataAnnotations;

namespace Mahali.Dtos.OrderProductsDtos
{
    public class OrderProductsCreateParameters
    {

        [Required]
        public int OrderId { get;  set; }

        [Required]
        public Guid ProductId { get;  set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get;  set; }

        [Required(ErrorMessage = "Unit price is required.")]
        public decimal UnitPrice { get;  set; } = 0!;

        [Required(ErrorMessage = "Color is required.")]
        public Colors Color { get;  set; }

        [Required(ErrorMessage = "Size is required.")]
        public Sizes Size { get;  set; }
    }
}
