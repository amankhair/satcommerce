namespace Sat.Server.Errors
{
    public class ApiException : ApiResponse
    {
        #region Fields

        public string Details { get; }

        #endregion

        #region Ctor

        public ApiException(int statusCode, string message = null, string details = null) 
            : base(statusCode, message)
        {
            Details = details;
        }

        #endregion
    }
}
