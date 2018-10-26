using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MunozAbrilSerialization
{
    class BinaryFormatterTest
    {
        Stream stream = File.Open("SchoolInfo.txt", FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
    }
}
