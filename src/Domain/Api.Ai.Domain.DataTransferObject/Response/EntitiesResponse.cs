using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response
{
    public class EntityResponse
    {
        #region Public Properties

        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Preview { get; set; }

        #endregion
    }
}
