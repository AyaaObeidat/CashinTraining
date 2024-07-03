using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingTransactionDtos;
using BookBorrowingLibraryEnums;

namespace BookBorrowingLibrary.Services
{
    public class BorrowingTransactionService
    {
        private readonly IBorrowingTransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;   
        public BorrowingTransactionService(IBorrowingTransactionRepository transactionRepository , IUserRepository userRepository , IBookRepository bookRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task BorrowingBookAsync(BorrowingTransactionCreateParameters parameters)
        {
            var user = await _userRepository.GetByIdAsync(parameters.UserId);
            var book = await _bookRepository.GetByIdAsync(parameters.BookId);
            if (user == null || book == null) return;
            if(book.NumberOfCopies <=0 ) return;

            var borrowingTransaction = BorrowingTransaction.Create(parameters.UserId, parameters.BookId);
            await _transactionRepository.AddAsync(borrowingTransaction);

            book.SetNumberOfCopies(book.NumberOfCopies - 1);
            book.SetStatus(BookStatus.Borrowed);
            await _bookRepository.UpdateAsync(book);
        }

        public async Task ReturningBookAsync(BookGetByParameters parameters)
        {
            var book = await _bookRepository.GetByIdAsync(parameters.Id);
            if (book == null) return;

            var borrowingTransactions = await _transactionRepository.GetAllAsync();
            foreach(var transaction in borrowingTransactions)
            {
                if(transaction.BookId == book.Id)
                {
                    await _transactionRepository.DeleteAsync(transaction.Id);
                    book.SetNumberOfCopies(book.NumberOfCopies + 1);    
                    await _bookRepository.UpdateAsync(book);
                }
            }
     
        }

        public async Task<List<BorrowingTransactionDetails>> GetAllAsync()
        {
            var borrowingTransactions = await _transactionRepository.GetAllAsync();
            return borrowingTransactions.Select(t => new BorrowingTransactionDetails()
            {
                UserId = t.UserId,
                BookId = t.BookId,
                BorrowedDate = t.BorrowedDate,
                ReturnedDate = t.ReturnedDate,
            }).ToList();
        }
    }
}
