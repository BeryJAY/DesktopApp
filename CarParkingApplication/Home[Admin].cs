using CarParkingApplication.Forms.Employees;
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

namespace CarParkingApplication
{
    public partial class Home_Admin_ : MetroForm
    {
        MetroForm PreviousForm;
        EmployeeView ev;

        public Home_Admin_(MetroForm form)
        {
            InitializeComponent();
            PreviousForm = form;
        }

        private void EmployyesTile_Click(object sender, EventArgs e)
        {
            if (ev == null)
            {
                ev = new EmployeeView(this);

            }
            else
            {

            }

            this.Hide();
            ev.Show();
        }
    }
}
