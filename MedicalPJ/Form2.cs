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
            
            int raw_index = 1;
            string cell_val = "1";
            while(cell_val!= "")
            {
                raw_index++;
                cell_val = sheet["A" + raw_index.ToString()].ToString();
            }
            //-------------------------------------------------
            sheet["A" + raw_index.ToString()].Value = raw_index - 1;
            sheet["B" + raw_index.ToString()].Value = textBox1.Text;
            sheet["C" + raw_index.ToString()].Value = textBox2.Text;
            sheet["D" + raw_index.ToString()].Value = float.Parse(textBox3.Text);
            if(checkBox1.Checked == true)
            {
                sheet["E" + raw_index.ToString()].Value = true;
            }
            else
            {
                sheet["E" + raw_index.ToString()].Value = false;
            }
            if (checkBox4.Checked == true)
            {
                sheet["F" + raw_index.ToString()].Value = true;
            }
            else
            {
                sheet["F" + raw_index.ToString()].Value = false;
            }
            if (checkBox6.Checked == true)
            {
                sheet["G" + raw_index.ToString()].Value = true;
            }
            else
            {
                sheet["G" + raw_index.ToString()].Value = false;
            }
            sheet["H" + raw_index.ToString()].Value = float.Parse(textBox7.Text);
            sheet["I" + raw_index.ToString()].DecimalValue = decimal.Parse(textBox8.Text)/100;
            sheet["J" + raw_index.ToString()].Value = float.Parse(textBox9.Text)/100;
            sheet["K" + raw_index.ToString()].Value = float.Parse(textBox10.Text);
            sheet["L" + raw_index.ToString()].Value = float.Parse(textBox11.Text)/100;
            sheet["M" + raw_index.ToString()].Value = float.Parse(textBox12.Text);
            sheet["N" + raw_index.ToString()].Value = float.Parse(textBox13.Text);
            sheet["O" + raw_index.ToString()].Value = float.Parse(textBox14.Text);
            sheet["P" + raw_index.ToString()].Value = float.Parse(textBox15.Text);
            sheet["Q" + raw_index.ToString()].Value = float.Parse(textBox16.Text);
            sheet["R" + raw_index.ToString()].Value = float.Parse(textBox17.Text);
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
            label1.Text = "shpih";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox2.Checked = false;
                
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox5.Checked = false;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox3.Checked = false;

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox4.Checked = false;

            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox6.Checked = false;

            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }
        int countclick = 0;
        private void button2_Click(object sender, EventArgs e)
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
            else{
                


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
        }
    }
}
