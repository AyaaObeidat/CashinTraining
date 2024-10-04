using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingTransactionDtos;
using BookBorrowingLibraryDtos.UserDtos;

namespace BookBorrowingLibrary.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddAsync(BookCreateParameters book)
        {
            var newBook = Book.Create(book.Name, book.NumberOfCopies, book.Classification,book.Price);
            await _bookRepository.AddAsync(newBook);
        }

        public async Task DeleteAsync(BookGetByParameters book)
        {
            var selectedBook = await _bookRepository.GetByIdAsync(book.Id);
            if (selectedBook == null) return;
            await _bookRepository.DeleteAsync(book.Id);
        }

        public async Task<List<BookDetails>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(b => new BookDetails
            {
                Name = b.Name,
                NumberOfCopies = b.NumberOfCopies,
                Classification = b.Classification,
                Status = b.Status,
                Price = b.Price,
                Users = b.Users.Select( x => new BorrowingTransactionDetails
                {
                    UserId = x.UserId
                }).ToList(),
                
            }).ToList();
        }

        public async Task<BookDetails?> GetByIdAsync(BookGetByParameters parameters)
        {
            var book = await _bookRepository.GetByIdAsync(parameters.Id);
            if (book == null) return null;
            return new BookDetails
            {
                Name = book.Name,
                NumberOfCopies = book.NumberOfCopies,
                Classification = book.Classification,
                Status = book.Status,
                Price= book.Price,
                Users = book.Users.Select(x => new BorrowingTransactionDetails
                {
                    UserId = x.UserId,
                }).ToList(),

            };
        }

        public async Task ModifyName (BookUpdateParameters parameters)
        {
            var books = await _bookRepository.GetAllAsync();
            foreach (var book in books)
            {
                if(book.Name == parameters.CurrentName)
                {
                    book.SetName(parameters.NewName);
                    await _bookRepository.UpdateAsync(book);
                }
            }

        }
    }
}
