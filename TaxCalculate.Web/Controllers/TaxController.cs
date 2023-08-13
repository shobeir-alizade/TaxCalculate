
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxCalculate.Core.Domains;
using TaxCalculate.Service.Tax.Infrastructure;
using TaxCalculate.ViewModel;

namespace TaxCalculate.Controllers
{
    public class TaxController : Framework.TaxCalculateBaseController
    {
        private readonly ITaxService _taxService;
        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }
        [HttpPost("CalculateTax")]
        [AllowAnonymous]
        public async Task<IActionResult> CalculateTax(VehicleTaxViewModel model)
        {
            // we shoud use auto mapper
            // 
            Service.Tax.DTO.Vehicle vehicle = new Service.Tax.DTO.Vehicle();
            vehicle.Caption = model.Vehicle.Caption;

            await _taxService.CalculateTaxByVehicleAsync(model.DateTimes, vehicle);

            return Ok();

        }
    }
}
