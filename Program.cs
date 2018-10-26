using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MunozAbrilSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the Principal part of the code.
            DataContractSerializer Principal = new DataContractSerializer();
            Principal.Name = "Matthews";
            Principal.Email = "Matthews@school.org";

            Stream stream = File.Open("SchoolInfo.txt", FileMode.Create);
            BinaryFormatter data = new BinaryFormatter();

            data.Serialize(stream, Principal);
            stream.Close();

            stream = File.Open("SchoolInfo.txt", FileMode.Open);
            data = new BinaryFormatter();

            Principal = (DataContractSerializer)data.Deserialize(stream);
            stream.Close();

            Console.WriteLine("Principal: {0}", Principal.Name);
            Console.WriteLine("Principal Email: {0}", Principal.Email);
            Console.WriteLine("");

            //This is the Student part of the code.
            //Student 1:
            BinaryFormatterStudent student1 = new BinaryFormatterStudent();
            student1.StudentName = "Amy";
            student1.StudentId = 5555;

            stream = File.Open("SchoolInfo.txt", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();

            bformatter.Serialize(stream, student1);
            stream.Close();

            stream = File.Open("SchoolInfo.txt", FileMode.Open);
            bformatter = new BinaryFormatter();
            
            student1 = (BinaryFormatterStudent)bformatter.Deserialize(stream);
            stream.Close();

            Console.WriteLine("Student Name: {0}", student1.StudentName);
            Console.WriteLine("Student ID: {0}", student1.StudentId);

            //Student 2:
            BinaryFormatterStudent student2 = new BinaryFormatterStudent();
            student2.StudentName = "Cody";
            student2.StudentId = 4444;

            stream = File.Open("SchoolInfo.txt", FileMode.Create);
            bformatter = new BinaryFormatter();

            bformatter.Serialize(stream, student2);
            stream.Close();

            stream = File.Open("SchoolInfo.txt", FileMode.Open);
            bformatter = new BinaryFormatter();

            student2 = (BinaryFormatterStudent)bformatter.Deserialize(stream);
            stream.Close();

            Console.WriteLine("Student Name: {0}", student2.StudentName);
            Console.WriteLine("Student ID: {0}", student2.StudentId);
            Console.WriteLine("");

            //This is the School part of the code.
            const string filePath = "SchoolInfo.txt";

            void Serialize(object obj)
            {
                var serializer = new JsonSerializer();

                using (var sw = new StreamWriter(filePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, obj);
                }
            }

            object Deserialize(string path)
            {
                var serializer = new JsonSerializer();

                using (var sw = new StreamReader(path))
                using (var reader = new JsonTextReader(sw))
                {
                    return serializer.Deserialize(reader);
                }
            }

            NewtonsoftJSON School = new NewtonsoftJSON();
            School.Principal = Principal.Name;
            School.Student = new List<string> {student1.StudentName, student2.StudentName};

            Console.WriteLine("Object before serialization:");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            School.Print();

            Serialize(School);

            var deserialized = Deserialize(filePath);

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);
        }
    }
}
