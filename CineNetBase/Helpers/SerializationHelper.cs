using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CineNetBase.Helpers
{    
    /// <summary>
    /// La clase SerializationHelper tiene por objetivo asistir en la serializacion de objetos
    /// </summary>
    public class SerializationHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToXmlString(object obj)
        {
            XmlSerializer xmlSer = new XmlSerializer(obj.GetType());
            StringWriter stringWriter = new StringWriter();
            xmlSer.Serialize(stringWriter, obj);
            return stringWriter.GetStringBuilder().ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeFromXmlString(string str, Type type)
        {
            XmlSerializer xmlSer = new XmlSerializer(type);
            StringReader stringReader = new StringReader(str);
            object obj = xmlSer.Deserialize(stringReader);
            return obj;
        }

        /// <summary>
        /// Serializa a binario el objeto recibido y se retorna un string del mismo.
        /// </summary>
        /// <param name="obj">Objeto a serialzar</param>
        /// <returns>String del objeto serializado en binario</returns>
        public static string SerializeToBinaryString(object obj)
        {
            if (Object.Equals(obj, null))
            {
                return (null);
            }

            MemoryStream ms = new MemoryStream();
            new BinaryFormatter().Serialize(ms, obj);
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// Se deserializa el string 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static object DeserializeFromBinaryString(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);
            BinaryFormatter formatter = new BinaryFormatter();
            object objectInstance = formatter.Deserialize(ms);
            return (objectInstance);
        }
    }
}