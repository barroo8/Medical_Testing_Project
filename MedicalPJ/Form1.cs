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
using System.Reflection;
using System.IO;
using MedicalPJ;
using IronXL;

namespace MedicalPJ
{
    public partial class Form1 : Form
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();

            //Center the image
            headerPic.Left = (this.ClientSize.Width - headerPic.Width) / 2;
            headerPic.Top = (this.ClientSize.Height - headerPic.Height) / 2 - 45;

            //Login + Register TextBox
            this.loginTxtBox.AutoSize = false;
            this.passwordTxtBox.AutoSize = false;
            loginTxtBox.Size = new System.Drawing.Size(360, 30);
            passwordTxtBox.Size = new System.Drawing.Size(360, 30);
            loginTxtBox.Font = new Font(loginTxtBox.Font.FontFamily, 16);
            passwordTxtBox.Font = new Font(passwordTxtBox.Font.FontFamily, 16);
            loginTxtBox.Text = "שם משתמש";
            this.loginTxtBox.Leave += new System.EventHandler(this.loginTxtBox_Leave);
            this.loginTxtBox.Enter += new System.EventHandler(this.loginTxtBox_Enter);
            passwordTxtBox.Text = "סיסמא";
            this.passwordTxtBox.Leave += new System.EventHandler(this.passwordTxtBox_Leave);
            this.passwordTxtBox.Enter += new System.EventHandler(this.passwordTxtBox_Enter);
            passwordTxtBox.ForeColor = Color.Silver;
            loginTxtBox.ForeColor = Color.Silver;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IronXL.License.LicenseKey = "IRONXL.ALEXSAVIZKY.29293-E7232B2EF6-H2I4LF-7GQK" +
                "Q3MWRGNM-2CN3SLI53KIJ-E4W23I7FJ4XL-" +
                "Y2535OOEXL2C-FXU7QDZDE2PS-R7K4Q4-TQ4ZCBH5GBOGEA-DEPLOYMENT.TRIAL-QC3FJE.TRIAL.EXPIRES.16.JUN.2022";
            this.ActiveControl = headerPic;
            InitCustomLabelFont();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            bool restrict = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "הרשמה למערכת")
                {
                    restrict = true;
                    f.BringToFront();
                    break;
                }
            }
            if (restrict == false)
            {
                RegisterForm reg = new RegisterForm();
                reg.Show();
            }
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


            headerLbl.Font = new Font(pfc.Families[0], 20);
            headerLbl.Text = "פרויקט מסכם בקורס בדיקות ואיכות תוכנה";

            loginBtn.Font = new Font(pfc.Families[0], 18);
            loginBtn.Text = "התחברות";

            registerBtn.Font = new Font(pfc.Families[0], 18);
            registerBtn.Text = "הרשמה";

            WelcomeLbl.Font = new Font(pfc.Families[0], 15);
            WelcomeLbl.Text = "ברוכים הבאים למערכת הרפואית המתקדמת בישראל";

            closeescLbl.Font = new Font(pfc.Families[0], 10);
            closeescLbl.Text = "";
        }
        //Dispose pfc when closed
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            pfc.Dispose();
        }

        //Login & Register block
        private void loginTxtBox_Leave(object sender, EventArgs e)
        {
            if (loginTxtBox.Text.Length == 0)
            {
                loginTxtBox.Text = "שם משתמש";
                loginTxtBox.ForeColor = Color.Silver;
                loginTxtBox.Font = new Font(loginTxtBox.Font.FontFamily, 16);
            }

        }
        private void loginTxtBox_Enter(object sender, EventArgs e)
        {
            if (loginTxtBox.Text == "שם משתמש")
            {
                loginTxtBox.Text = "";
                loginTxtBox.ForeColor = SystemColors.WindowText;
                loginTxtBox.Font = new Font(loginTxtBox.Font.FontFamily, 16);
            }
        }
        private void passwordTxtBox_Leave(object sender, EventArgs e)
        {
            if (passwordTxtBox.Text.Length == 0)
            {
                passwordTxtBox.Text = "סיסמא";
                passwordTxtBox.ForeColor = Color.Silver;
                passwordTxtBox.Font = new Font(passwordTxtBox.Font.FontFamily, 16);
                passwordTxtBox.PasswordChar = '\0';
            }
        }
        private void passwordTxtBox_Enter(object sender, EventArgs e)
        {
            if (passwordTxtBox.Text == "סיסמא")
            {
                passwordTxtBox.Text = "";
                passwordTxtBox.ForeColor = SystemColors.WindowText;
                passwordTxtBox.Font = new Font(passwordTxtBox.Font.FontFamily, 16);
                passwordTxtBox.PasswordChar = '*';
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //connect to the excel
            WorkBook workbook = WorkBook.Load("doctors.xlsx");
            var sheet = workbook.GetWorkSheet("sheet");
            //chek there is no user name with this username
            int raw_index = 1;
            string cell_val = "1";
            while (cell_val != "")
            {
                raw_index++;
                cell_val = sheet["A" + raw_index.ToString()].ToString();
                if (sheet["A" + raw_index.ToString()].ToString() == loginTxtBox.Text && sheet["B" + raw_index.ToString()].ToString() == passwordTxtBox.Text)
                {
                    //succes next page
                    (new Dashboard()).Show();
                    this.Hide();
                    break;
                }
            }

            //fail username or password wrong
            closeescLbl.ForeColor = Color.Red;
            closeescLbl.Text = "שם משתמש וסיסמא לא נכונים/לא קיימים במערכת";

            var t = new Timer();
            t.Interval = 2000;
            t.Tick += (s, ee) =>
            {
                closeescLbl.Text = "";
                closeescLbl.ForeColor = Color.Black;
                t.Stop();
            };
            t.Start();
        }
    }
}
