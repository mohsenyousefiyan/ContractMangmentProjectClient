namespace ConsoleApp.Models
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ServiceResult<TData> : ServiceResult
    {
        public TData Result { get; set; }
    }
}
