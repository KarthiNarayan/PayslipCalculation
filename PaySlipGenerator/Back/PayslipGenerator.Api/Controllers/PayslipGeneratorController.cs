using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PayslipGenerator.Domain;
using PayslipGenerator.Interfaces;
using System;
using System.Threading.Tasks;

namespace PayslipGenerator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayslipGeneratorController : ControllerBase
    {
        private readonly IPayslipService _payslipService;

        private readonly ILogger<PayslipGeneratorController> _logger;

        
        public PayslipGeneratorController(IPayslipService payslipService, ILogger<PayslipGeneratorController> logger)
        {
            this._logger = logger;

            _payslipService = payslipService;
        }


        [HttpGet("{empName}/{annualSalary}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IPayslipDetailResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PayslipDetailResponse>> GetPayDetails(string empName, decimal annualSalary)
        {
            try
            {
                if (string.IsNullOrEmpty(empName))
                    _logger.LogError("Employee name is mandatory");

                if (annualSalary < 0M)
                {
                    _logger.LogError($"{nameof(annualSalary)} must not be a negative decimal, was: {annualSalary}");
                }
                var salaryDetails = _payslipService.GetSalaryDetials(empName, annualSalary);

                return Ok(salaryDetails);
            }
            catch
            {

            }

        }


    }
}

      
    

