using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.SecurityTokenService;
using Moq;
using NUnit.Framework;
using PayslipGenerator.Api.Controllers;
using PayslipGenerator.Interfaces;
using PayslipGenerator.Service;
using System;

namespace PayslipGenerator.Test
{
    public class Tests
    {

		private PayslipGeneratorController _payslipController;
		private Mock<IPayslipService> _mockPayslipServiceMok;
		private Mock <ILogger<PayslipGeneratorController>>  _mockPayslipServiceLoggerMok;

		private PayslipService _payslipService;

		[SetUp]
		public void SetUp()
		{
			_mockPayslipServiceMok = new Mock<IPayslipService>();
			_mockPayslipServiceLoggerMok = new Mock<ILogger<PayslipGeneratorController>>();
		}

		[TearDown]
		public void TearDown()
		{
			_mockPayslipServiceMok = null;
			_payslipController = null;
		}
		[Test]
		public void GIVEN_Controller_WHEN_InitialiseWithPayslipServiceIsNull_SHOULD_ThrowArgumentNullException()
		{
			Assert.Throws(typeof(ArgumentNullException), () => new PayslipGeneratorController(null, null));
		}

		[Test]
		public void GIVEN_Get_WHEN_SalaryZeroOrNegative_SHOULD_ThrowBadRequestException()
		{
			_payslipController = new PayslipGeneratorController(_mockPayslipServiceMok.Object, _mockPayslipServiceLoggerMok.Object);

			Assert.Throws(typeof(BadRequestException), () => _payslipController.GetPayDetails("mark", 0));
		}

		[Test]
		public void GIVEN_Get_WHEN_EmptyEmployeeName_SHOULD_ThrowException()
		{
			_payslipController = new PayslipGeneratorController(_mockPayslipServiceMok.Object, _mockPayslipServiceLoggerMok.Object);

			Assert.Throws(typeof(Exception), () => _payslipController.GetPayDetails("", 60000));
		}

		[Test]
		public void GIVEN_Get_WHEN_EmpName_AnnualSalry_SHOULD_ReturnPayDetails()
		{
			_payslipController = new PayslipGeneratorController(_mockPayslipServiceMok.Object, _mockPayslipServiceLoggerMok.Object);

			var details = _payslipController.GetPayDetails("Mark", 60000);

			Assert.That(details != null);
		}

		[Test]
		public void GIVEN_Get_WHEN_EmpName_AnnualSalry_SHOULD_ReturnCorrectNetValue()
		{
			_payslipController = new PayslipGeneratorController(_mockPayslipServiceMok.Object, _mockPayslipServiceLoggerMok.Object);
			
			var details = _payslipService.GetSalaryDetials("Mark", 60000);

			Assert.That(details != null);
		}


		[Test]
        public void Test1()
        {
			
			Assert.Pass();
        }
    }
}