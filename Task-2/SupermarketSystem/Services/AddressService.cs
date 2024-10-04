using SupermarketSystem.Dtos.AddressDtos;
using SupermarketSystem.Dtos.CountryDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Implementations;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Services
{
    public class AddressService
    {

        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<AddressDetails>> GetAllAsync()
        {
            var addresses = await _addressRepository.GetAllAsync();
            return addresses.Select(c => new AddressDetails
            {
                Id = c.Id,
                CountryId = c.CountryId,
                CityId = c.CityId,
                RegionId = c.RegionId,
                TextAddress = c.TextAddress,

            }).ToList();
        }

        public async Task<AddressDetails> GetByIdAsync(Guid id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            return new AddressDetails
            {
                Id = address.Id,
                CountryId = address.CountryId,
                CityId = address.CityId,
                RegionId = address.RegionId,
                TextAddress = address.TextAddress,
            };
        }

        public async Task AddAsync(AddressCreateParameters parameters)
        {
            var address = Address.Create(parameters.TextAddress , parameters.CountryId , parameters.CityId , parameters.RegionId);
            await _addressRepository.AddAsync(address);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _addressRepository.DeleteAsync(id);
        }
        public async Task UpdateAsync(AddressUpdateParameters parameters)
        {
            Address address = await _addressRepository.GetByIdAsync(parameters.Id);
            address.Update(parameters.TextAddress , parameters.CountryId , parameters.CityId , parameters.RegionId);
            await _addressRepository.UpdateAsync(address);
        }
    }
}
