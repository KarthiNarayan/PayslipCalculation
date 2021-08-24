using PayslipGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayslipGenerator.Domain
{
    public class PaySlipDetailRequest : IPaySlipDetailRequest
    {
        public string  EmployeeName { get; set; }

        public double AnnualSalary { get; set; }
    }
}
