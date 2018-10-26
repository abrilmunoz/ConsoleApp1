using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MunozAbrilSerialization
{
    [Serializable()]
    //This is my Student class.
    class BinaryFormatterStudent : ISerializable
    {
        public int StudentId;
        public string StudentName;

        public BinaryFormatterStudent()
        {
            StudentId = 0;
            StudentName = null;
        }

        public BinaryFormatterStudent(SerializationInfo info, StreamingContext ctxt)
        {
            StudentId = (int)info.GetValue("StudentID", typeof(int));
            StudentName = (string)info.GetValue("StudentName", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("StudentID", StudentId);
            info.AddValue("StudentName", StudentName);
        }
    }
}
