using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;
using BookBorrowingLibraryDtos.AdminDtos;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingBookDtos;
using BookBorrowingLibraryDtos.BorrowingOrReturnBookDtos;
using BookBorrowingLibraryDtos.CustomerDtos;
using BookBorrowingLibraryEnums;

namespace BookBorrowingLibrary.Services
{
    public class AdminService
    {
        private readonly IUserInterface _userInterface;
        private readonly IBorrowingTransactionInterface _borrowingTransactionInterface;
        private readonly IBookInterface _bookInterface;
        private readonly IReturnTransactionInterface _returnTransactionInterface;
        private readonly IDamagedBooksInterface _damagedBooksInterface;

        public AdminService(IUserInterface userInterface , IBorrowingTransactionInterface borrowingTransactionInterface,IBookInterface bookInterface,IReturnTransactionInterface returnTransactionInterface,
            IDamagedBooksInterface damagedBooksInterface)
        {
            _userInterface = userInterface;
            _borrowingTransactionInterface = borrowingTransactionInterface;
            _bookInterface = bookInterface;
            _returnTransactionInterface = returnTransactionInterface;
            _damagedBooksInterface = damagedBooksInterface;
        }


        public async Task ModifyFullNameAsync(AdminUpdateParameters parameters)
        {
            var admin = await _userInterface.GetAdminAsync();
            if (admin.FullName == parameters.CurrentFullName)
            {
                    admin.SetFullName(parameters.NewFullName);
                    await _userInterface.UpdateAsync(admin);
            }
            else throw new Exception("The current full name does not match the existing name.");
        }//adm

        public async Task ModifyPasswordAsync(AdminUpdateParameters parameters)
        {
            var admin = await _userInterface.GetAdminAsync();
            if (admin.Password == parameters.CurrentPassword)
            {
                admin.SetPassword(parameters.NewPassword);
                await _userInterface.UpdateAsync(admin);
            }
            else throw new Exception("The current password name does not match the existing password.");
        }//adm

        public async Task AcceptNewCustomerAsync(CustomerGetByParameter parameter)
        {
            var user = await _userInterface.GetByIdAsync(parameter.Id);
            if (user == null) throw new ArgumentNullException("customer not found");
            user.SetAcceptedStatus();
            await _userInterface.UpdateAsync(user);

        }//adm

        public async Task RejectCustomerAsync(CustomerGetByParameter parameter)
        {
            var customer = await _userInterface.GetByIdAsync(parameter.Id);
            if (customer == null) throw new ArgumentNullException("Customer not found");
            await _userInterface.DeleteAsync(parameter.Id);
        }//adm

        public async Task BlockCustomerAsync(User user)
        {
            user.SetRejectedStatus();
            await _userInterface.UpdateAsync(user);
        }//adm
        public async Task UnBlockCustomerAsync(CustomerGetByParameter parameter)
        {
            var customer =await _userInterface.GetByIdAsync(parameter.Id);
            customer.SetRejectedStatus();
            await _userInterface.UpdateAsync(customer);
        }//adm

        public async Task AcceptBorrowingBookRequestAsync(BorrowingBookGetByParameter parameter)
        {
            var borrow_book = await _borrowingTransactionInterface.GetByIdAsync(parameter.Id);
            if(borrow_book == null) throw new ArgumentNullException();
            borrow_book.SetAcceptedRequestStatus();
            borrow_book.SetDeliveryStatus();
            await _borrowingTransactionInterface.UpdateAsync(borrow_book);

            var user =await _userInterface.GetByIdAsync(borrow_book.UserId);
            var book = await _bookInterface.GetByIdAsync(borrow_book.BookId);

            user.SetBookId(book.Id);
            await _userInterface.UpdateAsync(user);

            book.SetNumberOfAvailableCopies(book.NumberOfAvailableCopies-1);
            book.SetUserId(user.Id);
            await _bookInterface.UpdateAsync(book);
        }//adm
        public async Task RejectBorrowingBookRequestAsync(BorrowingBookGetByParameter parameter)
        {
            var borrow_book = await _borrowingTransactionInterface.GetByIdAsync(parameter.Id);
            if (borrow_book == null) throw new ArgumentNullException();
            await _borrowingTransactionInterface.DeleteAsync(borrow_book.Id);
        }//adm

        public async Task BuyNewCopiesAsync(BookUpdateParameter parameter)
        {
            var book = await _bookInterface.GetByIdAsync(parameter.Id);
            if (book == null) throw new ArgumentNullException();
            book.SetNumberOfAvailableCopies(book.NumberOfAvailableCopies + parameter.NewNumberOfAvailableCopies);
            book.SetTotalNumberOfCopies(book.TotalNumberOfCopies + parameter.NewNumberOfAvailableCopies);
            await _bookInterface.UpdateAsync(book);

        }//adm

        public async Task DamagedACopyOfBookAsync(Book book)
        {
           
            var damagedBook = DamagedBooks.Create(book.Id);
            await _damagedBooksInterface.AddAsync(damagedBook);
            damagedBook.UpdateNumberOfDamagedCopies();
            await _damagedBooksInterface.UpdateAsync(damagedBook);

            book.SetNumberOfAvailableCopies(book.NumberOfAvailableCopies - 1);
            await _bookInterface.UpdateAsync(book);
        }//adm
        public async Task ReturnBookStatusAsync(ReturnBookGetByParameters parameter)
        {
            var returnBook_trans = await _returnTransactionInterface.GetByIdAsync(parameter.Id);
            if (returnBook_trans == null) throw new ArgumentNullException();
            var book = await _bookInterface.GetByIdAsync(returnBook_trans.BookId);
            var customer = await _userInterface.GetByIdAsync(returnBook_trans.UserId);

            if(parameter.BookStatus == BookStatus.NonCorrupt)
            {
                returnBook_trans.SetNonCorruptBookStatus();
                await _returnTransactionInterface.UpdateAsync(returnBook_trans);
                book.SetNumberOfAvailableCopies(book.NumberOfAvailableCopies + 1);
                await _bookInterface.UpdateAsync(book);
            }
            else
            {
                returnBook_trans.SetDamagedBookStatus();
                await _returnTransactionInterface.UpdateAsync(returnBook_trans);
                await this.DamagedACopyOfBookAsync(book);
                await this.BlockCustomerAsync(customer);
            }

        }//adm
    }
}
