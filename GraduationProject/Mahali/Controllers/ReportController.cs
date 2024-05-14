using Mahali.Dtos.ReportDtos;
using Mahali.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> WriteReportAsync(ReportCreateParameters parameters)
        {
            await _reportService.WriteReportAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<IActionResult> EditReportTextAsync(ReportUpdateParameters parameters)
        {
            await _reportService.EditReportTextAsync(parameters);
            return Ok();
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteReportAsync(ReportDeleteParameters reportDelete)
        {
            await _reportService.DeleteReportAsync(reportDelete);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllReportsAsync()
        {
            return Ok(await _reportService.GetAllReportsAsync());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(ReportGetByParameters parameters)
        {
            return Ok(await _reportService.GetByIdAsync(parameters));
        }
    }
}
