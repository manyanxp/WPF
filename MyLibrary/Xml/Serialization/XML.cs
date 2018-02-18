using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace MyLibrary.Xml.Serialization
{
    public class XML
    {
        /// <summary>
        /// XMLファイルの書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="xml"></param>
        public static void WriteXmlFile<T>(string path, T xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, xml);
            }
        }
        
        /// <summary>
        /// XMLファイルの読み込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T ReadXmlFile<T>(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            T returnVal;

            using (var fs = new FileStream(path, FileMode.Open))
            {
                returnVal = (T)xmlSerializer.Deserialize(fs);
            }
            return returnVal;
        }
    }
}
