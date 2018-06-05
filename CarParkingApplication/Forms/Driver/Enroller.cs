using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using CarParkingApplication.Code;

namespace CarParkingApplication.Forms.Driver
{
    public partial class Enroller : MetroForm
    {
        Home_User_ h;

        public Enroller()
        {
            InitializeComponent();
        }
        public Enroller(Home_User_ h)
        {
          
            InitializeComponent();
            this.h = h;
        }
        
        public int UserID { get; set; }

        public Bitmap ScannedFingerPrint { get; set; }

        private void fingerprintbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "FingerPrint Images|*.tif;" ;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ScannedFingerPrint = new Bitmap(ofd.FileName);

                GetDriver();
            }

          
            
        }


        private async void GetDriver()
        {
            try
            {
                pictureBox2.Image = ScannedFingerPrint;

                UserFunctions uf = new UserFunctions();

                label2.Text = "Scanning...";

                int y = await uf.GetDriver(new Imc().ToBase64String(new Imc().ToByteArr(ScannedFingerPrint)));

                if (y == 0)
                {
                    pictureBox1.Image = Properties.Resources.fingerdumbwrong;
                    label2.Text = "Failed to find Driver";
                }
                else
                {

                    UserID = y;

                    // System.Diagnostics.Debug.WriteLine("Current Gate: "+h.CurrentGate.ToString());
                    try
                    {
                        if (h.CurrentGate == GateSide.Entrance)
                        {
                            pictureBox1.Image = Properties.Resources.fingerdumbcorrect;
                            label2.Text = "Success";

                            this.Close();

                            MessageBox.Show(h, String.Format("{0} Car has Entered Parking", h.DetectedLicenseNumber));
                        }
                        else
                        {
                            bool result = await uf.ExitParking(23, h.CarID, UserID);

                            if (result)
                            {
                                pictureBox1.Image = Properties.Resources.fingerdumbcorrect;
                                label2.Text = "Success";

                                this.Close();

                                MessageBox.Show(h, String.Format("{0} Car has Exited Parking", h.DetectedLicenseNumber));
                            }
                            else
                            {
                                pictureBox1.Image = Properties.Resources.fingerdumbwrong;
                                label2.Text = "Failed to find Driver";
                            }
                        }


                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
           

        }


        public enum Result
        {
            Enroll,
            Register
        }

            
      
    }
}
