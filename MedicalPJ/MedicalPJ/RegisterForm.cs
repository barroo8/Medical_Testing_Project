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
        }

        private void registerclickBtn_Click(object sender, EventArgs e)
        {

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
            usercondiLbl.Text = "שם משתמש חייב להכין בין 6 ל8 תווים";
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
    }
}
