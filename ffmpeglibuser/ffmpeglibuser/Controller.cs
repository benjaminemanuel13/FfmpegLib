using ffmpeglibuser.Enumerations;
using ffmpeglibuser.Services;
using ffmpeglibuser.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffmpeglibuser
{
    internal class Controller
    {
        ICaptureService captureService = new CaptureService();

        public void Capture(VideoFormat fmt)
        {
            captureService.Captured += CaptureService_Captured;
            captureService.StartCapturing(fmt);
        }

        private void CaptureService_Captured(object? sender, EventArguments.DataCapturedEventArgs e)
        {
            
        }

        public void StopCapture()
        {
            captureService.StopCapturing();
        }
    }
}
