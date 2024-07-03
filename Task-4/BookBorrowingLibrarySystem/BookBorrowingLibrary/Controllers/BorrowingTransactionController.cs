using BookBorrowingLibrary.Services;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingTransactionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowingLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingTransactionController : ControllerBase
    {
        private readonly BorrowingTransactionService _transactionService;

        public BorrowingTransactionController(BorrowingTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("BorrowingBook")]
        [Authorize]
        public async Task<IActionResult> BorrowingBookAsync([FromBody] BorrowingTransactionCreateParameters parameters)
        {
            await _transactionService.BorrowingBookAsync(parameters);
            return Ok();
        }


        [HttpPost]
        [Route("ReturningBook")]
        [Authorize]
        public async Task<IActionResult> ReturningBookAsync([FromBody] BookGetByParameters parameters)
        {
            await _transactionService.ReturningBookAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            
            return Ok(await _transactionService.GetAllAsync());
        }
    }
}
