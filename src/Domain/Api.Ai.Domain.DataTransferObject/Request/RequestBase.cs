using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Request
{
    public class RequestBase
    {
        #region Private Fields

        private string _v;

        #endregion

        #region Public Properties

        /// <summary>
        /// Version of the protocol, e.g. v=20150910
        /// </summary>
        public string V
        {
            get
            {
                if (string.IsNullOrEmpty(_v))
                {
                    _v = "20150910";
                }

                return _v;
            }
            set
            {
                _v = value;
            }
        }
    }

    #endregion

}
