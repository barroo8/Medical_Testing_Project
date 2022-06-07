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
    public partial class QuestionForm : Form
    {
        int i = 0;
        bool end = false;
        public static Question[] questlist = Dashboard.alex.GetQuestions();
        public QuestionForm()
        {
            InitializeComponent();
            CenterToScreen();
            for (; i < 6; i++)
            {
                if (questlist[i] != null)
                {
                    questionLbl.Text = questlist[i].getQuestion();
                    break;
                }
            }
        }
        private void registerclickBtn_Click(object sender, EventArgs e)
        {
            if (end == false)
            {
                if (yesBtn.Checked == true)
                {
                    questlist[i].setAnswer(true);
                    yesBtn.Checked = false;
                    i++;
                }
                else if (noBtn.Checked == true)
                {
                    questlist[i].setAnswer(false);
                    noBtn.Checked = false;
                    i++;
                }
                for (; i < 6; i++)
                {
                    if (questlist[i] != null)
                    {
                        questionLbl.Text = questlist[i].getQuestion();
                        break;
                    }
                }
                if (i == 6)
                {
                    end = true;
                    questionLbl.Text = "";
                    questionGroupBox.Visible = false;
                    registerclickBtn.Text = "לדף הבא";
                }

            }
            else
            {

                Dashboard.alex.FinalDiagnosis();
                HashSet<string> finaldiagnosis = Dashboard.alex.GetFinalDiagnosis();
                WorkBook workbook = WorkBook.Load("Patients.xlsx");
                var sheet = workbook.GetWorkSheet("sheet");
                foreach (string j in finaldiagnosis)
                {
                    sheet["S" + Dashboard.raw_index.ToString()].Value = j;
                    sheet["T" + Dashboard.raw_index.ToString()].Value = Dashboard.alex.DiagnosisToRecommendation(j);
                    Dashboard.raw_index++;
                }
                workbook.SaveAs("Patients.xlsx");
                this.Close();

            }


        }
        private void QuestionForm_Load_1(object sender, EventArgs e)
        {
            this.ActiveControl = pictureBox1;
            noBtn.Checked = false;
            yesBtn.Checked = false;
        }
    }
}