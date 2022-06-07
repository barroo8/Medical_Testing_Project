using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MedicalPJ
{
    public partial class DiagnoseForm : Form
    {
        public DiagnoseForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void DiagnoseForm_Load(object sender, EventArgs e)
        {

            Dictionary<string, string> dic = Dashboard.alex.DictDiagnos();

            DataTable dt = new DataTable();
            dt.Columns.Add("טיפול מומלץ");
            dt.Columns.Add("מחלה / בעיה");


            foreach (KeyValuePair<string, string> entry in dic)
            {
                dt.Rows.Add(entry.Value, entry.Key);
            }

            dataGridView1.DataSource = dt;
            int columnCount = dataGridView1.Columns.Count;
            int lastColumnIndex = columnCount - 1;
            //dataGridView1.Height -= 100;
            
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index == columnCount - lastColumnIndex)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            this.Height -= 100;
            dataGridView1.ScrollBars = ScrollBars.Both;
        }

    }
}
