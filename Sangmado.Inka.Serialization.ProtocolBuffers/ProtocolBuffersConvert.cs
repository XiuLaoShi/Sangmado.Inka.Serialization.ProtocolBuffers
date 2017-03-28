﻿using System.IO;

namespace Sangmado.Inka.Serialization.ProtocolBuffers
{
    public static class ProtocolBuffersConvert
    {
        public static byte[] SerializeObject(object obj)
        {
            byte[] data;
            using (var stream = new MemoryStream())
            {
                ProtoBuf.Serializer.NonGeneric.Serialize(stream, obj);
                data = stream.ToArray();
            }

            return data;
        }

        public static byte[] SerializeObject<T>(T obj)
        {
            byte[] data;
            using (var stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<T>(stream, obj);
                data = stream.ToArray();
            }

            return data;
        }

        public static T DeserializeObject<T>(byte[] data)
        {
            return DeserializeObject<T>(data, 0, data.Length);
        }

        public static T DeserializeObject<T>(byte[] data, int dataOffset, int dataLength)
        {
            T obj = default(T);
            using (var stream = new MemoryStream(data, dataOffset, dataLength))
            {
                obj = ProtoBuf.Serializer.Deserialize<T>(stream);
            }

            return obj;
        }
    }
}
