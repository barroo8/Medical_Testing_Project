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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkBook workbook = WorkBook.Load("Patients.xlsx");
            var sheet = workbook.GetWorkSheet("sheet");
            //int i = 0;
            //Patient alex = new Patient();
            //foreach (var cell in sheet["A2:K2"])
            ////a2;k2
            //{

            //    alex.insert_values(cell.Text, i);
            //    i++;
            //}
            //find open raw
            string col_index = "A";
            int raw_index = 2;
            string cell_val = "2";
            while(cell_val!= "")
            {
                label1.Text = cell_val;
                cell_val = sheet[col_index + raw_index.ToString()].ToString();
                
                raw_index++;
            }
            //-------------------------------------------------
            int i = 0;
            sheet["A" + raw_index.ToString()].Value = raw_index - 1;
            sheet["B" + raw_index.ToString()].Value = textBox1.Text;
            sheet["C" + raw_index.ToString()].Value = textBox2.Text;
            sheet["D" + raw_index.ToString()].Value = textBox3.Text;
            sheet["E" + raw_index.ToString()].Value = textBox4.Text;
            sheet["F" + raw_index.ToString()].Value = textBox5.ToString();
            sheet["G" + raw_index.ToString()].Value = textBox6.ToString();
            sheet["H" + raw_index.ToString()].Value = textBox7.ToString();
            sheet["I" + raw_index.ToString()].Value = textBox8.ToString();
            sheet["J" + raw_index.ToString()].Value = textBox9.ToString();
            sheet["K" + raw_index.ToString()].Value = textBox10.ToString();
            sheet["L" + raw_index.ToString()].Value = textBox10.ToString();
            sheet["M" + raw_index.ToString()].Value = textBox11.ToString();
            sheet["N" + raw_index.ToString()].Value = textBox12.ToString();
            sheet["O" + raw_index.ToString()].Value = textBox13.ToString();
            sheet["P" + raw_index.ToString()].Value = textBox14.ToString();
            sheet["Q" + raw_index.ToString()].Value = textBox15.ToString();
            sheet["R" + raw_index.ToString()].Value = textBox16.ToString();

            workbook.SaveAs("Patients.xlsx");



            //label1.Text = sheet["A2"].ToString();
            //foreach (var cell in sheet["A2:K2"])
            ////a2;k2
            //{

            //    alex.insert_values(cell.Text, i);
            //    i++;
            //}

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
