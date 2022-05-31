using ConsoleApp.Helpers;
using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Services
{
    public interface ICompanyService
    {
        ServiceResult<List<Company>> GetCompanyList();
        ServiceResult<Company> GetCompany(int id);
        ServiceResult CreateNewCompany(Company company);
        ServiceResult DeleteCompany(int id);    
        ServiceResult EditCompany(Company company);
    }
    public class CompanyService: ICompanyService
    {
        private readonly RestfulWebServiceOptions serverOption;

        public CompanyService(RestfulWebServiceOptions serverOption)
        {
            this.serverOption = serverOption;
        }

        public ServiceResult CreateNewCompany(Company company)
        {
            return RestFulHelper.CreatePostRequest($"{serverOption.BaseUrl}/company",company);
        }

        public ServiceResult DeleteCompany(int id)
        {
            return RestFulHelper.CreateDeleteRequest($"{serverOption.BaseUrl}/company/{id}");
        }

        public ServiceResult EditCompany(Company company)
        {
            return RestFulHelper.CreatePutRequest($"{serverOption.BaseUrl}/company", company);
        }

        public ServiceResult<Company> GetCompany(int id)
        {
            return RestFulHelper.CreateGetRequest<Company>($"{serverOption.BaseUrl}/company/{id}");
        }

        public ServiceResult<List<Company>> GetCompanyList()
        {
            return  RestFulHelper.CreateGetRequest<List<Company>>($"{serverOption.BaseUrl}/company");
        }
    }
}
