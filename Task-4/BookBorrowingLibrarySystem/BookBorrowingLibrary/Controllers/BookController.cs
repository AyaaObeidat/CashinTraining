using BookBorrowingLibrary.Services;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowingLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync([FromBody] BookCreateParameters book)
        {
            await _bookService.AddAsync(book);
            return (Ok());
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] BookGetByParameters book)
        {
            await _bookService.DeleteAsync(book);
            return (Ok());
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _bookService.GetAllAsync();
            return (Ok(books));
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromBody] BookGetByParameters parameter)
        {
            var book = await _bookService.GetByIdAsync(parameter);
            return (Ok(book));
        }

        [HttpPatch]
        [Route("ModifyName")]
        public async Task<IActionResult> ModifyNameAsync([FromBody] BookUpdateParameters parameters)
        {
            await _bookService.ModifyName(parameters);
            return (Ok());
        }



    }
}
