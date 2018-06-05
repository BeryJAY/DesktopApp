using CarParkingApplication.Code;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkingApplication.Forms.Driver
{
    public partial class RegisterDriver : MetroForm
    {

        Bitmap ScannedFingerPrint;
        private int UserId;

        public RegisterDriver()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "FingerPrint Images|*.tif;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ScannedFingerPrint = new Bitmap(ofd.FileName);

                pictureBox1.Image = ScannedFingerPrint;

                GetPrintUser();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetUser();
           
        }

        public async void GetPrintUser()
        {
            UserFunctions uf = new UserFunctions();
            User u = new User();
          
            try
            {

                int UserID = await uf.GetDriver(new Imc().ToBase64String(new Imc().ToByteArr(ScannedFingerPrint)));

                u = await uf.GetUser(UserID);


                firstnamelabel.Text = u.NationalRegInfo.FirstName;
                lastnamelabel.Text = u.NationalRegInfo.LastName;
                ninlabel.Text = u.NationalRegInfo.NIN;
                phonelabel.Text = u.PhoneNumber;
                emaillabel.Text = u.Email;
                UserId = u.ID;
            }
            catch
            {

            }

        }

        public async void GetUser()
        {
            UserFunctions uf = new UserFunctions();
            User u= new User();

            pictureBox1.Image = Properties.Resources.fingerdumb;

            try
            {
                u = await uf.GetUser(usersearchbox.Text);

                firstnamelabel.Text = u.NationalRegInfo.FirstName;
                lastnamelabel.Text =  u.NationalRegInfo.LastName;
                ninlabel.Text = u.NationalRegInfo.NIN;
                phonelabel.Text =  u.PhoneNumber;
                emaillabel.Text =  u.Email;
                UserId = u.ID;
                savebtn.Enabled = true;

                if (u.FingerPrint != "")
                {
                    button2.Enabled=false;
                    savebtn.Enabled = false;    
                    pictureBox1.Image = new Imc().ToBitmap(new Imc().ToByteArr(u.FingerPrint));
                }
                else
                {
                    button2.Enabled = true;
                savebtn.Enabled = true;
                }

              
        }
            catch
            {
                firstnamelabel.Text = "null";
                lastnamelabel.Text = "null";
                ninlabel.Text = "null";
                phonelabel.Text = "null";
                emaillabel.Text = "null";
                savebtn.Enabled = false;
                button2.Enabled = false;
            }

}

private void savebtn_Click(object sender, EventArgs e)
        {
            RegisterCurrentDriver();
        }

        private async void RegisterCurrentDriver()
        {
            if (ScannedFingerPrint != null && UserId != 0)
            {
                
                UserFunctions uf = new UserFunctions();
                await uf.RegisterDriver(UserId);
            }
        }

    }
}
