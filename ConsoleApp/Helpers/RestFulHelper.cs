using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp.Helpers
{
    public class RestFulHelper
    {
        public static ServiceResult<T> CreateGetRequest<T>(string url, Dictionary<string, string> parameters = null, Dictionary<string, string> HeaderItems = null)
        {
            try
            {
                ServiceResult<T> ReturnResult = new ServiceResult<T>();


                using (HttpClient httpClient = new HttpClient())
                {
                    if (HeaderItems != null && HeaderItems.Count > 0)
                    {
                        foreach (var item in HeaderItems)
                            httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }

                    var requestUrl = url + GenerateQueryString(parameters);
                    HttpResponseMessage result =  httpClient.GetAsync(requestUrl).Result;

                   
                   if (!result.IsSuccessStatusCode)
                        return new ServiceResult<T>() { IsSuccess=false,ErrorMessage=result.StatusCode.ToString()};
                  

                    var resultContent =  result.Content.ReadAsStringAsync().Result;
                    var data = SerializerHelper.DeSerialize<T>(resultContent);
                    return new ServiceResult<T>() { IsSuccess = true, Result = data };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<T>() {IsSuccess=false, ErrorMessage = ex.Message };
            }
        }

        public static ServiceResult CreateDeleteRequest(string url, Dictionary<string, string> parameters = null, Dictionary<string, string> HeaderItems = null)
        {
            try
            {
                ServiceResult ReturnResult = new ServiceResult();


                using (HttpClient httpClient = new HttpClient())
                {
                    if (HeaderItems != null && HeaderItems.Count > 0)
                    {
                        foreach (var item in HeaderItems)
                            httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }

                    var requestUrl = url + GenerateQueryString(parameters);
                    HttpResponseMessage result = httpClient.DeleteAsync(requestUrl).Result;

                    return new ServiceResult() { IsSuccess = result.IsSuccessStatusCode, ErrorMessage = result.StatusCode.ToString() };

                }
            }
            catch (Exception ex)
            {
                return new ServiceResult() { IsSuccess = false, ErrorMessage = ex.Message };
            }
        }

        public static  ServiceResult CreatePostRequest(string url, object Params, Dictionary<string, string> HeaderItems = null)
        {
            try
            {
                ServiceResult ReturnResult = new ServiceResult();

                var input = SerializerHelper.SerializeObject(Params);


                using (HttpClient httpClient = new HttpClient())
                {
                    var content = new StringContent(input, Encoding.UTF8, "application/json");

                    if (HeaderItems != null && HeaderItems.Count > 0)
                    {
                        foreach (var item in HeaderItems)
                            httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }

                    var result =  httpClient.PostAsync(url, content).Result;

                    return new ServiceResult() { IsSuccess = result.IsSuccessStatusCode, ErrorMessage = result.StatusCode.ToString() };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult() { IsSuccess = false, ErrorMessage = ex.Message };
            }
        }

        public static ServiceResult CreatePutRequest(string url, object Params, Dictionary<string, string> HeaderItems = null)
        {
            try
            {
                ServiceResult ReturnResult = new ServiceResult();

                var input = SerializerHelper.SerializeObject(Params);


                using (HttpClient httpClient = new HttpClient())
                {
                    var content = new StringContent(input, Encoding.UTF8, "application/json");

                    if (HeaderItems != null && HeaderItems.Count > 0)
                    {
                        foreach (var item in HeaderItems)
                            httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }

                    var result = httpClient.PutAsync(url, content).Result;

                    return new ServiceResult() { IsSuccess = result.IsSuccessStatusCode, ErrorMessage = result.StatusCode.ToString() };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult() { IsSuccess = false, ErrorMessage = ex.Message };
            }
        }

        private static string GenerateQueryString(Dictionary<string, string> parameters)
        {
            string queryString = "";

            if (parameters != null && parameters.Count > 0)
            {
                queryString = "?";
                foreach (var item in parameters)
                {
                    if (StringHelper.HasValue(item.Key) && StringHelper.HasValue(item.Value))
                        queryString += $"{item.Key}={HttpUtility.UrlEncode(item.Value)}&";
                }

                if (queryString.EndsWith("&") || queryString.EndsWith("?"))
                    queryString = queryString.Substring(0, queryString.Length - 1);
            }

            return queryString;
        }
    }
}
