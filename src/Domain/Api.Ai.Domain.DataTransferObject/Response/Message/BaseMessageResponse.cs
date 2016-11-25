using Api.Ai.Domain.DataTransferObject.Serializer.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response.Message
{
    [Serializable]
    public abstract class BaseMessageResponse
    {
        public Domain.Enum.Type Type { get; set; }
        
        public abstract void SetMessageType();

        #region Private Methods

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            SetMessageType();
        }

        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            SetMessageType();
        }

        #endregion        
    }
}
