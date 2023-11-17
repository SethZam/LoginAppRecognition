using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition;

namespace LoginAppRecognition
{
    public partial class Form2 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        string log;
        string user;
        string pass;

        public Form2()
        {
            InitializeComponent();
        }

        FaceRec fr = new FaceRec();

        private void opencam_Click(object sender, EventArgs e)
        {
            fr.openCamera(pictureBox1, pictureBox2);
        }

        private void detectfaces_Click(object sender, EventArgs e)
        {
            fr.isTrained = true;
            var login = db.sp_facelogin(lblusername.Text).ToList();
            foreach (var item in login)
            {
                log = item.Fullname;
            }

            var username = db.sp_login(txtuser.Text, txtpass.Text).ToList();
            foreach (var items in username)
            {
                user = items.username;
                pass = items.passwords;
            }
            if (log == lblusername.Text)
            {
                if (db.sp_type(user, pass) == 0)
                {
                    MessageBox.Show($"Hi {log}, Welcome Admin!");
                }
                else
                {
                    MessageBox.Show($"Hi {log}, Welcome Staff!");
                }
            }
            else if (user == txtuser.Text && pass == txtpass.Text)
            {
                if (db.sp_type(user, pass) == 0)
                {
                    MessageBox.Show($"Hi {log}, Welcome Admin!");
                }
                else
                {
                    MessageBox.Show($"Hi {log}, Welcome Staff!");
                }
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fr.getPersonName(lblusername);
        }
    }
}
