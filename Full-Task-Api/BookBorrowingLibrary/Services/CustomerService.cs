using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.Interfaces;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingBook;
using BookBorrowingLibraryDtos.CustomerDtos;
using BookBorrowingLibraryEnums;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookBorrowingLibrary.Services
{
    public class CustomerService
    {
        private readonly IUserInterface _userInterface;
        private readonly IBookInterface _bookInterface;
        private readonly IReturnTransactionInterface _returnTransactionInterface;
        private readonly IBorrowingTransactionInterface _borrowingTransactionInterface;

        public CustomerService(IUserInterface userInterface, IBookInterface bookInterface, IBorrowingTransactionInterface borrowingTransactionInterface, IReturnTransactionInterface returnTransactionInterface)
        {
            _userInterface = userInterface;
            _bookInterface = bookInterface;
            _borrowingTransactionInterface = borrowingTransactionInterface;
            _returnTransactionInterface = returnTransactionInterface;
        }

        public async Task RegisterAsync(RegisterParameters parameters)
        {
            var customers = await _userInterface.GetAllCustomersAsync();
            var notValidCustomers = customers.ToList().Where(u => u.FullName == parameters.FullName || u.Email == parameters.Email || u.PhoneNumber == parameters.PhoneNumber).ToList();
            if (notValidCustomers.Count() > 0) throw new Exception("A user with the same full name, email, or phone number already exists.");
            else
            {
                var user = User.Create(parameters.FullName, parameters.Email, parameters.PhoneNumber, parameters.Password);
                await _userInterface.AddAsync(user);
                user.SetIsCustomer();
                await _userInterface.UpdateAsync(user);
            }
        }//cus

        public async Task<CustomerDetails> LoginAsync(LoginParameters parameters)
        {
            var users = await _userInterface.GetAllAsync();
            var user = users.FirstOrDefault(c => c.Email == parameters.Email && c.Password == parameters.Password && c.Status == RequestStatus.Accepted);
            if (user == null) throw new Exception("Invalid email, password, or the account is not accepted.");
            else
            {

                var book = await _bookInterface.GetByIdAsync(user.BookId);
                return new CustomerDetails
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,
                    Book = book != null ? new BookDetails
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Description = book.Description,
                        Author = book.Author,
                        Publisher = book.Publisher,
                        PublicationYear = book.PublicationYear,
                        NumberOfAvailableCopies = book.NumberOfAvailableCopies,
                        TotalNumberOfCopies = book.TotalNumberOfCopies,
                    } : null,
                    IsAdmin = user.IsAdmin,
                    Status = user.Status,
                };
            }

        }//cus

        public async Task ModifyFullNameAsync(CustomerUpdateParameters parameters)
        {
            var customer = await _userInterface.GetByIdAsync(parameters.Id);
            if (customer == null) throw new ArgumentNullException("Customer not found");
            var customers = await _userInterface.GetAllCustomersAsync();
            var NotValidCustomers = customers.ToList().Where(c => c.FullName == parameters.NewFullName).ToList();
            if (NotValidCustomers.Count > 0) throw new Exception("This full name is already in use.");
            else
            {
                customer.SetFullName(parameters.NewFullName);
                await _userInterface.UpdateAsync(customer);
            }
        
        } //cus

        public async Task ModifyPasswordAsync(CustomerUpdateParameters parameters)
        {
            var customer = await _userInterface.GetByIdAsync(parameters.Id);
            if (customer == null) throw new ArgumentNullException("Customer not found");
            else if (customer.Password == parameters.CurrentPassword)
            {
                var customers = await _userInterface.GetAllCustomersAsync();
                var NotValidCustomers = customers.ToList().Where(c => c.Password == parameters.NewPassword).ToList();
                if (NotValidCustomers.Count > 0) throw new Exception("This password is already in use.");
                else
                {
                    customer.SetPassword(parameters.NewPassword);
                    await _userInterface.UpdateAsync(customer);
                }
            }
            else throw new Exception("The current password does not match the existing password.");
        }//cus

        public async Task ModifyPhoneNumberAsync(CustomerUpdateParameters parameters)
        {
            var customer = await _userInterface.GetByIdAsync(parameters.Id);
            if (customer == null) throw new ArgumentNullException("Customer not found");
                var customers = await _userInterface.GetAllCustomersAsync();
                var NotValidCustomers = customers.ToList().Where(c => c.PhoneNumber == parameters.NewPhoneNumber).ToList();
                if (NotValidCustomers.Count > 0) throw new Exception("This phoneNumber is already in use.");
                else
                {
                    customer.SetPhoneNumber(parameters.NewPhoneNumber);
                    await _userInterface.UpdateAsync(customer);
                }
        }//cus

        public async Task Borrow_BookAsync(BorrowOrReturn_BookParameter parameter)
        {
            var customer = await _userInterface.GetByIdAsync(parameter.UserId);
            var book = await _bookInterface.GetByIdAsync(parameter.BookId);
            if (customer == null || book == null) throw new ArgumentNullException("customer or book not found");
            if(await CanBorrowBookAsync(customer) && book.NumberOfAvailableCopies > 0)
            {
                var borrow_book = BorrowingTransaction.Create(customer.Id , book.Id);
                await _borrowingTransactionInterface.AddAsync(borrow_book);
                
            }

        }//cus

        public async Task Return_BookAsync(BorrowOrReturn_BookParameter parameter)
        {
            var customer = await _userInterface.GetByIdAsync(parameter.UserId);
            var book = await _bookInterface.GetByIdAsync(parameter.BookId);
            if (customer == null || book == null) throw new ArgumentNullException("customer or book not found");

            var returnBook_trans = ReturnTransaction.Create(customer.Id , book.Id);
            await _returnTransactionInterface.AddAsync(returnBook_trans);

            customer.SetBookId(Guid.Empty);
            await _userInterface.UpdateAsync(customer); 
           

        }//cus

        public async Task<CustomerDetails> GetCustomerByIdAsync(CustomerGetByParameter parameter)
        {
            var customer = await _userInterface.GetByIdAsync(parameter.Id);
            if(customer == null) throw new ArgumentNullException("customer not found");
            var book = await _bookInterface.GetByIdAsync(customer.BookId);
            return new CustomerDetails
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber,
                Book = book != null ? new BookDetails
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    Publisher = book.Publisher,
                    PublicationYear = book.PublicationYear,
                    NumberOfAvailableCopies = book.NumberOfAvailableCopies,
                    TotalNumberOfCopies = book.TotalNumberOfCopies,
                }:null,
                IsAdmin = customer.IsAdmin,
                Status = customer.Status,
            };
        }

        public async Task<List<CustomerDetails>> GetAllAcceptedCustomerAsync()
        {
            var customers = (await _userInterface.GetAllCustomersAsync()).ToList();
            var books = (await _bookInterface.GetAllAsync()).ToList();
            if (customers.Count == 0) throw new ArgumentException("Not found any customer yet");
            return customers.Where(x => x.Status == RequestStatus.Accepted).ToList().Select( c =>
            {
                var book = books.FirstOrDefault(b => b.Id == c.BookId);
                return new CustomerDetails
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    Email = c.Email,
                    Password = c.Password,
                    PhoneNumber = c.PhoneNumber,
                    Book = book != null ? new BookDetails
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Description = book.Description,
                        Author = book.Author,
                        Publisher = book.Publisher,
                        PublicationYear = book.PublicationYear,
                        NumberOfAvailableCopies = book.NumberOfAvailableCopies,
                        TotalNumberOfCopies = book.TotalNumberOfCopies,
                    }:null,
                    IsAdmin = c.IsAdmin,
                    Status = c.Status,
                };

            }).ToList();
       
            
        }//adm

        public async Task<List<CustomerDetails>> GetAllPendingCustomerAsync()
        {
            var customers = await _userInterface.GetAllCustomersAsync();
            if (customers.Count == 0) throw new ArgumentException("Not found any customer yet");
            var books = await _bookInterface.GetAllAsync();
            return customers.ToList().Where(x => x.Status == RequestStatus.Pending).ToList().Select(c =>
            {
                var book = books.FirstOrDefault(b => b.Id == c.BookId);
                return new CustomerDetails
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    Email = c.Email,
                    Password = c.Password,
                    PhoneNumber = c.PhoneNumber,
                    Book = book != null ? new BookDetails
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Description = book.Description,
                        Author = book.Author,
                        Publisher = book.Publisher,
                        PublicationYear = book.PublicationYear,
                        NumberOfAvailableCopies = book.NumberOfAvailableCopies,
                        TotalNumberOfCopies = book.TotalNumberOfCopies,
                    }:null,
                    IsAdmin = c.IsAdmin,
                    Status = c.Status,
                };

        }).ToList();

    }//adm

        public async Task<List<CustomerDetails>> GetAllBlockedCustomerAsync()
        {
            var customers = await _userInterface.GetAllCustomersAsync();
            if (customers.Count == 0) throw new ArgumentException("Not found any customer yet");
            var books = await _bookInterface.GetAllAsync();
            return customers.ToList().Where(x => x.Status == RequestStatus.Rejected).ToList().Select(c =>
            {
                var book = books.FirstOrDefault(b => b.Id == c.BookId);
                return new CustomerDetails
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    Email = c.Email,
                    Password = c.Password,
                    PhoneNumber = c.PhoneNumber,
                    Book = book != null ? new BookDetails
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Description = book.Description,
                        Author = book.Author,
                        Publisher = book.Publisher,
                        PublicationYear = book.PublicationYear,
                        NumberOfAvailableCopies = book.NumberOfAvailableCopies,
                        TotalNumberOfCopies = book.TotalNumberOfCopies,
                    }:null,
                    IsAdmin = c.IsAdmin,
                    Status = c.Status,
                };

        }).ToList();

    }//adm

        public async Task<BookDetails?> ReturnBorrow_sBookAsync(CustomerGetByParameter parameter)
        {
            var customer = await _userInterface.GetByIdAsync(parameter.Id);
            if (customer == null) throw new ArgumentNullException("Customer not found");
            if (customer.BookId == Guid.Empty) return null;
            else
            {
                var book = await _bookInterface.GetByIdAsync(customer.BookId);
                return new BookDetails
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    Publisher = book.Publisher,
                    PublicationYear = book.PublicationYear,

                };
            }
        }//cus

        //Business Validation
        public async Task<bool> CanBorrowBookAsync(User customer)
        {
            var borrowingTransactions = await _borrowingTransactionInterface.GetAllAsync();
            var borrowTransaction = borrowingTransactions.ToList().FirstOrDefault(bt => bt.UserId ==  customer.Id);
            if (borrowingTransactions == null) return true;
            return false;
          
        }
    }
}
