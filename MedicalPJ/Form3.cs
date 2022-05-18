using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;

namespace MedicalPJ
{
    public partial class Form3 : Form
    {
        float[] madadim = new float[11];
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            errorLbl.ForeColor = Color.Red;
            errorLbl2.ForeColor = Color.Red;
            errorLbl3.ForeColor = Color.Red;
            errorLbl4.ForeColor = Color.Red;

            richTextBox1.AllowDrop = true;
            richTextBox1.DragDrop += RichTextBox1_DragDrop;
            richTextBox1.KeyDown += new KeyEventHandler(RichTextBox1_KeyDown);
        }

        void RichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    label1.Text = fileNames[0];
                    label1.Visible = true;

                    WorkBook workbook = WorkBook.Load(fileNames[0]);
                    var sheet = workbook.GetWorkSheet("sheet");
                    Char x = 'A';
                    for (int i = 0; i < 11; i++)
                    {
                        madadim[i] = float.Parse(sheet[x.ToString() + "2"].ToString());
                        x = (Char)(Convert.ToUInt16(x) + 1);

                    }
                }
            }
        }

        private void nameTxtBox_Enter(object sender, EventArgs e)
        {
            errorLbl.Visible = false;
        }

        private void nameTxtBox_Leave(object sender, EventArgs e)
        {
            foreach (char c in nameTxtBox.Text)
            {
                if (c > 47 && c < 58)
                {
                    errorLbl.Text = "שם חייב להכיל אותיות בלבד";
                    errorLbl.Visible = true;
                    nameTxtBox.Text = "";
                    break;
                }
            }
        }

        private void lastnameTxtBox_Leave(object sender, EventArgs e)
        {
            foreach (char c in lastnameTxtBox.Text)
            {
                if (c > 47 && c < 58)
                {
                    errorLbl2.Text = "שם משפחה חייב להכיל אותיות בלבד";
                    errorLbl2.Visible = true;
                    lastnameTxtBox.Text = "";
                    break;
                }
            }
        }

        private void lastnameTxtBox_Enter(object sender, EventArgs e)
        {
            errorLbl2.Visible = false;
        }

        private void ageTxtBox_Leave(object sender, EventArgs e)
        {
            foreach (char c in ageTxtBox.Text)
            {
                if (c < 47 || c > 58)
                {
                    errorLbl3.Text = "גיל חייב להיות מספר בין 1-120";
                    errorLbl3.Visible = true;
                    ageTxtBox.Text = "";
                    break;
                }
            }
            try
            {
                int textVal = int.Parse(ageTxtBox.Text);
                if (textVal > 120 || textVal < 0)
                {
                    errorLbl3.Text = "גיל חייב להיות מספר בין 1-120";
                    errorLbl3.Visible = true;
                    ageTxtBox.Text = "";
                }
            }
            catch
            {

            }
        }

        private void ageTxtBox_Enter(object sender, EventArgs e)
        {
            errorLbl3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((maleRBtn.Checked == false && femaleRBtn.Checked == false) || (mizrahiRBtn.Checked == false &&
                nomizrahiRBtn.Checked == false) || (ethipoiRBtn.Checked == false && noethiopiRBtn.Checked == false) ||
                nameTxtBox.Text == "" || lastnameTxtBox.Text == "" || ageTxtBox.Text == "" || richTextBox1.Text == "")
            {
                errorLbl4.Visible = true;
                errorLbl4.Text = "נא למלא את כל השדות במלואם";
                var t = new Timer();
                t.Interval = 2000;
                t.Tick += (s, ee) =>
                {
                    errorLbl4.Visible = false;
                    t.Stop();
                };
                t.Start();
                return;
            }

            ChartsForm cf = new ChartsForm();
            loadform(cf);
            panel1.BringToFront();
        }

        public void loadform(object Form)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(f);
            this.panel1.Tag = f;
            f.Show();
        }


    }
}
