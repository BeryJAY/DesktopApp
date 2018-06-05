//----------------------------------------------------------------------------
//  Copyright (C) 2004-2018 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCam_Capture;

namespace CarParkingApplication
{
    public partial class CameraCapture
    {
        public Task Scan;
        private EventHandler ScanComplete, Scanning;
        WebCam_Capture.WebCamCapture Webcam;
        public PictureBox Feed { get; set; }

        public CameraCapture()
        {

            try
            {
                WebCam_Capture.WebCamCapture WebCam = new WebCamCapture();

                WebCam.Start(0);

                //ScanComplete += new EventHandler(ScanningComplete);

                WebCam.Height = 0;
                WebCam.Width = 0;
                WebCam.ImageCaptured += new WebCamCapture.WebCamEventHandler(ImageCaptured);
            }
            catch
            {

            }
        }

        private void ImageCaptured(object source, WebcamEventArgs e)
        {
            Feed.Image = e.WebCamImage;
        }

        private void ScanningComplete(object sender, EventArgs e)
        {
            while (ScanPicture() == false)
            {
               
            }

            if (Scan != null)
            {
                Scan.Dispose();
            }
        }

        private bool ScanPicture()
        {
            bool started = false;

            Scan = Task.Run(() =>
            {


                started = true;
            });


            return started;
        }

    }
}
