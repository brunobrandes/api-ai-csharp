using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.Enum
{
    /// <summary>
    /// Message query response type.
    /// </summary>
    public enum Type
    {
        Text = 0,
        Card = 1,
        QuickReply = 2,
        Image = 3,
        Payload = 4
    }
}
