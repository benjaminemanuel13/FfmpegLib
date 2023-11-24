using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffmpeglibuser.Services.Interfaces
{
    internal interface IConversionService
    {
        bool ConvertAudioFile(string inFilename, string outFilename);
        bool ConvertVideoFile(string inFilename, string outFilename);
    }
}
