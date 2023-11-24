//Audio / Video Conversion
extern __declspec(dllexport) int audioconvert(char* infilename, char* outfilename);
extern __declspec(dllexport) int videoconvert(char* infilename, char* outfilename);

//Video and Audio Capture To File
extern __declspec(dllexport) int startfilecapture(char* filename);
extern __declspec(dllexport) int stopfilecapture();


typedef void (*data_callback)(char*, int, int);
//Video and Audio Capture To Callback
extern __declspec(dllexport) int setcapturecallback(data_callback aCallback);
extern __declspec(dllexport) int freecapturecallback();
//ftm 1= Mp4, 2= Wmv
extern __declspec(dllexport) int startcapture(int fmt);
extern __declspec(dllexport) int stopcapture();
void ProcessCapturedBytes();

//Audio Only Capture To File
extern __declspec(dllexport) int startcaptureaudio(char* filename);
extern __declspec(dllexport) int stopcaptureaudio();

//Video Only Capture To File
extern __declspec(dllexport) int startcapturevideo(char* filename);
extern __declspec(dllexport) int stopcapturevideo();




//Ready For Callbacks
typedef void (*callback_function)(int, int);
extern __declspec(dllexport) void SetCallback(callback_function aCallback);
extern __declspec(dllexport) void GetData();

typedef void (*bytes_callback)(char*, int);
//Byte Callback
extern __declspec(dllexport) void SetByteCallback(bytes_callback aCallback);
extern __declspec(dllexport) void GetByteData();