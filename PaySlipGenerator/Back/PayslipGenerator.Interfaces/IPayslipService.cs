using System;
using System.Collections.Generic;
using System.Text;

namespace PayslipGenerator.Interfaces
{
    public interface IPayslipService
    {
        IPayslipDetailResponse GetSalaryDetials(string empName, decimal annualSalary);
    }
}
