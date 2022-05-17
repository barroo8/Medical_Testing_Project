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
        Patient alex = new Patient();
        int raw_index = 1;
        float[] madadim = new float[11];
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            richTextBox1.AllowDrop = true;
            richTextBox1.DragDrop += RichTextBox1_DragDrop;
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data!= null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0) {
                    label1.Text = fileNames[0];
                    WorkBook workbook = WorkBook.Load(fileNames[0]);
                    var sheet = workbook.GetWorkSheet("sheet");
                    Char x = 'A';
                    for (int i =0; i < 11; i++)
                    {
                        madadim[i] = float.Parse(sheet[x.ToString() + "2"].ToString());
                        x = (Char)(Convert.ToUInt16(x) + 1);
                        
                    }
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkBook workbook = WorkBook.Load("Patients.xlsx");
            var sheet = workbook.GetWorkSheet("sheet");
            int i = 0;

            string cell_val = "1";
            while (cell_val != "")
            {
                raw_index++;
                cell_val = sheet["S" + raw_index.ToString()].ToString();
            }
            //-------------------------------------------------
            sheet["A" + raw_index.ToString()].Value = raw_index - 1;
            sheet["B" + raw_index.ToString()].Value = textBox1.Text;
            sheet["C" + raw_index.ToString()].Value = textBox2.Text;
            sheet["D" + raw_index.ToString()].Value = float.Parse(textBox3.Text);
            if (checkBox1.Checked == true)
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
            Char x = 'H';
            for (i = 0; i < 11; i++)
            {
                if (x == 'I' || x == 'J' || x == 'L')
                {
                    sheet[x.ToString() + raw_index.ToString()].Value = madadim[i]/100;
                    sheet[x.ToString() + raw_index.ToString()].FormatString = "0.00%";
                }
                else
                { 
                    sheet[x.ToString() + raw_index.ToString()].Value= madadim[i];
                }
                x = (Char)(Convert.ToUInt16(x) + 1);
                
            }
            workbook.SaveAs("Patients.xlsx");

            //excel to object
            i = 0;
            foreach (var cell in sheet["A" + raw_index.ToString() + ":R" + raw_index.ToString()])
            ////a2;k2
            {

                alex.insert_values(cell.Text, i);
                i++;
            }
        }
    }
}
