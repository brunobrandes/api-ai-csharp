using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.Service.Exceptions
{
    public class ApiAiException : Exception
    {
        #region Public Properties

        public HttpStatusCode Code { get; set; }

        #endregion

        #region Constructor
        
        public ApiAiException(string message) :
            base(message)
        {
            this.Code = HttpStatusCode.InternalServerError;
        }

        public ApiAiException(HttpStatusCode code, string message) :
            base(message)
        {
            this.Code = code;
        }

        public ApiAiException(int code, string message) :
            base(message)
        {
            this.Code = (HttpStatusCode)code;
        }

        #endregion
    }
}
