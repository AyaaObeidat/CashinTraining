using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingTransactionDtos;
using BookBorrowingLibraryDtos.UserDtos;
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
            
            var allBorrowingTransactions = await _transactionRepository.GetAllAsync();
            foreach (var transaction in allBorrowingTransactions)
            {
                if ( transaction.UserId != user.Id || transaction.BookId != book.Id || transaction.ReturnStatus == BookReturnStatus.Returned) continue;
                else throw new ArgumentException("This book is actually borrowed from this user");
            }

            var borrowingTransaction = BorrowingTransaction.Create(parameters.UserId, parameters.BookId);
            await _transactionRepository.AddAsync(borrowingTransaction);

            book.SetNumberOfCopies(book.NumberOfCopies - 1);
            book.SetStatus(BookStatus.Borrowed);
            await _bookRepository.UpdateAsync(book);

            decimal totalAmountOfBorrowingBooks = user.TotalPriceOfBorrowingBooks + book.Price;
            user.SetTotalPriceOfBorrowingBooks(totalAmountOfBorrowingBooks);
            await _userRepository.UpdateAsync(user);
        }

        public async Task ReturningBookAsync(BorrowingTransactionGetByParameter parameters)
        {
            var book = await _bookRepository.GetByIdAsync(parameters.BookId);
            var user = await _userRepository.GetByIdAsync(parameters.UserId);
            if (book == null || user == null) return;

            var borrowingTransactions = await _transactionRepository.GetAllAsync();
            foreach(var transaction in borrowingTransactions)
            {
                if(transaction.BookId == book.Id && transaction.UserId == user.Id)
                {
                    transaction.SetActualReturnDate();
                    transaction.SetBookReturnStatus();
                    await _transactionRepository.UpdateAsync(transaction);
                    book.SetNumberOfCopies(book.NumberOfCopies + 1);    
                    await _bookRepository.UpdateAsync(book);

                    int numberOfDays = (int)Math.Round((transaction.ActualReturnDate - transaction.RequiredReturnDate).TotalDays);

                    decimal fine;
                    if (numberOfDays <= 0) fine = 0;
                    else if (numberOfDays >= 1 && numberOfDays<= 3)
                    {
                        fine = book.Price - (book.Price * (decimal)0.50);

                    }

                    else
                    {
                        fine = book.Price;

                    }

                    transaction.SetArrangedFine(fine);
                    await _transactionRepository.UpdateAsync(transaction);
                    decimal totalAmountOfBorrowingBooks = user.TotalPriceOfBorrowingBooks + fine;
                    user.SetTotalPriceOfBorrowingBooks(totalAmountOfBorrowingBooks);
                    await _userRepository.UpdateAsync(user);
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
                ReturnedDate = t.RequiredReturnDate,
                
            }).ToList();
        }

        public async Task<bool> CanBorrowBookAsync(UserGetByParameter parameter)
        {
            var user = await _userRepository.GetByIdAsync(parameter.Id);
            var userBooks = user.Books.ToList();
            if (userBooks.Count < 2) return true;
            else
            {
                var notReturnedBooks = userBooks.Where(x => x.ReturnStatus == BookReturnStatus.NotReturned).ToList();
                if(notReturnedBooks.Count < 2) return true;
            }
            return false;
        }
    }
}
