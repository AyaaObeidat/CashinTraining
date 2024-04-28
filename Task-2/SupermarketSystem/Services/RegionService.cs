using SupermarketSystem.Dtos.CountryDtos;
using SupermarketSystem.Dtos.RegionDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Repositories.Implementations;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Services
{
    public class RegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<List<RegionDetails>> GetAllAsync()
        {
            var regions = await _regionRepository.GetAllAsync();
            return regions.Select(c => new RegionDetails
            {
                Id = c.Id,
                Name = c.Name,

            }).ToList();
        }

        public async Task<RegionDetails> GetByIdAsync(Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            return new RegionDetails
            {
                Id = region.Id,
                Name = region.Name,

            };
        }

        public async Task AddAsync(RegionCreateParameters parameters)
        {
            var region = Region.Create(parameters.Name);
            await _regionRepository.AddAsync(region);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _regionRepository.DeleteAsync(id);
        }
        public async Task UpdateAsync(RegionUpdateParameters parameters)
        {
            Region region = await _regionRepository.GetByIdAsync(parameters.Id);
            region.SetName(parameters.Name);
            await _regionRepository.UpdateAsync(region);
        }
    }
}
