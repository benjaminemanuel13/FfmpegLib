using ffmpeglibuser.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffmpeglibuser.EventArguments
{
    internal class DataCapturedEventArgs : EventArgs
    {
        ByteDataTypes DataType { get; set; }
        public byte[] Data { get; set; }

        public DataCapturedEventArgs(byte[] data, ByteDataTypes type)
        {
            DataType = type;
            Data = data;
        }
    }
}
