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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        FaceRec fr = new FaceRec();
        DataClasses1DataContext db = new DataClasses1DataContext();
        string image;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == " " || textBox5.Text == " " || textBox1.Text == " " || textBox2.Text == " " || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Fill user inputs", "Message");
            }
            else
            {
                fr.openCamera(pictureBox1, pictureBox2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == " " || textBox5.Text == " ")
            {
                MessageBox.Show("Fill user inputs", "Message");
            }
            else
            {
                image = textBox3.Text + " " + textBox5.Text;
                fr.Save_IMAGE(textBox3.Text + " " + textBox5.Text);
                fr.isTrained = true;
                db.create_user(textBox3.Text, textBox5.Text, textBox1.Text, textBox2.Text, Convert.ToInt32(comboBox1.SelectedIndex), image);
                MessageBox.Show("Saved Successfully", "Saved");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
