using BookBorrowingLibrary.Services;
using BookBorrowingLibraryDtos.AdminDtos;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingBookDtos;
using BookBorrowingLibraryDtos.BorrowingOrReturnBookDtos;
using BookBorrowingLibraryDtos.CustomerDtos;
using BookBorrowingLibraryDtos.DamagedBooksDtos;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> ModifyFullNameAsync(AdminUpdateParameters parameters)
        {
            await _adminService.ModifyFullNameAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPassword")]
        [Authorize]
        public async Task<IActionResult> ModifyPasswordAsync(AdminUpdateParameters parameters)
        {
            await _adminService.ModifyPasswordAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllBooks")]
        [Authorize]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            return Ok(await _bookService.GetAllBooksAsync());
        }

        [HttpPut]
        [Route("GetBookById")]
        [Authorize]
        public async Task<IActionResult> GetBookByIdAsync(BookGetByParameter parameter)
        {
            return Ok(await _bookService.GetByIdAsync(parameter));
        }

        [HttpPatch]
        [Route("ModifyTitle")]
        [Authorize]
        public async Task<IActionResult> ModifyTitleAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyTitleAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyAuthor")]
        [Authorize]
        public async Task<IActionResult> ModifyAuthorAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyAuthorAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPublisher")]
        [Authorize]
        public async Task<IActionResult> ModifyPublisherAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyPublisherAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPublisherYear")]
        [Authorize]
        public async Task<IActionResult> ModifyPublisherYearAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyPublisherYearAsync(parameters);
            return Ok();
        }


        [HttpPatch]
        [Route("ModifyNumberOfAvailableCopies")]
        [Authorize]
        public async Task<IActionResult> ModifyNumberOfAvailableCopiesAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyNumberOfAvailableCopiesAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyTotalNumberOfCopies")]
        [Authorize]
        public async Task<IActionResult> ModifyTotalNumberOfCopiesAsync(BookUpdateParameter parameters)
        {
            await _bookService.ModifyTotalNumberOfCopiesAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("BuyNewCopies")]
        [Authorize]
        public async Task<IActionResult> BuyNewCopiesAsync(BookUpdateParameter parameters)
        {
            await _adminService.BuyNewCopiesAsync(parameters);
            return Ok();
        }

        [HttpPost]
        [Route("AddNewBook")]
        [Authorize]
        public async Task<IActionResult> AddNewBookAsync(BookCreateParameters parameters)
        {
            await _bookService.AddNewBookAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllPendingCustomer")]
        [Authorize]
        public async Task<IActionResult> GetAllPendingCustomerAsync()
        {
            return Ok(await _customerService.GetAllPendingCustomerAsync());
        }

        [HttpPost]
        [Route("AcceptNewCustomer")]
        [Authorize]
        public async Task<IActionResult> AcceptNewCustomerAsync(CustomerGetByParameter parameters)
        {
            await _adminService.AcceptNewCustomerAsync(parameters);
            return Ok();
        }

        [HttpPost]
        [Route("RejectCustomer")]
        [Authorize]
        public async Task<IActionResult> RejectCustomerAsync(CustomerGetByParameter parameters)
        {
            await _adminService.RejectCustomerAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllAcceptedCustomer")]
        [Authorize]
        public async Task<IActionResult> GetAllAcceptedCustomerAsync()
        {
            return Ok(await _customerService.GetAllAcceptedCustomerAsync());
        }

        [HttpGet]
        [Route("GetAllBlockedCustomer")]
        [Authorize]
        public async Task<IActionResult> GetAllBlockedCustomerAsync()
        {
            return Ok(await _customerService.GetAllBlockedCustomerAsync());
        }


        [HttpPost]
        [Route("UnBlockCustomer")]
        [Authorize]
        public async Task<IActionResult> UnBlockCustomerAsync(CustomerGetByParameter parameters)
        {
            await _adminService.UnBlockCustomerAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllBorrowBooksPendingRequests")]
        [Authorize]
        public async Task<IActionResult> GetAllBorrowBooksPendingRequestsAsync()
        {
            return Ok(await _bookService.GetAllBorrowBooksPendingRequestsAsync());
        }

        [HttpPost]
        [Route("AcceptBorrowingBookRequest")]
        [Authorize]
        public async Task<IActionResult> AcceptBorrowingBookRequestAsync(BorrowingBookGetByParameter parameters)
        {
            await _adminService.AcceptBorrowingBookRequestAsync(parameters);
            return Ok();
        }

        [HttpPost]
        [Route("RejectBorrowingBookRequest")]
        [Authorize]
        public async Task<IActionResult> RejectBorrowingBookRequestAsync(BorrowingBookGetByParameter parameters)
        {
            await _adminService.RejectBorrowingBookRequestAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllBorrowBooksAcceptingRequests")]
        [Authorize]
        public async Task<IActionResult> GetAllBorrowBooksAcceptingRequestsAsync()
        {
            return Ok(await _bookService.GetAllBorrowBooksAcceptingRequestsAsync());
        }

        [HttpGet]
        [Route("GetAllReturnBooksTransactions")]
        [Authorize]
        public async Task<IActionResult> GetAllReturnBooksTransactionsAsync()
        {
            return Ok(await _bookService.GetAllReturnBooksTransactionsAsync());
        }

        [HttpPost]
        [Route("ReturnBookStatus")]
        [Authorize]
        public async Task<IActionResult> ReturnBookStatusAsync(ReturnBookGetByParameters parameters)
        {
            await _adminService.ReturnBookStatusAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllDamagedBooks")]
        [Authorize]
        public async Task<IActionResult> GetAllDamagedBooksAsync()
        {
            return Ok(await _bookService.GetAllDamagedBooksAsync());
        }

        [HttpPost]
        [Route("RepairOfDamagedCopy")]
        [Authorize]
        public async Task<IActionResult> RepairOfDamagedCopyAsync(DamagedBookGetByParameter parameters)
        {
            await _bookService.RepairOfDamagedCopyAsync(parameters);
            return Ok();
        }
    }
}