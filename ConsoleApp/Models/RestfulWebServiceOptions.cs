namespace ConsoleApp.Models
{
    public class RestfulWebServiceOptions
    {
        private string baseUrl;
        public string BaseUrl
        {
            get { return baseUrl; }
            set
            {
                if (value.EndsWith("/"))
                    value = value.Substring(0, value.Length - 1);
                baseUrl = value;
            }
        }
    }
}
