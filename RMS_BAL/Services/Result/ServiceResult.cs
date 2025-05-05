namespace RMS_BAL.Services.Result
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; internal set; }
        public string Error { get; internal set; }
    }
}