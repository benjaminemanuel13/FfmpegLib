using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ffmpeglibuser.CallbackFunctionality
{

    internal class CallbackUser
    {
        public delegate void CallbackDelegate(int a, int b);

        [DllImport("ffmpeglib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetData();

        [DllImport("ffmpeglib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCallback(CallbackDelegate aCallback);


        public delegate void ByteDelegate(IntPtr ptr, int size);

        [DllImport("ffmpeglib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetByteData();

        [DllImport("ffmpeglib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetByteCallback(ByteDelegate aCallback);

        public CallbackUser()
        { 
        }

        public void DoWork() 
        {
            CallbackDelegate lTD = new CallbackDelegate(MyCallback);

            SetCallback(lTD);
            GetData();

            ByteDelegate byteC = new ByteDelegate(ByteCallback);

            SetByteCallback(byteC);
            GetByteData();
        }

        public static void MyCallback(int a, int b)
        {
            //Do Something With Data From c Library
            Console.WriteLine("Data From c: " + a + ", " + b);
        }

        public static void ByteCallback(IntPtr ptr, int size)
        {
            byte[] data = new byte[size];
            Marshal.Copy(ptr, data, 0, size);

            Console.Write("Bytes: ");
            StringBuilder build = new StringBuilder();

            foreach (byte b in data)
            {
                build.Append(b.ToString() + ", ");
            }

            Console.WriteLine(build.ToString().Substring(0, build.Length - 1));
        }
    }
}
