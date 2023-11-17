using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAppRecognition
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            int login = db.sp_login(txtuser.Text, txtpass.Text).Count();

            if (db.sp_type(txtuser.Text, txtpass.Text) == 0)
            {
                MessageBox.Show("Welcome Admin");
            }
            else
            {
                MessageBox.Show("Welcome Staff");
            }
        }

        private void btnface_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
    }
}
