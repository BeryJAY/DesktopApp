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

namespace CarParkingApplication.Forms.Employees
{
    public partial class EmployeeView : MetroForm
    {
        MetroForm LastForm;

        public EmployeeView()
        {
            InitializeComponent();
        }

        public EmployeeView(MetroForm f)
        {
            InitializeComponent();
            LastForm = f;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            LastForm.Show(this);
            this.Hide();
        }

        private void CreateEmployeeButton_Click(object sender, EventArgs e)
        {
            NewEmployee newEmployee = new NewEmployee();
            newEmployee.Show();
        }
    }
}
