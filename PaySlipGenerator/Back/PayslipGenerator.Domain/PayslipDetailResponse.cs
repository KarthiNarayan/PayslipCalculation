using PayslipGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayslipGenerator.Domain
{
    public class PayslipDetailResponse : IPayslipDetailResponse
    {
        public decimal GrossMonthlyIncome { get; set; }
        public decimal MonthlyIncomeTax { get; set; }
        public decimal NetMonthlyIncome { get; set; }
    }
}
