using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunozAbrilSerialization
{
    class DataContractSerializerTest
    {
        Stream stream = File.Open("SchoolInfo.txt", FileMode.Create);
        DataContractSerializer bformatter = new DataContractSerializer();
    }
}
