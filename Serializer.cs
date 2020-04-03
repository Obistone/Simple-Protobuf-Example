using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Serializer
{
    public static class Serializer
    {
        /// <summary>
        /// Serializes your <paramref name="type"/> of choice.
        /// </summary>
        /// <param name="type">The packet to serialize.</param>
        /// <returns>null if there's an exception, otherwise the bytes of your packet.</returns>
        public static byte[] Serialize(YourType type)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(stream, type);
                    return stream.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializes bytes into an <see cref="YourType"/>.
        /// </summary>
        /// <param name="data">The bytes to deserialize.</param>
        /// <returns>null if there's an exception.</returns>
        public static YourType Deserialize(byte[] data)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(data))
                {
                    return ProtoBuf.Serializer.Deserialize<YourType>(stream);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
