using System;
using System.Collections.Generic;
using System.Text;

namespace PayslipGenerator.Interfaces
{
    public interface IPaySlipDetailRequest
    {
         string EmployeeName { get; set; }

         double AnnualSalary { get; set; }
    }

    
}
