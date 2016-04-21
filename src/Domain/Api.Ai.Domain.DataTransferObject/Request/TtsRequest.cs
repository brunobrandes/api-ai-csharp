using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Request
{
    /// <summary>
    /// The tts endpoint is used to perform text-to-speech - generate speech (audio file) from text.
    /// </summary>
    public class TtsRequest : RequestBase
    {
        #region Public Properties

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }

        #endregion
    }
}
