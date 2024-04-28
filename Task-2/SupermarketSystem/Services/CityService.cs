using SupermarketSystem.Dtos.CityDtos;
using SupermarketSystem.Dtos.CountryDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Implementations;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Services
{
    public class CityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityDetails>> GetAllAsync()
        {
            var cities = await _cityRepository.GetAllAsync();
            return cities.Select(c => new CityDetails
            {
                Id = c.Id,
                Name = c.Name,

            }).ToList();
        }

        public async Task<CityDetails> GetByIdAsync(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            return new CityDetails
            {
                Id = city.Id,
                Name = city.Name,

            };
        }

        public async Task AddAsync(CityCreateParameters parameters)
        {
            var city = City.Create(parameters.Name);
            await _cityRepository.AddAsync(city);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
        }
        public async Task UpdateAsync(CityUpdateParameters parameters)
        {
            City city = await _cityRepository.GetByIdAsync(parameters.Id);
            city.SetName(parameters.Name);
            await _cityRepository.UpdateAsync(city);
        }
    }
}
