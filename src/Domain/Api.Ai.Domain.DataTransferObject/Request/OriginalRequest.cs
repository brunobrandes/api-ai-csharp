using Api.Ai.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Request
{
    public class OriginalRequest
    {
        /// <summary>
        /// Request source name. 
        /// Possible values: "facebook", "kik", "slack", "slack_testbot", "line", 
        /// "skype", "spark", "telegram", "tropo", "twilio", "twilio-ip", "twitter"
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// Request data.
        /// </summary>
        public object Data { get; set; }
    }
}
