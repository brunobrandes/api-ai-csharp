using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.Enum
{
    public enum RequestType
    {
        Query = 0,
        Tts = 1,
        Entities = 2,
        UserEntities = 3,
        Intents = 4
    }
}
