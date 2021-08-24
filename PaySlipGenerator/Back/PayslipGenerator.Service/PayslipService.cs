
using PayslipGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayslipGenerator.Service
{
    public class PayslipService: IPayslipService
    {
        private readonly IPayslipRepository _payslipRepository;


        public PayslipService(IPayslipRepository payslipRepository)
        {
            if (payslipRepository == null) throw new ArgumentNullException(nameof(payslipRepository));
            _payslipRepository = payslipRepository;
           
        }
      
        public IPayslipDetailResponse  GetSalaryDetials(string empName, decimal annualSalary)
        {
            return  _payslipRepository.GetDetails(empName, annualSalary);
        }
    }
}
