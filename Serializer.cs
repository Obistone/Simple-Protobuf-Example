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
        /// <param name="type">The type to serialize.</param>
        /// <returns>null if there's an exception, otherwise the bytes of your packet.</returns>
        public static byte[] Serialize<T>(T type)
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
        /// Deserializes bytes into your type of choice.
        /// </summary>
        /// <param name="data">The bytes to deserialize.</param>
        /// <returns>null if there's an exception.</returns>
        public static T Deserialize<T>(byte[] data)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(data))
                {
                    return ProtoBuf.Serializer.Deserialize<T>(stream);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
