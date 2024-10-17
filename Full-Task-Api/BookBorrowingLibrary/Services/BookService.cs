using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Repositories.implementations;
using BookBorrowingLibrary.Repositories.Interfaces;
using BookBorrowingLibraryDtos.BookDtos;
using BookBorrowingLibraryDtos.BorrowingOrReturnBookDtos;
using BookBorrowingLibraryDtos.CustomerDtos;
using BookBorrowingLibraryDtos.DamagedBooksDtos;
using BookBorrowingLibraryEnums;

namespace BookBorrowingLibrary.Services
{
    public class BookService
    {
        private readonly IBookInterface _bookInterface;
        private readonly IDamagedBooksInterface _damagedBooksInterface;
        private readonly IBorrowingTransactionInterface _borrowingTransactionInterface;
        private readonly IReturnTransactionInterface _returnTransactionInterface;
        private readonly IUserInterface _userInterface;

        public BookService(IBookInterface bookInterface, IDamagedBooksInterface damagedBooksInterface, IBorrowingTransactionInterface borrowingTransactionInterface, IUserInterface userInterface, IReturnTransactionInterface returnTransactionInterface)
        {
            _bookInterface = bookInterface;
            _damagedBooksInterface = damagedBooksInterface;
            _borrowingTransactionInterface = borrowingTransactionInterface;
            _userInterface = userInterface;
            _returnTransactionInterface = returnTransactionInterface;
        }

        public async Task AddNewBookAsync(BookCreateParameters parameters)
        {
            var book = Book.Create(parameters.Title,parameters.Description, parameters.Author, parameters.Publisher, parameters.PublicationYear, parameters.NumberOfAvailableCopies, parameters.TotalNumberOfCopies);
            await _bookInterface.AddAsync(book);
        }//adm

        public async Task<BookDetails> GetByIdAsync(BookGetByParameter parameter)
        {
            var book = await _bookInterface.GetByIdAsync(parameter.Id);
            if (book == null) throw new ArgumentNullException("Book not found");
            var customer = await _userInterface.GetByIdAsync(book.UserId);
            return new BookDetails
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Publisher = book.Publisher,
                PublicationYear = book.PublicationYear,
                NumberOfAvailableCopies = book.NumberOfAvailableCopies,
                TotalNumberOfCopies = book.TotalNumberOfCopies,
                Customer = customer!=null? new CustomerDetails
                {
                    Id = customer.Id,
                    FullName = customer.FullName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,       
                }:null,

            };
        }//adm

