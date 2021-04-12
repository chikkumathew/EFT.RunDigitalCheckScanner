using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFT.RunDigitalCheckScanner.Common;

namespace EFT.RunDigitalCheckScanner.Services
{
    public class DCSStartScanner
    {
        
        public DCSStartScanner()
        {
           
        }
        public string StartScanner()
        {

            // Run BUICSCAN.INI and initiate the scanner driver
            var bb = InitiateScanner();

            GetCheckImagesandData();

            //RegisterScannerLibrary.BUICGetParam(RegisterScannerLibrary.CFG_RO_DF_SENSOR_TRIGGERED);
            
            return "";
        }
        private void GetCheckImagesandData()
        {
            string strFront = String.Empty;
            string strBack = String.Empty;
            int mlngItems = 0;

            strFront = Constants.ImageLocation + "\\F" + (mlngItems + 1).ToString("0000000") + ".tif";
            strBack = Constants.ImageLocation + "\\B" + (mlngItems + 1).ToString("0000000") + ".tif";

            RegisterScannerOperations.BUICScan(7, strFront, strFront.Length.ToString(), strBack, strBack.Length.ToString(), "", "");
        }
        private int InitiateScanner()
        {
            RegisterScannerOperations.typDocStatus DocStatus = RegisterScannerOperations.typDocStatus.CreateInstance();

            if (!RegisterScannerOperations.DirExists(Constants.ImageLocation))
            {
                Directory.CreateDirectory(Constants.ImageLocation);
            } //Make folder to save images


            RegisterScannerOperations.BUICSetParamString(RegisterScannerOperations.CFG_INIPATH, Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\BUICSCAN.INI");
            //WriteLog("Initiate Scan");

            return RegisterScannerOperations.BUICInit();
        }

    }


}
