using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Request
{
    public class LocationRequest
    {
        #region Public Properties

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        #endregion

    }
}
