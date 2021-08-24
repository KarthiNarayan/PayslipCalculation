using System;
using System.Collections.Generic;
using System.Text;

namespace PayslipGenerator.Interfaces
{
    public interface IPayslipRepository
    {
        IPayslipDetailResponse GetDetails(string empName, decimal annualSalary);
    }
}
