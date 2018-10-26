using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MunozAbrilSerialization
{
    [Serializable()]
    //This is my Principal class.
    class DataContractSerializer : ISerializable
    {
        public string Name;
        public string Email;

        public DataContractSerializer()
        {
            Name = null;
            Email = null;
        }

        public DataContractSerializer(SerializationInfo info, StreamingContext ctxt)
        {
            Name = (string)info.GetValue("PrincipalName", typeof(string));
            Email = (string)info.GetValue("PrincipalEmail", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("PrincipalName", Name);
            info.AddValue("PrincipalEmail", Email);
        }
    }
}
