using ConsoleApp.Helpers;
using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Services
{
    public interface IContractService
    {
        ServiceResult<List<Contract>> GetContractList();
        ServiceResult<Contract> GetContract(int id);
        ServiceResult CreateNewContract(Contract Contract);
        ServiceResult DeleteContract(int id);
        ServiceResult EditContract(Contract Contract);
    }
    public class ContractService: IContractService
    {
        private readonly RestfulWebServiceOptions serverOption;

        public ContractService(RestfulWebServiceOptions serverOption)
        {
            this.serverOption = serverOption;
        }

        public ServiceResult CreateNewContract(Contract Contract)
        {
            return RestFulHelper.CreatePostRequest($"{serverOption.BaseUrl}/Contract", Contract);
        }

        public ServiceResult DeleteContract(int id)
        {
            return RestFulHelper.CreateDeleteRequest($"{serverOption.BaseUrl}/Contract/{id}");
        }

        public ServiceResult EditContract(Contract Contract)
        {
            return RestFulHelper.CreatePutRequest($"{serverOption.BaseUrl}/Contract", Contract);
        }

        public ServiceResult<Contract> GetContract(int id)
        {
            return RestFulHelper.CreateGetRequest<Contract>($"{serverOption.BaseUrl}/Contract/{id}");
        }

        public ServiceResult<List<Contract>> GetContractList()
        {
            return RestFulHelper.CreateGetRequest<List<Contract>>($"{serverOption.BaseUrl}/Contract");
        }
    }
}
