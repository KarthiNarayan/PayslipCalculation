using Newtonsoft.Json;
using PayslipGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayslipGenerator.Domain
{
    public class PayslipDetailResponse : IPayslipDetailResponse
    {
        [JsonProperty(PropertyName = "grossMonthlyIncome")]
        public decimal GrossMonthlyIncome { get; set; }
        [JsonProperty(PropertyName = "monthlyIncomeTax")]
        public decimal MonthlyIncomeTax { get; set; }
        [JsonProperty(PropertyName = "netMonthlyIncome")]
        public decimal NetMonthlyIncome { get; set; }
    }
}
