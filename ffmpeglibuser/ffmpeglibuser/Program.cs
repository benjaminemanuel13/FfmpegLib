
using ffmpeglibuser;
using ffmpeglibuser.CallbackFunctionality;
using ffmpeglibuser.Enumerations;
using ffmpeglibuser.Services;
using ffmpeglibuser.Services.Interfaces;

CallbackUser user = new CallbackUser();
user.DoWork();

IConversionService conversionService = new ConversionService();
bool audio = conversionService.ConvertAudioFile("in.wav", "out.mp3");
bool video = conversionService.ConvertVideoFile("in.wmv", "out.mp4");

if (!audio)
{
    Console.WriteLine("Failed To Convert Audio File.");
}

if (!video)
{
    Console.WriteLine("Failed To Convert Video File.");
}

Controller c = new Controller();
c.Capture(VideoFormat.Mp4);

Thread.Sleep(3000);

c.StopCapture();