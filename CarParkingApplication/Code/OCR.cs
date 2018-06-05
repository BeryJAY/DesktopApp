using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tesseract;

namespace CarParkingApplication
{
    class OCR
    {


        private string FinalLicense;
        public string GetLicense(Bitmap bm)
        {
           

                var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                
                var page = ocr.Process(bm,null);

                

            if (page.GetText().Length > 3 && IsValidLicense(page.GetText()))
            {
                return FinalLicense;
            }

            else
            {
                return "INVALID";
            }

            
        }

        private string LicenceREGEX = @"^[A-Z]{2,3}\s+[0-9]{3}[A-Z]{1}$";

        private bool IsValidLicense(string PageText)
        {
            Regex regex = new Regex(@"[A-Z]{2,3}\s+[0-9]{3}[A-Z]{1}");

            Match matcher = regex.Match(PageText);

            regex = new Regex(LicenceREGEX);

            FinalLicense = matcher.Groups[0].Value + matcher.Groups[1].Value + matcher.Groups[2].Value;

            if (regex.IsMatch(FinalLicense))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
