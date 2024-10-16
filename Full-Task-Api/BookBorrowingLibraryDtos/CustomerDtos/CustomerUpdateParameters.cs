using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingLibraryDtos.CustomerDtos
{
    public class CustomerUpdateParameters
    {
      public Guid Id { get; set; }
      public string NewFullName { get; set; }
      public string CurrentPassword { get; set; }
      public string NewPassword { get; set; }
      public long NewPhoneNumber { get; set; }
    }
}