        public async Task<List<BookDetails>> GetAllBooksAsync()
        {
            var books = (await _bookInterface.GetAllAsync()).ToList();
            if (books.Count == 0) throw new ArgumentNullException("Books not found");
            var customers = (await _userInterface.GetAllCustomersAsync()).ToList();
            return books.Select(b =>
            {
                var customer = customers.FirstOrDefault(c => c.Id == b.UserId);
                return new BookDetails
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author = b.Author,
                    Publisher = b.Publisher,
                    PublicationYear = b.PublicationYear,
                    NumberOfAvailableCopies = b.NumberOfAvailableCopies,
                    TotalNumberOfCopies = b.TotalNumberOfCopies,
                    Customer = customer != null ? new CustomerDetails
                    {
                        Id = customer.Id,
                        FullName = customer.FullName,
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber,
                    }:null,

                };
            }).ToList();
           
        }//cus&adm

        public async Task DeleteAsync(BookGetByParameter parameter)
        {
            var book = await _bookInterface.GetByIdAsync(parameter.Id);
            if (book == null) throw new ArgumentNullException("Book not found");
            await _bookInterface.DeleteAsync(parameter.Id);
        }

        public async Task ModifyTitleAsync(BookUpdateParameter parameters)
        {
            var book = await _bookInterface.GetByIdAsync(parameters.Id);
            if (book == null) throw new ArgumentNullException("Book not found");
            book.SetTitle(parameters.NewTitle);
            await _bookInterface.UpdateAsync(book);
        }//adm
        public async Task ModifyAuthorAsync(BookUpdateParameter parameters)
        {
            var book = await _bookInterface.GetByIdAsync(parameters.Id);
            if (book == null) throw new ArgumentNullException("Book not found");
            book.SetAuthor(parameters.NewAuthor);
            await _bookInterface.UpdateAsync(book);
        }//adm
        public async Task ModifyPublisherAsync(BookUpdateParameter parameters)
        {
            var book = await _bookInterface.GetByIdAsync(parameters.Id);
            if (book == null) throw new ArgumentNullException("Book not found");
            book.SetPublisher(parameters.NewPublisher);
            await _bookInterface.UpdateAsync(book);
        }//adm
        public async Task ModifyPublisherYearAsync(BookUpdateParameter parameters)
        {
            var book = await _bookInterface.GetByIdAsync(parameters.Id);
            if (book == null) throw new ArgumentNullException("Book not found");
            book.SetPublisherYear(parameters.NewPublicationYear);
            await _bookInterface.UpdateAsync(book);
        }//adm
        public async Task ModifyNumberOfAvailableCopiesAsync(BookUpdateParameter parameters)
        {
            var book = await _bookInterface.GetByIdAsync(parameters.Id);
            if (book == null) throw new ArgumentNullException("Book not found");
            book.SetNumberOfAvailableCopies(parameters.NewNumberOfAvailableCopies);
            await _bookInterface.UpdateAsync(book);
        }//adm
        public async Task ModifyTotalNumberOfCopiesAsync(BookUpdateParameter parameters)
        {
            var book = await _bookInterface.GetByIdAsync(parameters.Id);
            if (book == null) throw new ArgumentNullException("Book not found");
            book.SetTotalNumberOfCopies(parameters.NewTotalNumberOfCopies);
            await _bookInterface.UpdateAsync(book);
        }//adm



        //BorrowBookRequest

        public async Task<List<BorrowBookDetails>> GetAllBorrowBooksPendingRequestsAsync()
        {
            var borrowTransactions = await _borrowingTransactionInterface.GetAllAsync();
            var customers = (await _userInterface.GetAllCustomersAsync()).ToList(); 
            var books = (await _bookInterface.GetAllAsync()).ToList(); 

            return borrowTransactions
                .Where(x => x.RequestStatus == RequestStatus.Pending)
                .Select(b =>
                {
                    var customer = customers.FirstOrDefault(c => c.Id == b.UserId);
                    var book = books.FirstOrDefault(k => k.Id == b.BookId);

                    return new BorrowBookDetails
                    {
                        Id = b.Id,
                        CreatedDate = b.CreatedDate,
                        RequestStatus = RequestStatus.Pending,
                        BookStatus = b.BookStatus,
                        DeliveryStatus = b.DeliveryStatus,
                        Customer = customer != null ? new CustomerDetails
                        {
                            Id = customer.Id,
                            FullName = customer.FullName,
                            Email = customer.Email,
                            PhoneNumber = customer.PhoneNumber,
                        }:null,
                        Book = book != null ? new BookDetails
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Description = book.Description,
                            Author = book.Author,
                            PublicationYear = book.PublicationYear,
                            Publisher = book.Publisher,
                        }:null
                    };
                })
                .ToList();
        }//adm
        public async Task<List<BorrowBookDetails>> GetAllBorrowBooksAcceptingRequestsAsync()
        {
            var borrowTransactions = await _borrowingTransactionInterface.GetAllAsync();
            var customers = (await _userInterface.GetAllCustomersAsync()).ToList();
            var books = (await _bookInterface.GetAllAsync()).ToList();

            return borrowTransactions
                .Where(x => x.RequestStatus == RequestStatus.Accepted)
                .Select(b =>
                {
                    var customer = customers.FirstOrDefault(c => c.Id == b.UserId);
                    var book = books.FirstOrDefault(k => k.Id == b.BookId);

                    return new BorrowBookDetails
                    {
                        Id = b.Id,
                        CreatedDate = b.CreatedDate,
                        RequestStatus = RequestStatus.Pending,
                        BookStatus = b.BookStatus,
                        DeliveryStatus = b.DeliveryStatus,
                        Customer = customer != null ? new CustomerDetails
                        {
                            Id = customer.Id,
                            FullName = customer.FullName,
                            Email = customer.Email,
                            PhoneNumber = customer.PhoneNumber,
                        }:null,
                        Book = book != null ? new BookDetails
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Description = book.Description,
                            Author = book.Author,
                            PublicationYear = book.PublicationYear,
                            Publisher = book.Publisher,
                        }:null
                    };
                })
                .ToList();
        }//adm

        //BookRequests
        public async Task<List<ReturnBookDetails>> GetAllReturnBooksTransactionsAsync()
        {
            var returnTransactions = await _returnTransactionInterface.GetAllAsync();
            var customers = (await _userInterface.GetAllCustomersAsync()).ToList();
            var books = (await _bookInterface.GetAllAsync()).ToList();

            return returnTransactions
                .Select(b =>
                {
                    var customer = customers.FirstOrDefault(c => c.Id == b.UserId);
                    var book = books.FirstOrDefault(k => k.Id == b.BookId);

                    return new ReturnBookDetails
                    {
                        Id = b.Id,
                        ReturnedDate = b.ReturnedDate,
                        BookStatus = b.BookStatus,
                        Customer = customer != null ? new CustomerDetails
                        {
                            Id = customer.Id,
                            FullName = customer.FullName,
                            Email = customer.Email,
                            PhoneNumber = customer.PhoneNumber,
                        }:null,
                        Book = book != null ? new BookDetails
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Description = book.Description,
                            Author = book.Author,
                            PublicationYear = book.PublicationYear,
                            Publisher = book.Publisher,
                        }:null
                    };
                })
                .ToList();
        }//adm

        //DamagedBook
        public async Task<List<DamagedBooksDetails>> GetAllDamagedBooksAsync()
        {
            var damagedBooks = await _damagedBooksInterface.GetAllAsync();
            var books = await _bookInterface.GetAllAsync();
            return damagedBooks.ToList().Where(x => x.DamageProceedings!=DamageProceedings.Reform).ToList().Select( d =>

            {
                var book = books.ToList().FirstOrDefault(b => b.Id == d.BookId);
                return new DamagedBooksDetails
                {
                    Id= d.Id,
                    NumberOfDamagedCopies = d.NumberOfDamagedCopies,
                    DamageProceedings = d.DamageProceedings,
                    Book = book != null ? new BookDetails
                    {
                        Id = book.Id,
                        Title= book.Title,
                        Description = book.Description,
                        Author = book.Author,
                        PublicationYear = book.PublicationYear,
                        Publisher = book.Publisher,
                    }:null
                    
                };
            }).ToList();
        }//adm
        public async Task RepairOfDamagedCopyAsync (DamagedBookGetByParameter parameter)
        {
            var damagedBook = await _damagedBooksInterface.GetByIdAsync(parameter.Id);
            damagedBook.SetReformDamageProceedings();
            await _damagedBooksInterface.UpdateAsync(damagedBook);

            var book = await _bookInterface.GetByIdAsync(damagedBook.BookId);
            book.SetNumberOfAvailableCopies(book.NumberOfAvailableCopies + 1);
            await _bookInterface.UpdateAsync(book);


            await _damagedBooksInterface.DeleteAsync(damagedBook.BookId);

        }//adm
    }
}
