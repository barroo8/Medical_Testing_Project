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
        Patient alex = new Patient();
        int raw_index = 1;
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

            foreach(TextBox t in textBoxes)
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
                        isDot+=1;
                    }

                    if ((c < 47 && c!=46) || isDot > 1 || c > 58)
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

            WorkBook workbook = WorkBook.Load("Patients.xlsx");
            var sheet = workbook.GetWorkSheet("sheet");
            int i = 0;
            
            int raw_index = 1;
            string cell_val = "1";
            while(cell_val!= "")
            {
                raw_index++;
                cell_val = sheet["S" + raw_index.ToString()].ToString();
            }
            //-------------------------------------------------
            sheet["A" + raw_index.ToString()].Value = raw_index - 1;
            sheet["B" + raw_index.ToString()].Value = nameTxtBox.Text;
            sheet["C" + raw_index.ToString()].Value = lastnameTxtBox.Text;
            sheet["D" + raw_index.ToString()].Value = float.Parse(ageTxtBox.Text);
            if(maleRBtn.Checked == true)
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
            sheet["I" + raw_index.ToString()].DecimalValue = decimal.Parse(neutTxtBox.Text)/100;
            sheet["J" + raw_index.ToString()].Value = float.Parse(lymphTxtBox.Text)/100;
            sheet["K" + raw_index.ToString()].Value = float.Parse(rbcTxtBox.Text);
            sheet["L" + raw_index.ToString()].Value = float.Parse(hctTxtBox.Text)/100;
            sheet["M" + raw_index.ToString()].Value = float.Parse(ureaTxtBox.Text);
            sheet["N" + raw_index.ToString()].Value = float.Parse(hbTxtBox.Text);
            sheet["O" + raw_index.ToString()].Value = float.Parse(crtnTxtBox.Text);
            sheet["P" + raw_index.ToString()].Value = float.Parse(ironTxtBox.Text);
            sheet["Q" + raw_index.ToString()].Value = float.Parse(hdlTxtBox.Text);
            sheet["R" + raw_index.ToString()].Value = float.Parse(apTxtBox.Text);
            sheet["I" + raw_index.ToString()].FormatString = "0.00%";
            sheet["J" + raw_index.ToString()].FormatString = "0.00%";
            sheet["L" + raw_index.ToString()].FormatString = "0.00%";


            workbook.SaveAs("Patients.xlsx");



            //excel to object
            foreach (var cell in sheet["A"+ raw_index.ToString() + ":R"+ raw_index.ToString()])
            ////a2;k2
            {

                alex.insert_values(cell.Text, i);
                i++;
            }
            int[] analasis = alex.Diagnosis();
            //present diagnos
            label39.Text = analsys(analasis[0]);
            label38.Text = analsys(analasis[1]);
            label37.Text = analsys(analasis[2]);
            label36.Text = analsys(analasis[3]);
            label35.Text = analsys(analasis[4]);
            label34.Text = analsys(analasis[5]);
            label33.Text = analsys(analasis[6]);
            label32.Text = analsys(analasis[7]);
            label31.Text = analsys(analasis[8]);
            label30.Text = analsys(analasis[9]);
            label29.Text = analsys(analasis[10]);
            Question[] question_lst = alex.questionGeneratior(analasis);
            i = 0;
            //while (question_lst[i] != null)
            //{
            //label40.Text = question_lst[0].getQuestion();
            //label33.Text = question_lst[1].getQuestion();
            //if (question_lst[2] != null)
            //{
            //    label32.Text = question_lst[2].getQuestion();
            //    label31.Text = question_lst[3].getQuestion();
            //    label30.Text = question_lst[4].getQuestion();
            //    label29.Text = question_lst[5].getQuestion();
            //}
            label1_Click(sender,e)  ;
            

            //}

        }
        private string analsys(int num)
        {
            if (num == 0)
                return "תקין";
            else if (num == 1)
                return "גבוה";
            else
                return "נמוך";
        }
        private void answers(Question[] lst)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
            nameLbl.Text = "shpih";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

/*        private bool isCellEmpty()
        {
            if (nameTxtBox.Text == "" || lastnameTxtBox.Text == "" || nameTxtBox.Text == "" ||)
        }*/

        int countclick = 0;

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

        private void neutTxtBox_TextChanged(object sender, EventArgs e)
        {

        }





        /*        private void button2_Click(object sender, EventArgs e)
                {
                    Question[] question_lst = alex.questionGeneratior(alex.Diagnosis());

                    button2.Text = "הגש";
                    if (question_lst[countclick] == null)
                    {
                        button2.Text = "לעמוד הבא";
                        button2.Enabled = false;

                    }
                    else if (countclick == 0)
                    {
                        label40.Text = question_lst[countclick].getQuestion();
                        countclick++;
                    }
                    else
                    {
                        if (checkBox8.Checked == true)
                        {
                            question_lst[countclick - 1].setAnswer(true);
                            checkBox8.Checked = false;
                            countclick++;
                        }
                        if (checkBox7.Checked == true)
                        {
                            question_lst[countclick - 1].setAnswer(false);
                            checkBox7.Checked = false;
                            countclick++;
                        }
                        label40.Text = question_lst[countclick-1].getQuestion();
                    }
                }*/
    }
}
