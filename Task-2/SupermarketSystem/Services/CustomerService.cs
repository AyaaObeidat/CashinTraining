using SupermarketSystem.Dtos.AddressDtos;
using SupermarketSystem.Dtos.CustomerDtos;
using SupermarketSystem.Dtos.OrderDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Implementations;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDetails>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerDetails
            {
               Id = c.Id,
               Name = c.Name,
               PhoneNumber = c.PhoneNumber,
               AddressId = c.AddressId,
               orders = c.OrdersList,

            }).ToList();
        }

        public async Task<CustomerDetails> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return new CustomerDetails
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                AddressId = customer.AddressId,
                orders = customer.OrdersList,
            };
        }

        public async Task AddAsync(CustomerCreateParameters parameters)
        {
            var customer = Customer.Create(parameters.Name , parameters.PhoneNumber , parameters.AddressId);
            await _customerRepository.AddAsync(customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }
        public async Task UpdateNameAsync(CustomerUpdateParameters parameters)
        {
            Customer customer = await _customerRepository.GetByIdAsync(parameters.Id);
            customer.SetName(parameters.Name);
            await _customerRepository.UpdateAsync(customer);
        }
        public async Task UpdatePhoneNumberAsync(CustomerUpdateParameters parameters)
        {
            Customer customer = await _customerRepository.GetByIdAsync(parameters.Id);
            customer.SetPhoneNumber(parameters.PhoneNumber);
            await _customerRepository.UpdateAsync(customer);
        }
      
    }
}
