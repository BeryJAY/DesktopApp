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
using Newtonsoft.Json.Linq;
using CarParkingApplication.Code;

namespace CarParkingApplication
{
  
    public enum AccountTypes
    {
        Administrator,Supervisor,Casual
    }

    public partial class Login : MetroForm
    {

        private static int UserType;
        private bool LoginComplete = false;
        
        public Login()
        {
            
            InitializeComponent();
            LoadData();
            
        }

        public void LoadData()
        {
            UserTypeCombo.Items.Add(AccountTypes.Administrator);
            UserTypeCombo.Items.Add(AccountTypes.Casual);
            UserTypeCombo.Items.Add(AccountTypes.Supervisor);
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {

            try
            {
                Task<string> t = getLogin(UserType, EmailBox.Text, PasswordBox.Text);

                await t;

                if (t.IsCompleted)
                {
                    metroProgressSpinner1.Spinning = false;
                }

                if (t.Result == '"' + "Authenticated" + '"')
                {
                    pictureBox1.Image = new Bitmap(CarParkingApplication.Properties.Resources.fingerdumbcorrect);


                    if (UserType == 1)
                    {
                        Home_User_ home = new Home_User_(this);
                        home.Show();
                        //Application.Run(home);
                        this.Hide();
                    }
                    else if (UserType == 2)
                    {
                        Home_Admin_ home = new Home_Admin_(this);
                        home.Show();
                        this.Hide();
                    }
                }
                else
                {
                    pictureBox1.Image = new Bitmap(CarParkingApplication.Properties.Resources.fingerdumbwrong);
                }
                MessageBox.Show(t.Result);
                
            }
            catch
            {
                MessageBox.Show("Please Select User Type");
            }
               
        }

        private async Task<string> getLogin(int AsType,string Email,string password)
        {
            UserFunctions uf = new UserFunctions();
            string r = await uf.Login(new User() { Email = Email, Password = password },AsType,23);
            
            metroProgressSpinner1.Spinning = true;

            while (r == null)
            {

            }

            LoginComplete = true;
           
            return r;
            

        }

        private void UserTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((AccountTypes)UserTypeCombo.SelectedItem)
            {
                case AccountTypes.Administrator:
                    UserType = 2;
                    break;

                case AccountTypes.Supervisor:
                    UserType = 3;
                    break;

                case AccountTypes.Casual:
                    UserType = 1;
                    break;
            }
        }
    }
}
