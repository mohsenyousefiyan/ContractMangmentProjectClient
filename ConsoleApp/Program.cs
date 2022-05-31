using ConsoleApp.Models;
using ConsoleApp.Services;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var serverOption = new RestfulWebServiceOptions() { BaseUrl = "https://localhost:44358/api/" };
           
            ICompanyService companyService = new CompanyService(serverOption);
            IContractService contractService = new ContractService(serverOption);

            PrintCompanyList(companyService);
            PrintContractList(contractService);



            Console.ReadLine();
        }

        static void PrintCompanyList(ICompanyService companyService)
        {
            var serviceResult=companyService.GetCompanyList();

            if(serviceResult.IsSuccess)
            {
                foreach (var item in serviceResult.Result)             
                    Console.WriteLine($"Id: {item.CompanyId}  Subject:{item.Subject}");                
            }
        }
        static void PrintContractList(IContractService contractService )
        {
            var serviceResult = contractService.GetContractList();

            if (serviceResult.IsSuccess)
            {
                foreach (var item in serviceResult.Result)
                    Console.WriteLine($"Id: {item.ContractId}  PostCode:{item.PostCode}");
            }
        }

      
    }
}
