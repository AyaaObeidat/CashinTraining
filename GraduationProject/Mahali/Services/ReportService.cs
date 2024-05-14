using Mahali.Dtos.ReportDtos;
using Mahali.Models;
using Mahali.Repositories.Implementations;
using Mahali.Repositories.Interfaces;
using System.Data.Common;
using System.Reflection.Metadata;

namespace Mahali.Services
{
    public class ReportService
    {
        private readonly IReportInterface _reportInterface;
        private readonly IShopInterface _shopInterface;
        private readonly IAdminInterface _adminInterface;
        private readonly IShopRequestInterface _shopRequestInterface;

        public ReportService(IReportInterface reportInterface , IShopInterface shopInterface, IAdminInterface adminInterface,IShopRequestInterface shopRequestInterface)
        {
            _reportInterface = reportInterface;
            _shopInterface = shopInterface;
            _adminInterface = adminInterface;
            _shopRequestInterface = shopRequestInterface;
        }
        public async Task WriteReportAsync(ReportCreateParameters parameters)
        {
            var admin = await  _adminInterface.GetByIdAsync(await _adminInterface.GetIdAsync());
            var shop = await _shopInterface.GetByIdAsync(parameters.ShopId);
            var request = await _shopRequestInterface.GetRequestByShopIdAsync(shop.Id);
            if (request.Status == RequestStatus.Approved)
            {
                var report = Report.Create(admin.Id, shop.Id, parameters.ReportText);
                await _reportInterface.AddAsync(report);
            }

        }

        public async Task EditReportTextAsync(ReportUpdateParameters parameters)
        {
            var admin = await _adminInterface.GetByIdAsync(await _adminInterface.GetIdAsync());
            var shop = await _shopInterface.GetByIdAsync(parameters.ShopId);
            if (shop == null) return;
            var reports = await _reportInterface.GetAllAsync();
            var report = reports.FirstOrDefault(x => x.ShopId == shop.Id && x.AdminId == admin.Id);
            if (report == null) return;
            report.SetReportText(parameters.ReportText);
            await _reportInterface.UpdateAsync(report);
        }

        public async Task DeleteReportAsync(ReportDeleteParameters reportDelete)
        {
            var admin = await _adminInterface.GetByIdAsync(await _adminInterface.GetIdAsync());
            var shop = await _shopInterface.GetByIdAsync(reportDelete.ShopId);
            if (shop == null) return;
            var reports = await _reportInterface.GetAllAsync();
            var report = reports.FirstOrDefault(x => x.ShopId == shop.Id && x.AdminId == admin.Id);
            if (report == null) return;
            await _reportInterface.DeleteAsync(report);
        }

        public async Task<List<ReportListItems>> GetAllReportsAsync()
        {
            var reports = await _reportInterface.GetAllAsync();
            return reports.Select(x => new ReportListItems
            {
                ShopId = x.ShopId,
                ReportText = x.ReportText,
                CreatedAt = x.CreatedAt,
                LastModifiedTime = x.LastModifiedTime,

            }).ToList();
        }

        public async Task<ReportListItems?> GetByIdAsync(ReportGetByParameters parameters)
        {
            var report = await _reportInterface.GetByIdAsync(parameters.ID);
            if (report == null) return null;
            return new ReportListItems
            {
                ShopId = report.ShopId,
                ReportText = report.ReportText,
                CreatedAt = report.CreatedAt,
                LastModifiedTime = report.LastModifiedTime,

            };
        }
    }
}
