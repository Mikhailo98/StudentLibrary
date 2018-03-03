using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DAL
{
    public interface IDataProvider
    {
        void Write(Object data, string connection);
        Object Read(Type t, string connection);
    }

    public class XMLDataProvider : IDataProvider
    {
        public object Read(Type t, string connection)
        {
            object data;
            using (FileStream fs = new FileStream(connection, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    data = formatter.Deserialize(fs);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return data;
        }

        public void Write(object data, string connection)
        {
            using (FileStream fs = new FileStream(connection, FileMode.OpenOrCreate))
            {
                //    XmlSerializer formatter = new XmlSerializer(data.GetType());
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, data);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
