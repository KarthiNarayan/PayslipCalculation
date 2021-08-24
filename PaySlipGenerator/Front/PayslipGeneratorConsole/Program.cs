using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                        //var client = new RestClient("https://localhost:44310/PayslipGenerator/Mark/60000");
                        //var request = new RestRequest(Method.GET);
                        //request.AddHeader("postman-token", "d2892d51-4d93-825c-49ab-4096888c4ebf");
                        //request.AddHeader("cache-control", "no-cache");
                        //IRestResponse response = client.Execute(request);

                       


                        var client = new RestClient("https://localhost:44310/PayslipGenerator/Mark/80000");

                        var request = new RestRequest(Method.GET);
                    
                        //request.AddHeader("postman-token", "2e808013-cc55-dbb8-fb10-9ffc19540fb8");
                        //request.AddHeader("cache-control", "no-cache");
                        IRestResponse response = client.Get(request);
                        if (!string.IsNullOrEmpty(response.ErrorMessage))
                        {
                            Console.WriteLine(response.ErrorMessage);
                            cmd = false;
                        }
                        else
                            Console.WriteLine(response.Content);


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






