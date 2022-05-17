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
        Patient alex = new Patient();
        int raw_index = 1;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            WorkBook workbook = WorkBook.Load("Patients.xlsx");
            var sheet = workbook.GetWorkSheet("sheet");
            int i = 0;
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

            label1_Click(sender,e)  ;

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
     /*
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
