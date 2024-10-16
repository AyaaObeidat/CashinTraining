using BookBorrowingLibrary.Services;
using BookBorrowingLibraryDtos.BorrowingBook;
using BookBorrowingLibraryDtos.BorrowingOrReturnBookDtos;
using BookBorrowingLibraryDtos.CustomerDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowingLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly BookService _bookService;

        public CustomerController(CustomerService customerService, BookService bookService)
        {
            _customerService = customerService;
            _bookService = bookService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterParameters parameters)
        {
            await _customerService.RegisterAsync(parameters);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginParameters parameters)
        {
            return Ok(await _customerService.LoginAsync(parameters));
        }

        [HttpPatch]
        [Route("ModifyFullName")]
        public async Task<IActionResult> ModifyFullNameAsync(CustomerUpdateParameters parameters)
        {
            await _customerService.ModifyFullNameAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPassword")]
        public async Task<IActionResult> ModifyPasswordAsync(CustomerUpdateParameters parameters)
        {
            await _customerService.ModifyPasswordAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPhoneNumber")]
        public async Task<IActionResult> ModifyPhoneNumberAsync(CustomerUpdateParameters parameters)
        {
            await _customerService.ModifyPhoneNumberAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            return Ok(_bookService.GetAllBooksAsync()); 
        }

        [HttpPost]
        [Route("Borrow_Book")]
        public async Task<IActionResult> Borrow_BookAsync(BorrowOrReturn_BookParameter parameters)
        {
           await _customerService.Borrow_BookAsync(parameters);
           return Ok();
        }


        [HttpPost]
        [Route("ReturnBorrow_sBook")]
        public async Task<IActionResult> ReturnBorrow_sBookAsync(CustomerGetByParameter parameter)
        {
            return Ok(await _customerService.ReturnBorrow_sBookAsync(parameter));
        }


        [HttpPost]
        [Route("Return_Book")]
        public async Task<IActionResult> Return_BookAsync(BorrowOrReturn_BookParameter parameter)
        {
            await _customerService.Return_BookAsync(parameter);
            return Ok();
        }
    }
}
