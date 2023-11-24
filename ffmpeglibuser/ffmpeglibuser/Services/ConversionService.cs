using ffmpeglibuser.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ffmpeglibuser.Services
{
    internal class ConversionService : IConversionService
    {
        [DllImport("ffmpeglib", EntryPoint = "audioconvert", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AudioConvert(string infilename, string outfilename);

        [DllImport("ffmpeglib", EntryPoint = "videoconvert", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VideoConvert(string infilename, string outfilename);

        public bool ConvertAudioFile(string inFilename, string outFilename)
        {
            int ret = AudioConvert(inFilename, outFilename);

            return ret >= 0;
        }

        public bool ConvertVideoFile(string inFilename, string outFilename)
        {
            int ret = AudioConvert(inFilename, outFilename);

            return ret >= 0;
        }
    }
}
