using SupermarketSystem.Dtos.CountryDtos;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Services
{
    public class CountryService
    {

        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<CountryDetails>> GetAllAsync()
        {
            var countries = await _countryRepository.GetAllAsync();
            return countries.Select(c => new CountryDetails
            {
                Id = c.Id,
                Name = c.Name,

            }).ToList();
        }

        public async Task<CountryDetails> GetByIdAsync(Guid id)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            return new CountryDetails
            {
                Id = country.Id,
                Name = country.Name,

            };
        }

        public async Task AddAsync(CountryCreateParameters parameters)
        {
            var country = Country.Create(parameters.Name);
            await _countryRepository.AddAsync(country);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _countryRepository.DeleteAsync(id);
        }
        public async Task UpdateAsync(CountryUpdateParameters parameters)
        {
            Country country = await _countryRepository.GetByIdAsync(parameters.Id);
            country.SetName(parameters.Name);
            await _countryRepository.UpdateAsync(country);
        }
    }
}
