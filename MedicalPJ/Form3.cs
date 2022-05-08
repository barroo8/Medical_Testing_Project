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
                    //richTextBox1.LoadFile(fileNames[0]);
                    WorkBook workbook = WorkBook.Load(fileNames[0]);
                    var sheet = workbook.GetWorkSheet("sheet");
                    label1.Text = sheet["A2"].ToString();
                }
            }
        }
    }
}
