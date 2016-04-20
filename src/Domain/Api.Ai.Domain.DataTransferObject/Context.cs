using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject
{
    public class Context
    {
        public string Name { get; set; }
        
        public Dictionary<string, string> Parameters { get; set; }
        
        public int? Lifespan { get; set; }
    }
}
