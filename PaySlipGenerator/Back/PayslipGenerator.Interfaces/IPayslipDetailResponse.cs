using System;
using System.Collections.Generic;
using System.Text;

namespace PayslipGenerator.Interfaces
{
    public interface IPayslipDetailResponse
    {
        decimal GrossMonthlyIncome { get; set; }
        decimal MonthlyIncomeTax { get; set; }
        decimal NetMonthlyIncome { get; set; }
    }
}
