using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MunozAbrilSerialization
{
    //This is my School Class.
    class NewtonsoftJSON
    {
        public string Principal;
        public List<string> Student;
        public void Print()
        {
            Console.WriteLine("Principal: " + Principal);
            Console.WriteLine("Students: " + string.Join<string>(",", Student));
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void SerializeStudent(object obj)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("SchoolInfo.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static object DeserializeStudent(string path)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamReader(path))
            using (var reader = new JsonTextReader(sw))
            {
                return serializer.Deserialize(reader);
            }
        }
    }
}
