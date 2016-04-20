using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Language
    {
        [EnumMember(Value = "en")]
        English = 0,

        [EnumMember(Value = "pt-br")]
        BrazilianPortuguese = 1,

        [EnumMember(Value = "zh-hk")]
        ChineseCantonese = 2,

        [EnumMember(Value = "zh-cn")]
        ChineseSimplified = 3,

        [EnumMember(Value = "zh-tw")]
        ChineseTraditional = 4,

        [EnumMember(Value = "nl")]
        Dutch = 5,

        [EnumMember(Value = "fr")]
        French = 6,

        [EnumMember(Value = "de")]
        German = 7,

        [EnumMember(Value = "it")]
        Italian = 8,

        [EnumMember(Value = "ja")]
        Japanese = 9,

        [EnumMember(Value = "ko")]
        Korean = 10,

        [EnumMember(Value = "pt")]
        Portuguese = 11,

        [EnumMember(Value = "ru")]
        Russian = 12,

        [EnumMember(Value = "es")]
        Spanish = 13,

        [EnumMember(Value = "uk")]
        Ukrainian = 14
    }
}
