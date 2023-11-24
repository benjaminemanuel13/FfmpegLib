using ffmpeglibuser.Enumerations;
using ffmpeglibuser.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffmpeglibuser.Services.Interfaces
{
    internal interface ICaptureService
    {
        event EventHandler<DataCapturedEventArgs> Captured;
        void StartCapturing(VideoFormat fmt);
        void StopCapturing();
    }
}
