namespace API.Errors
{
    public class APIException
    {
        public APIException(int statusCode, string massage = null, string details = null)
        {
            StatusCode = statusCode;
            Massage = massage;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string Massage { get; set; }
        public string Details { get; set; }
    }
}