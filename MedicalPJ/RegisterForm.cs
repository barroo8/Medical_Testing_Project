using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using MedicalPJ;
using IronXL;


namespace MedicalPJ
{
    public partial class RegisterForm : Form
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();

        public RegisterForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            InitCustomLabelFont();
            errorLbl.ForeColor = Color.DarkRed;
            errorLbl2.ForeColor = Color.DarkRed;
            errorLbl3.ForeColor = Color.DarkRed;
        }

        private void registerclickBtn_Click(object sender, EventArgs e)
        {
            WorkBook workbook = WorkBook.Load("doctors.xlsx");
            var sheet = workbook.GetWorkSheet("sheet");
            //chek there is no user name with this username
            int raw_index = 1;
            string cell_val = "1";
            bool flag = true;
            while (cell_val != "")
            {
                raw_index++;
                cell_val = sheet["A" + raw_index.ToString()].ToString();
                if (cell_val == textBox1.Text)
                {
                    //there is alrady username with this name
                    errorLbl.Visible = true;
                    errorLbl.Text = "שם המשתמש שהזנת כבר קיים במערכת";


                    var t = new Timer();
                    t.Interval = 2000;
                    t.Tick += (s, ee) =>
                    {
                        errorLbl.Visible = false;
                        t.Stop();
                    };
                    t.Start();

                    flag = false;
                }
            }
            if (flag)
            {
                sheet["A" + raw_index.ToString()].Value = textBox1.Text;
                sheet["B" + raw_index.ToString()].Value = textBox2.Text;
                sheet["C" + raw_index.ToString()].Value = textBox3.Text;
                workbook.SaveAs("doctors.xlsx");
                this.Hide();
            }
        }

        //Custom Font function
        private void InitCustomLabelFont()
        {
            //Create your private font collection object.
            //PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            int fontLength = Properties.Resources.SecularOne_Regular.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.SecularOne_Regular;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            usernameLbl.Font = new Font(pfc.Families[0], 14);
            usernameLbl.Text = ":שם משתמש";

            usercondiLbl.Font = new Font(pfc.Families[0], 10);
            usercondiLbl.Text = "שם משתמש חייב להכיל בין 6 ל8 תווים";
            usercondiLbl2.Font = new Font(pfc.Families[0], 10);
            usercondiLbl2.Text = "לכל היותר 2 ספרות וכל השאר אותיות באנגלית";
            passcondiLbl.Font = new Font(pfc.Families[0], 10);
            passcondiLbl.Text = "(...#,!,$) סיסמא חייבת להכיל 8-10 תווים, חייב להכיל לפחות אות, ספרה ותו מיוחד";
            idcondiLbl.Font = new Font(pfc.Families[0], 10);
            idcondiLbl.Text = "תעודת זהות חייבת להכיל 9 ספרות כולל ספרת ביקורת";

            passwordLbl.Font = new Font(pfc.Families[0], 14);
            passwordLbl.Text = ":סיסמא";

            idLbl.Font = new Font(pfc.Families[0], 14);
            idLbl.Text = ":תעודת זהות";

            registerclickBtn.Font = new Font(pfc.Families[0], 18);
            registerclickBtn.Text = "הרשמה למערכת";
        }

        //Dispose pfc when closed
        private void RegisterForm_FormClosing(Object sender, FormClosingEventArgs e) 
        {
            pfc.Dispose();
        }

        //ESC exit button function block
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 6 || textBox1.Text.Length > 8)
            {
                errorLbl.Text = "שם משתמש חייב להכיל בין 6 ל8 תווים";
                textBox1.Text = "";
                errorLbl.Visible = true;
                return;
            }
            int nums = 0;
            foreach (char c in textBox1.Text)
            {
                if (c > 47 && c < 58)
                {
                    nums++;
                    if (nums > 2)
                    {
                        errorLbl.Text = "לכל היותר 2 ספרות וכל השאר אותיות באנגלית";
                        textBox1.Text = "";
                        errorLbl.Visible = true;
                        break;
                    }
                }
                else if (!char.IsLetter(c))
                {
                    errorLbl.Text = "לכל היותר 2 ספרות וכל השאר אותיות באנגלית";
                    textBox1.Text = "";
                    errorLbl.Visible = true;
                    break;
                }
            }

        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            errorLbl.Visible = false;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 8 || textBox2.Text.Length > 10)
            {
                errorLbl2.Text = "סיסמא חייבת להכיל בין 8 ל10 תווים";
                textBox2.Text = "";
                errorLbl2.Visible = true;
                return;
            }
            int p1 = 0, p2 = 0;
            foreach (char c in textBox2.Text)
            {
                if (char.IsDigit(c))
                    p1++;
                else if (char.IsLetter(c))
                    p2++;
            }
            if (!HasSpecialChars(textBox2.Text) || p1==0 || p2==0)
            {
                errorLbl2.Text = "(...#,!,$) חייב להכיל לפחות אות, ספרה ותו מיוחד";
                textBox2.Text = "";
                errorLbl2.Visible = true;
                return;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            errorLbl2.Visible = false;
            textBox2.PasswordChar = '*';
        }

        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 9)
            {
                errorLbl3.Text = "תעודת זהות חייבת להכיל 9 ספרות כולל ספרת ביקורת";
                textBox3.Text = "";
                errorLbl3.Visible = true;
                return;
            }
            foreach (char c in textBox3.Text)
            {
                if (!char.IsDigit(c))
                {
                    errorLbl3.Text = "תעודת זהות חייבת להכיל 9 ספרות כולל ספרת ביקורת";
                    textBox3.Text = "";
                    errorLbl3.Visible = true;
                    break;
                }
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            errorLbl3.Visible = false;
        }
    }
}
