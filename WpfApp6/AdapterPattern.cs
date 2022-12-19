using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Model;
using Newtonsoft.Json;
using static WpfApp6.AdapterPattern;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Shapes;

namespace WpfApp6
{
    public class AdapterPattern
    {
        public interface IAdapter
        {
            void Write(Person person);
            void Read();
        }

        public class JsonAdapter : IAdapter
        {
            private Json _json;
          

            public JsonAdapter(Json json)
            {
                _json = json;
            }

            

            public void Read()
            {
                _json.JsonRead();
            }

            public void Write(Person person)
            {
                _json.JsonWrite(person);
            }
        }

        public class XmlAdapter : IAdapter
        {
            private Xml _xml;

            public XmlAdapter(Xml xml)
            {
                _xml = xml;
            }

            public void Read()
            {
                _xml.XmlRead();
            }

            public void Write(Person person)
            {
                _xml.XmlWriter(person);
            }
        }

        public class Json
        {
            public void JsonWrite(Person person)
            {
                var serializer = new JsonSerializer();

                using (StreamWriter sw = new StreamWriter("person.json"))
                {
                    using (var writer = new JsonTextWriter(sw))
                    {
                        
                        serializer.Serialize(writer, person);
                    }
                }
            }

            public Person JsonRead()
            {
                Person person=null ;
                var serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader("person.json"))
                {
                    using (var read = new JsonTextReader(sr))
                    {
                        person = serializer.Deserialize<Person>(read);
                    }
                }
                return person;
            }
        }
    }

        public class Xml
        {
        public void XmlWriter(Person person)
        {

            var serializer = new XmlSerializer(typeof(Person));
            using (var writer = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(writer, person);
            }
        }

        
        public void XmlRead()
        {
            Person person ;
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (XmlReader read = XmlReader.Create("person.xml"))
            {
                person = serializer.Deserialize(read) as Person;
            }
        }
    }
   

class Converter
        {
            private readonly IAdapter _adapter;

            public Converter(IAdapter adapter)
            {
                _adapter = adapter;
            }

        public void Write(Person person)
        {
            _adapter.Write(person);
        }

        public void Read()
        {
            _adapter.Read();
        }

    }
  }


   





