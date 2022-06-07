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
using IronXL.Formatting;
using IronXL.Formatting.Enums;
using IronXL.Styles;

namespace MedicalPJ
{
    public partial class Form2 : Form
    {
        private List<TextBox> textBoxes = new List<TextBox>();
        int raw_index = Dashboard.raw_index;
        
        public Form2()
        {
            InitializeComponent();

            textBoxes.Add(wbcTxtBox);
            textBoxes.Add(ureaTxtBox);
            textBoxes.Add(neutTxtBox);
            textBoxes.Add(hbTxtBox);
            textBoxes.Add(lymphTxtBox);
            textBoxes.Add(crtnTxtBox);
            textBoxes.Add(rbcTxtBox);
            textBoxes.Add(ironTxtBox);
            textBoxes.Add(hctTxtBox);
            textBoxes.Add(hdlTxtBox);
            textBoxes.Add(apTxtBox);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            errorLbl.ForeColor = Color.Red;
            errorLbl2.ForeColor = Color.Red;
            errorLbl3.ForeColor = Color.Red;
            errorLbl4.ForeColor = Color.Red;
            errorLbl5.ForeColor = Color.Red;

        }

        public void button1_Click(object sender, EventArgs e)
        {
            //------------------------------check if the form filled correctly -------------------------------------
            if ((maleRBtn.Checked == false && femaleRBtn.Checked == false) || (mizrahiRBtn.Checked == false &&
                nomizrahiRBtn.Checked == false) || (ethipoiRBtn.Checked == false && noethiopiRBtn.Checked == false) ||
                nameTxtBox.Text == "" || lastnameTxtBox.Text == "" || ageTxtBox.Text == "")
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

            bool flag = false;

            foreach (TextBox t in textBoxes)
            {

                if (t.Text == "")
                {
                    errorLbl5.Visible = true;
                    errorLbl5.Text = "נא למלא את כל השדות במלואם";
                    var t3 = new Timer();
                    t3.Interval = 2000;
                    t3.Tick += (s, ee) =>
                    {
                        errorLbl5.Visible = false;
                        t3.Stop();
                    };
                    t3.Start();
                    return;
                }

                int isDot = 0;

                foreach (char c in t.Text)
                {
                    if (c == 46)
                    {
                        isDot += 1;
                    }

                    if ((c < 47 && c != 46) || isDot > 1 || c > 58)
                    {
                        flag = true;
                        t.Text = "";
                    }
                }
            }
            if (flag == true)
            {
                errorLbl5.Visible = true;
                errorLbl5.Text = "נא להקיש ערכים מספריים";
                var t2 = new Timer();
                t2.Interval = 2000;
                t2.Tick += (s, ee) =>
                {
                    errorLbl5.Visible = false;
                    t2.Stop();
                };
                t2.Start();
                flag = false;
                return;
            }
            try
            {
                float textVal = float.Parse(neutTxtBox.Text);
                if (textVal > 100 || textVal < 0)
                {
                    errorLbl5.Visible = true;
                    errorLbl5.Text = "neut-נא להקיש ערכים בין 0-100 בתיבת ה";
                    var t4 = new Timer();
                    t4.Interval = 2000;
                    t4.Tick += (s, ee) =>
                    {
                        errorLbl5.Visible = false;
                        t4.Stop();
                    };
                    t4.Start();
                    neutTxtBox.Text = "";
                    return;
                }
            }
            catch
            {

            }
            try
            {
                float textVal = float.Parse(lymphTxtBox.Text);
                if (textVal > 100 || textVal < 0)
                {
                    errorLbl5.Visible = true;
                    errorLbl5.Text = "lymph-נא להקיש ערכים בין 0-100 בתיבת ה";
                    var t5 = new Timer();
                    t5.Interval = 2000;
                    t5.Tick += (s, ee) =>
                    {
                        errorLbl5.Visible = false;
                        t5.Stop();
                    };
                    t5.Start();
                    lymphTxtBox.Text = "";
                    return;
                }
            }
            catch
            {

            }
            try
            {
                float textVal = float.Parse(hctTxtBox.Text);
                if (textVal > 100 || textVal < 0)
                {
                    errorLbl5.Visible = true;
                    errorLbl5.Text = "hct-נא להקיש ערכים בין 0-100 בתיבת ה";
                    var t6 = new Timer();
                    t6.Interval = 2000;
                    t6.Tick += (s, ee) =>
                    {
                        errorLbl5.Visible = false;
                        t6.Stop();
                    };
                    t6.Start();
                    hctTxtBox.Text = "";
                    return;
                }
            }
            catch
            {

            }
            //-------------------------------------------------------------------------------------------
            //------------------------------insert values into the excel fille --------------------------
            WorkBook workbook = WorkBook.Load("Patients.xlsx");
            var sheet = workbook.GetWorkSheet("sheet");
            string cell_val = "1";
            int i = 0;
            int id=0;
            raw_index = 1;
            //find where is the next row and the id of this meeting
            while (cell_val != "")
            {
                raw_index++;
                cell_val = sheet["S" + raw_index.ToString()].ToString();
                if(sheet["A" + raw_index.ToString()].ToString()!= "")
                    id = int.Parse(sheet["A" + raw_index.ToString()].ToString());
            }
            Dashboard.raw_index = raw_index;
            id++;
            //insert values into the excel fille
            sheet["A" + raw_index.ToString()].Value = id;
            sheet["B" + raw_index.ToString()].Value = nameTxtBox.Text;
            sheet["C" + raw_index.ToString()].Value = lastnameTxtBox.Text;
            sheet["D" + raw_index.ToString()].Value = float.Parse(ageTxtBox.Text);
            if (maleRBtn.Checked == true)
            {
                sheet["E" + raw_index.ToString()].Value = true;
            }
            else
            {
                sheet["E" + raw_index.ToString()].Value = false;
            }
            if (mizrahiRBtn.Checked == true)
            {
                sheet["F" + raw_index.ToString()].Value = true;
            }
            else
            {
                sheet["F" + raw_index.ToString()].Value = false;
            }
            if (ethipoiRBtn.Checked == true)
            {
                sheet["G" + raw_index.ToString()].Value = true;
            }
            else
            {
                sheet["G" + raw_index.ToString()].Value = false;
            }
            sheet["H" + raw_index.ToString()].Value = float.Parse(wbcTxtBox.Text);
            sheet["I" + raw_index.ToString()].DecimalValue = decimal.Parse(neutTxtBox.Text) / 100;
            sheet["J" + raw_index.ToString()].Value = float.Parse(lymphTxtBox.Text) / 100;
            sheet["K" + raw_index.ToString()].Value = float.Parse(rbcTxtBox.Text);
            sheet["L" + raw_index.ToString()].Value = float.Parse(hctTxtBox.Text) / 100;
            sheet["M" + raw_index.ToString()].Value = float.Parse(ureaTxtBox.Text);
            sheet["N" + raw_index.ToString()].Value = float.Parse(hbTxtBox.Text);
            sheet["O" + raw_index.ToString()].Value = float.Parse(crtnTxtBox.Text);
            sheet["P" + raw_index.ToString()].Value = float.Parse(ironTxtBox.Text);
            sheet["Q" + raw_index.ToString()].Value = float.Parse(hdlTxtBox.Text);
            sheet["R" + raw_index.ToString()].Value = float.Parse(apTxtBox.Text);
            sheet["I" + raw_index.ToString()].FormatString = "0.00%";
            sheet["J" + raw_index.ToString()].FormatString = "0.00%";
            sheet["L" + raw_index.ToString()].FormatString = "0.00%";

            workbook.SaveAs("Patients.xlsx");//save fille
            //-------------------------------------------------------------------------------------------
            //excel to patient object
            foreach (var cell in sheet["A" + raw_index.ToString() + ":R" + raw_index.ToString()])
            {
                Dashboard.alex.insert_values(cell.Text, i);
                i++;
            }
            //------------------------------------------questions --------------------------------------
            bool question = false;
            Dashboard.alex.Diagnosis();
            Dashboard.alex.questionGeneratior();
            Question[] questlist = Dashboard.alex.GetQuestions();
            for (int j = 0; j < 6; j++)
            {
                if (questlist[j] != null)
                {
                    QuestionForm qf = new QuestionForm();
                    qf.Show();
                    qf.FormClosed += delegate
                    {
                        nextpage();
                    };
                    question = true;
                    break;
                }
            }
            if (question == false)
            {
                Dashboard.alex.FinalDiagnosis();
                HashSet<string> finaldiagnosis = Dashboard.alex.GetFinalDiagnosis();
                foreach (string j in finaldiagnosis)
                {
                    sheet["S" + Dashboard.raw_index.ToString()].Value = j;
                    sheet["T" + Dashboard.raw_index.ToString()].Value = Dashboard.alex.DiagnosisToRecommendation(j);
                    Dashboard.raw_index++;
                }
                workbook.SaveAs("Patients.xlsx");
                nextpage();
            }
        }


        public void nextpage()
        {
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



        private void nameTxtBox_Leave(object sender, EventArgs e)
        {

            foreach (char c in nameTxtBox.Text)
            {
                if (c>47 && c<58)
                {
                    errorLbl.Text = "שם חייב להכיל אותיות בלבד";
                    errorLbl.Visible = true;
                    nameTxtBox.Text = "";
                    break;
                }
            }
        }

        private void nameTxtBox_Enter(object sender, EventArgs e)
        {
            errorLbl.Visible = false;
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
    }
}
