using ffmpeglibuser.Enumerations;
using ffmpeglibuser.EventArguments;
using ffmpeglibuser.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ffmpeglibuser.Services
{
    internal class CaptureService : ICaptureService
    {
        public delegate void CaptureDelegate(IntPtr ptr, int size, ByteDataTypes type);

        [DllImport("ffmpeglib", EntryPoint = "setcapturecallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetCaptureCallback(CaptureDelegate aCallback);

        [DllImport("ffmpeglib", EntryPoint = "freecapturecallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FreeCaptureCallback();

        [DllImport("ffmpeglib", EntryPoint = "startcapture", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StartCapture(int fmt);

        [DllImport("ffmpeglib", EntryPoint = "stopcapture", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StopCapture();

        public event EventHandler<DataCapturedEventArgs> Captured;

        public void CaptureCallback(IntPtr ptr, int size, ByteDataTypes type)
        {
            //Do something with Captured Bytes
            byte[] data = new byte[size];
            Marshal.Copy(ptr, data, 0, size);

            Captured?.Invoke(this, new DataCapturedEventArgs(data, type));
        }

        public void StartCapturing(VideoFormat fmt)
        {
            CaptureDelegate capD = new CaptureDelegate(CaptureCallback);

            SetCaptureCallback(capD);

            StartCapture((int)fmt);
        }

        public void StopCapturing()
        {
            StopCapture();

            FreeCaptureCallback();
        }
    }
}
