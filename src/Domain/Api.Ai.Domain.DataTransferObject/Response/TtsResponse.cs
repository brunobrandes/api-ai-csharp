using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response
{
    public class TtsResponse : IDisposable
    {
        #region Private Fields

        private readonly byte[] _bytes;
        private readonly Stream _stream;

        #endregion

        #region Contructor

        public TtsResponse(Stream stream)
        {
            if (stream != null && stream.Length > 0)
            {
                _stream = stream;
                _bytes = ReadFully(stream);
            }

        }

        #endregion

        #region Public Properties

        public byte[] Bytes { get { return _bytes; } }

        public Stream Stream { get { return _stream; } }

        #endregion

        #region Private Methods

        private byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[stream.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create a file.
        /// </summary>
        /// <param name="path">Path not include filne name.</param>
        /// <returns>File name</returns>
        public async Task<string> WriteToFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (_bytes != null && _bytes.Count() > 0)
                {
                    var fileName = $"{Guid.NewGuid().ToString()}.wav";

                    using (FileStream fileStream = new FileStream($"{path}\\{fileName}", FileMode.Create))
                    {
                        await fileStream.WriteAsync(_bytes, 0, _bytes.Length);
                        return fileName;
                    }
                }
                else
                {
                    throw new Exception("Write to file error - Byte array is empty.");
                }
            }
            else
            {
                throw new Exception("Write to file error - Path is null or empty.");
            }

        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
