using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace EFT.RunDigitalCheckScanner.Services
{
    public class RegisterScannerOperations
    {
        public const int CFG_INIPATH = 135;
        static public string mstrPath = String.Empty;
        static public string localTempPath = String.Empty;
        public const int CFG_RO_DF_SENSOR_TRIGGERED = 245;

        [DllImport("BUICAP32.DLL")]
        extern public static int BUICStartImageWindow(int hWnd, int iWindow);

        [DllImport("BUICAP32.DLL")]
        extern public static int BUICSetParamString(int iParameter, string sString);

        [DllImport("BUICAP32.DLL")]
        extern public static int BUICInit();

        [DllImport("BUICAP32.DLL")]
        public static extern int DCCScan(string pszFrontTiff, string pszBackTiff, string pszFrontJPEG, string pszBackJPEG, StringBuilder pszMICR, ref int piFinalImageQuality, ref int piFinalContrast, ref typDocStatus piDocStatus);

        [DllImport("BUICAP32.DLL")]
        extern public static int BUICScan(int iJob, string lpFront, string strFLen, string lpBack, string strBLen, string LpCode, string LpLen); // 02-18-97


        [DllImport("BUICAP32.DLL")]
        extern public static int BUICGetParam(int iParam);
        static public bool DirExists(string sPath)
        {
            try
            {
                Object fso = new Object();
            }
            catch
            {
            }
            return Directory.Exists(sPath);
        }

        // Doc status type
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct typDocStatus
        { //array OF 32 bytes (Long = 4 bytes each, 2 items are reserved for 20 bytes)
            public int MaxEdgeCrop;
            public int SpecklesRemoved;
            public int StandardCkSize;
            public int Skew;
            public int BentLeftTopPix;
            public int BentRightTopPix;
            public int BentLeftBottomPix;
            public int BentRightBottomPix;
            public int FirstSolidLine;
            public int MICRQualityStatus;
            public int PctBlackBits;
            public int CompressedImgSize;
            public int CARPresent;
            public int LARPresent;
            public int PayeePresent;
            public int DatePresent;
            public int SignaturePresent;
            public int MemoPresent;
            public int BLOBPresent;
            public int CarbonPresent;
            public int StreakStatus;
            public int GrayScaleContrast;
            public int ImageFocus;
            public int DocSizeInTenths; //23-Document Size in 10th of inches so a width to 6.2 inches would be 62.  The Width is multiplied by 256 and added to the height.  Example: an image 6.0 by 2.7 would be 60 * 256 + 27 or 15387
            public int DPI; //Pixels per inch
            public int SkewIn10thsofdeg;
            public int TopEdgeStatus;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Reserved;
            //public FixedLengthString Reserved;

            public static typDocStatus CreateInstance()
            {
                typDocStatus result = new typDocStatus();
                result.Reserved = FixedLength(result.Reserved, 20);//new FixedLengthString(20);
                return result;
            }

            public static string FixedLength(string value, int length)
            {
                if (value == null)
                    value = string.Empty;
                if (value.Length > length)
                    value = value.Remove(length - 1, value.Length - length - 1);
                else
                    value += value.PadRight(length, '\0');

                return value;
            }
        }

    }
}
