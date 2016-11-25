using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Source
    {
        [EnumMember(Value = "facebook")]
        Facebook = 0,

        [EnumMember(Value = "kik")]
        Kik = 1,

        [EnumMember(Value = "slack")]
        Slack = 2,

        [EnumMember(Value = "slack_testbot")]
        SlackTestbot = 3,

        [EnumMember(Value = "line")]
        Line = 4,

        [EnumMember(Value = "skype")]
        Skype = 5,

        [EnumMember(Value = "spark")]
        Spark = 6,

        [EnumMember(Value = "telegram")]
        Telegram = 7,

        [EnumMember(Value = "tropo")]
        Tropo = 8,

        [EnumMember(Value = "twilio")]
        Twilio = 9,

        [EnumMember(Value = "twilio-ip")]
        TwilioIp = 10,

        [EnumMember(Value = "twitter")]
        Twitter = 11
    }
}
