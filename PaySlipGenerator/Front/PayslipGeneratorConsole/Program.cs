using Newtonsoft.Json;
using PayslipGenerator.Domain;
using PayslipGenerator.Interfaces;
using RestSharp;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace PayslipGeneratorConsole
{
    class Program
    {
        static async Task RunAsync()
        {
            string empName = string.Empty;
            decimal annualSalary = 0M;

            bool cmd = false;
            Console.WriteLine("Enter STOP to exit... ");


            do
            {
                Console.Write("Enter the Input (Employee Name,Annual salary): ");
                var val = Console.ReadLine();

                if (val == null)
                    continue;
                else if (val.Equals("STOP"))
                {
                    cmd = true;
                }

                if (!val.Contains(","))
                {
                    Console.WriteLine("Not a valid input. Please try again.");
                    continue;
                }
                else
                {
                    if (!Decimal.TryParse(val.Split(',')[1], out annualSalary))
                    {
                        Console.WriteLine("Invalid Salary");
                        continue;
                    }
                    empName = val.Split(',')[0].ToString();
                    annualSalary = Convert.ToDecimal(val.Split(',')[1]);

                }
                if (string.IsNullOrEmpty(empName) || annualSalary <= 0)
                {
                    Console.WriteLine("Not a valid input. Please try again.");
                   continue;
                }

                else
                {
                    try
                    {
                        string baseUrl = ConfigurationManager.AppSettings["url"].ToString();
                       
                        var client = new RestClient(baseUrl + empName +"/"+annualSalary);

                        var request = new RestRequest(Method.GET);                 
                       //get the response
                        IRestResponse response = client.Get(request);
                        if (!string.IsNullOrEmpty(response.ErrorMessage))
                        {
                            Console.WriteLine(response.ErrorMessage);
                            cmd = false;
                        }
                        else
                        {                           

                            var details = JsonConvert.DeserializeObject<PayslipDetailResponse>(response.Content);
                            //Write the output 
                            Console.WriteLine($"Gross Monthly Income: { details.GrossMonthlyIncome}");
                            Console.WriteLine($"Monthly Income Tax: { details.MonthlyIncomeTax}");
                            Console.WriteLine($"Net Monthly Income: { details.NetMonthlyIncome}");
                        }

                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!cmd);


        }
    

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }
            
    }

}






