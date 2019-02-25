using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace CineNetEntity.Helpers
{    
    /// <summary>
    /// La clase SerializationHelper tiene por objetivo asistir en la serializacion de objetos
    /// </summary>
    public static class SerializationHelper
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

        public static string ToAbsoluteUrl(this string relativeUrl) //Use absolute URL instead of adding phycal path for CSS, JS and Images     
        {
            if (string.IsNullOrEmpty(relativeUrl)) return relativeUrl;
            if (HttpContext.Current == null) return relativeUrl;
            if (relativeUrl.StartsWith("/")) relativeUrl = relativeUrl.Insert(0, "~");
            if (!relativeUrl.StartsWith("~/")) relativeUrl = relativeUrl.Insert(0, "~/");
            var url = HttpContext.Current.Request.Url;
            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;
            return String.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        }
        public static string GeneratePassword(int length) //length of salt    
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[length];
            var allowedCharCount = allowedChars.Length;
            for (var i = 0; i <= length - 1; i++)
            {
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public static string EncodePassword(string pass, string salt) //encrypt password    
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            //return Convert.ToBase64String(inArray);    
            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
        public static string EncodePasswordMd5(string pass) //Encrypt using MD5    
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)    
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string    
            return BitConverter.ToString(encodedBytes);
        }
        public static string base64Encode(string sData) // Encode    
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
    }
}