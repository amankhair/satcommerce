using System.Collections.Generic;

namespace Sat.Server.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        #region Fields

        public IEnumerable<string> Errors { get; set; }

        #endregion

        public ApiValidationErrorResponse() : base(400)
        {

        }
    }
}
