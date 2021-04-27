using System;
using System.IO;
using System.Xml.Serialization;

namespace AlexSpace
{
    public sealed class SerializableIXMLData<T> : IData<T>
    {
        private static XmlSerializer _formatter;

        public SerializableIXMLData()
        {
            _formatter = new XmlSerializer(typeof(T));
        }

        public void Save(T data, string path = null)
        {
            if (data == null && !String.IsNullOrEmpty(path)) return;
            using (var fs = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(fs, data);
            }
        }

        public T Load(string path)
        {
            T result;
            if (!File.Exists(path)) return default(T);

            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = (T)_formatter.Deserialize(fs);
            }
            return result;
        }
    }
}