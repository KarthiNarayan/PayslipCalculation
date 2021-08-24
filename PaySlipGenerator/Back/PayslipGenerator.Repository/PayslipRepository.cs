using PayslipGenerator.Interfaces;
using PayslipGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayslipGenerator.Repository
{
    public class PayslipRepository : IPayslipRepository
    {
        private const int MonthsInYear = 12;

        public  IPayslipDetailResponse GetDetails(string empName, decimal annualSalary)
        {

            //Do the calculation here
            decimal grossMonthlyIncome = CalculatedGrossIncome(annualSalary);
            decimal monthlyTax = CalculatedIncomeTax(annualSalary);
            decimal netMonthlyIncome = grossMonthlyIncome - monthlyTax;

            IPayslipDetailResponse details = new PayslipDetailResponse()
            {
                GrossMonthlyIncome = Convert.ToDecimal( grossMonthlyIncome.ToString("0.##")),
                MonthlyIncomeTax = Convert.ToDecimal(monthlyTax.ToString("0.##")),
                NetMonthlyIncome = Convert.ToDecimal(netMonthlyIncome.ToString("0.##"))
            };

            return  details;
        }

        private decimal CalculatedGrossIncome(decimal income)
        {
            var result = income / MonthsInYear;
            return result;
        }

        private decimal CalculatedIncomeTax(decimal amount)
        {
            var result = TaxRate(amount);
            return result;
        }

        private decimal TaxRate(decimal salary)
        {
            decimal taxAmount = 0M;

            if (salary > 0 && salary <= 20000)
                taxAmount = 0;
            else if (salary > 20000 && salary <= 40000)
            {
                taxAmount = (((salary - 20000) * 0.1M) / MonthsInYear);
            }
            else if (salary >= 40001 && salary <= 80000)
            {

                taxAmount = (((20000 * 0M) + ((40000 - 20000) * 0.1M) + ((salary - 40000) * 0.2M)) / MonthsInYear);
            }
            else if (salary >= 80001 && salary <= 180000)
            {
                taxAmount = (((40000 - 20000) * 0.1M) + ((80000 - 40000) * 0.2M) + ((salary - 80000) * 0.3M)) / MonthsInYear;
            }
            else if (salary >= 180001)
            {
                taxAmount = (((20000 * 0M) + ((40000 - 20000) * 0.1M) + ((80000 - 40000) * 0.2M) + ((180000 - 80000) * 0.3M) + +((salary - 180000) * 0.4M))) / MonthsInYear;
            }
            return taxAmount;
        }
    }          
            
}
