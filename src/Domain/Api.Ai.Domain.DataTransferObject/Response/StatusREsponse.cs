using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response
{
    public class StatusResponse
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Text description of error, or "success" if no error.
        /// </summary>
        public string ErrorType { get; set; }

        /// <summary>
        /// D of the error. Optionally returned if the request failed.
        /// </summary>
        public string ErrorId { get; set; }

        /// <summary>
        /// Text details of the error. Only returned if the request failed.
        /// </summary>
        public string ErrorDetails { get; set; }
    }
}
