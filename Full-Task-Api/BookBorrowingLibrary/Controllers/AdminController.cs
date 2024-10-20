using BookBorrowingLibrary.Services;
using BookBorrowingLibraryDtos.AdminDtos;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingBookDtos;
using BookBorrowingLibraryDtos.BorrowingOrReturnBookDtos;
using BookBorrowingLibraryDtos.CustomerDtos;
using BookBorrowingLibraryDtos.DamagedBooksDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowingLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;
        private readonly CustomerService _customerService;
        private readonly BookService _bookService;

        public AdminController(AdminService adminService, BookService bookService, CustomerService customerService)
        {
            _adminService = adminService;
            _bookService = bookService;
            _customerService = customerService;
        }

        [HttpPatch]
        [Route("ModifyFullName")]
        public async Task<IActionResult> ModifyFullNameAsync(AdminUpdateParameters parameters)
        {
            await _adminService.ModifyFullNameAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPassword")]
        public async Task<IActionResult> ModifyPasswordAsync(AdminUpdateParameters parameters)
        {
            await _adminService.ModifyPasswordAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            return Ok(await _bookService.GetAllBooksAsync());
        }

        [HttpPut]
        [Route("GetBookById")]
        public async Task<IActionResult> GetBookByIdAsync(BookGetByParameter parameter)
        {
            return Ok(await _bookService.GetByIdAsync(parameter));
        }

        [HttpPatch]
        [Route("ModifyTitle")]
        public async Task<IActionResult> ModifyTitleAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyTitleAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyAuthor")]
        public async Task<IActionResult> ModifyAuthorAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyAuthorAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPublisher")]
        public async Task<IActionResult> ModifyPublisherAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyPublisherAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPublisherYear")]
        public async Task<IActionResult> ModifyPublisherYearAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyPublisherYearAsync(parameters);
            return Ok();
        }


        [HttpPatch]
        [Route("ModifyNumberOfAvailableCopies")]
        public async Task<IActionResult> ModifyNumberOfAvailableCopiesAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyNumberOfAvailableCopiesAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyTotalNumberOfCopies")]
        public async Task<IActionResult> ModifyTotalNumberOfCopiesAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyTotalNumberOfCopiesAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("BuyNewCopies")]
        public async Task<IActionResult> BuyNewCopiesAsync(BookUpdateParameter parameters)
        {
            await _adminService.BuyNewCopiesAsync(parameters);
            return Ok();
        }

        [HttpPost]
        [Route("AddNewBook")]
        public async Task<IActionResult> AddNewBookAsync(BookCreateParameters parameters)
        {
            await _bookService.AddNewBookAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllPendingCustomer")]
        public async Task<IActionResult> GetAllPendingCustomerAsync()
        {
            return Ok(await _customerService.GetAllPendingCustomerAsync());
        }

        [HttpPost]
        [Route("AcceptNewCustomer")]
        public async Task<IActionResult> AcceptNewCustomerAsync(CustomerGetByParameter parameters)
        {
            await _adminService.AcceptNewCustomerAsync(parameters);
            return Ok();
        }

        [HttpPost]
        [Route("RejectCustomer")]
        public async Task<IActionResult> RejectCustomerAsync(CustomerGetByParameter parameters)
        {
            await _adminService.RejectCustomerAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllAcceptedCustomer")]
        public async Task<IActionResult> GetAllAcceptedCustomerAsync()
        {
            return Ok(await _customerService.GetAllAcceptedCustomerAsync());
        }

        [HttpGet]
        [Route("GetAllBlockedCustomer")]
        public async Task<IActionResult> GetAllBlockedCustomerAsync()
        {
            return Ok(await _customerService.GetAllBlockedCustomerAsync());
        }


        [HttpPost]
        [Route("UnBlockCustomer")]
        public async Task<IActionResult> UnBlockCustomerAsync(CustomerGetByParameter parameters)
        {
            await _adminService.UnBlockCustomerAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllBorrowBooksPendingRequests")]
        public async Task<IActionResult> GetAllBorrowBooksPendingRequestsAsync()
        {
            return Ok(await _bookService.GetAllBorrowBooksPendingRequestsAsync());
        }

        [HttpPost]
        [Route("AcceptBorrowingBookRequest")]
        public async Task<IActionResult> AcceptBorrowingBookRequestAsync(BorrowingBookGetByParameter parameters)
        {
            await _adminService.AcceptBorrowingBookRequestAsync(parameters);
            return Ok();
        }

        [HttpPost]
        [Route("RejectBorrowingBookRequest")]
        public async Task<IActionResult> RejectBorrowingBookRequestAsync(BorrowingBookGetByParameter parameters)
        {
            await _adminService.RejectBorrowingBookRequestAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllBorrowBooksAcceptingRequests")]
        public async Task<IActionResult> GetAllBorrowBooksAcceptingRequestsAsync()
        {
            return Ok(await _bookService.GetAllBorrowBooksAcceptingRequestsAsync());
        }

        [HttpGet]
        [Route("GetAllReturnBooksTransactions")]
        public async Task<IActionResult> GetAllReturnBooksTransactionsAsync()
        {
            return Ok(await _bookService.GetAllReturnBooksTransactionsAsync());
        }

        [HttpPost]
        [Route("ReturnBookStatus")]
        public async Task<IActionResult> ReturnBookStatusAsync(ReturnBookGetByParameters parameters)
        {
            await _adminService.ReturnBookStatusAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllDamagedBooks")]
        public async Task<IActionResult> GetAllDamagedBooksAsync()
        {
            return Ok(await _bookService.GetAllDamagedBooksAsync());
        }

        [HttpPost]
        [Route("RepairOfDamagedCopy")]
        public async Task<IActionResult> RepairOfDamagedCopyAsync(DamagedBookGetByParameter parameters)
        {
            await _bookService.RepairOfDamagedCopyAsync(parameters);
            return Ok();
        }
    }
}