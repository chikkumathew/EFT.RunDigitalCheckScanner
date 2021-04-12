using System;
using System.IO;
using System.Reflection;

namespace EFT.RunDigitalCheckScanner.Common
{
    public class Constants
    {
        public static string ImageLocation = Path.GetTempPath() + "Images";
        //public static string ScannerINIPath = Path.GetDirectoryName(Assembly.GetAssembly().Location) + "\\BUICSCAN.INI";
    }
}
