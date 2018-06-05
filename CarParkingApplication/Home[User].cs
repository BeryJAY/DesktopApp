using CarParkingApplication.Code;
using CarParkingApplication.Forms.Driver;
using MetroFramework.Forms;
using MyREST.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkingApplication
{
    public partial class Home_User_ : MetroForm
    {
        UserFunctions ufunctions;

        private bool EntranceGateOpened = false;
        private bool ExitGateOpened=false;
        private Timer tm1,tm2;
        private Bitmap LicenseBitmap;
        public string DetectedLicenseNumber  { get; set; }
        public int ParkID { get; set; }
        public int CarID { get; set; }
        public GateSide CurrentGate { get; set; }
        MetroForm f;
      

        public Home_User_(MetroForm form)
        {
            InitializeComponent();
            GateTypeCombo.SelectedText = GateSide.Entrance.ToString();

            GateTypeCombo.Items.Add(GateSide.Entrance.ToString());
            GateTypeCombo.Items.Add(GateSide.Exit.ToString());

            GetPark(24);

            try
            {
                CameraCapture cm = new CameraCapture();
                cm.Feed = FeedBox;
            }
            catch
            {

            }

            UpdateActivities();
         
        }

        private void StartEntranceOperations()
        {
            try
            {
                tm1 = new Timer();
                tm1.Interval = 5000;
                tm1.Tick += new EventHandler(SyncEntranceOperations);
                tm1.Start();
            }
            catch
            {

            }
           
        }
    
        private void StartExitOperations()
        {
            try
            {
                tm2 = new Timer();
                tm2.Interval = 5000;
                tm2.Tick += new EventHandler(SyncExitOperations);
                tm2.Start();
            }
            catch
            {

            }
        }

        


        private void OpenGate(GateSide G)
        {
            switch (G)
            {
                case GateSide.Entrance:
                    EntranceGateOpened = true;
                    break;

                case GateSide.Exit:
                    ExitGateOpened = true;
                    break;
            }

        }

        private void CloseGate(GateSide G)
        {
            switch (G)
            {
                case GateSide.Entrance:
                    EntranceGateOpened = false;
                    tm1.Start();
                    break;

                case GateSide.Exit:
                    ExitGateOpened = false;
                    tm2.Start();
                    break;

            }
        }

        private async void Test()
        {
            ufunctions = new UserFunctions();

            int y = await ufunctions.RegisterCar("UAU 047L");

        }

        private async void SyncEntranceOperations(object sender, EventArgs e)
        {
            if (EntranceGateOpened)
            {
                tm1.Stop();

                CloseGate(GateSide.Entrance);
            }
            else
            {
                LicenseBitmap = (Bitmap)FeedBox.Image;

                if (LicenseBitmap == null)
                {
                    DetectedLicense.Text = "NULL";
                }
                else
                {
                    DetectedLicense.Text = "LOADING";

                    pictureBox1.Image = FeedBox.Image;

                    OCR ocr = new OCR();
                   
                    DetectedLicense.Text= ocr.GetLicense(Get24bppRgb(LicenseBitmap));

                    if (!DetectedLicense.Text.Equals("INVALID"))
                    {
                        DetectedLicenseNumber = DetectedLicense.Text;

                        tm1.Stop();

                        ufunctions = new UserFunctions();
                        UserFunctions uf = new UserFunctions();

                        int y = await uf.RegisterCar(DetectedLicense.Text);
                        CarID = y;

                        Enroller en = new Enroller(this);
                        en.ShowDialog();

                        bool t = await ufunctions.GetParking(23, y, en.UserID);

                        ProcessTicket(23, y);

                       
                        
                    }

                }
             
            }
        }


        private async void UpdateActivities()
        {

            List<ListViewItem> lvlist = new List<ListViewItem>();

            foreach (ParkingYard.Activities Activity in await ufunctions.GetActivities(23))
            {

                if (HistoryListView.InvokeRequired)
                {
                    HistoryListView.Invoke(new MethodInvoker(delegate
                    {
                        

                        string[] str = { "Hello", "world" };

                        HistoryListView.Items.Add(Activity.License).SubItems.Add(Activity.IN.ToString());


                    }));

                }
              //  HistoryListView.Items.AddRange(new ListViewItem[] { lvi, lvi, lvi3 });

            }

        }

        private static Bitmap Get24bppRgb(Image image)
        {
            var bitmap = new Bitmap(image);
            var bitmap24 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bitmap24))
            {
                gr.DrawImage(bitmap, new Rectangle(0, 0, bitmap24.Width, bitmap24.Height));
            }
            return bitmap24;
        }

        private async void SyncExitOperations(object sender, EventArgs e)
        {
            if (ExitGateOpened)
            {
                tm2.Stop();

                CloseGate(GateSide.Exit);
            }
            else
            {
                LicenseBitmap = (Bitmap)FeedBox.Image;

                if (LicenseBitmap == null)
                {
                    DetectedLicense.Text = "NULL";
                }
                else
                {
                    DetectedLicense.Text = "LOADING";

                    pictureBox1.Image = FeedBox.Image;

                    OCR ocr = new OCR();

                    DetectedLicense.Text = ocr.GetLicense(Get24bppRgb(LicenseBitmap));

                    if (!DetectedLicense.Text.Equals("INVALID"))
                    {
                        DetectedLicenseNumber = DetectedLicense.Text;

                        tm2.Stop();

                        ufunctions = new UserFunctions();
                        UserFunctions uf = new UserFunctions();

                        int y = await uf.RegisterCar(DetectedLicense.Text);
                        CarID = y;

                        Enroller en = new Enroller(this);
                        en.ShowDialog();

                       
                        
                    }
                }
                        //Capture Image from here and process it

                    }
                }
        private bool CheckLicense(string License)
        {
            //Code to check whether license exists

            return true;

        }

        private async void GetPark(int id)
        {
            ufunctions = new UserFunctions();

            Park p = new Park();

            p = await ufunctions.GetPark(id);

            carparktitle.Text = p.Name;
            
               
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
           
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bm = new Bitmap(ofd.FileName);

                Imc imc = new Imc();

                string h = Convert.ToBase64String(imc.ToByteArr(bm));

                TimeStampLabel.Text = "Date / Time: " + DateTime.Now;

                GetLicense(bm);
                


              
            }

            
            
           
        }

        private async void ProcessTicket(int ParkId,int CarId)
        {
            ufunctions = new UserFunctions();
            ParkTicket pt = new ParkTicket();
            pt = await ufunctions.GetParkTicket(ParkId, CarId);

            ticketid.Text = pt.TicketID.ToString();
            ticketdate.Text = pt.Date.ToLongDateString();
            ticketdriver.Text = pt.DriverName;
            ticketlicense.Text = pt.License;
            
        }

        private void GetLicense(Bitmap bm)
        {   
            Task T = Task.Run(() =>
            {
                OCR ocr = new OCR();

                if (DetectedLicense.InvokeRequired)
                {
                    DetectedLicense.Invoke(new MethodInvoker(delegate
                    {
       
                        DetectedLicense.Text= ocr.GetLicense(bm);

                    }));
                }
                
            });

       
        }

        private void GateTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (GateTypeCombo.SelectedItem.Equals(GateSide.Entrance.ToString()))
                {
                    StartEntranceOperations();
                    CurrentGate = GateSide.Entrance;
                }
                else
                {
                    StartExitOperations();
                    CurrentGate = GateSide.Exit;
                }
            }
            catch
            {

            }
        }

        private void RegisterDriverButton_Click(object sender, EventArgs e)
        {
            RegisterDriver rd = new RegisterDriver();
            rd.Show(this);
        }

      

    }

    public enum GateSide
    {
        Entrance,
        Exit
    }
}
