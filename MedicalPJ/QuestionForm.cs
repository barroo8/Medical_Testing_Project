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
    public partial class QuestionForm : Form
    {
        int i = 0;
        Question[] questlist = Form2.alex.questionGeneratior(Form2.alex.Diagnosis());
        public QuestionForm()
        {
            InitializeComponent();
            
            questionLbl.Text = questlist[0].getQuestion();
        }


        private void registerclickBtn_Click(object sender, EventArgs e)
        {
            if(yesBtn.Checked ==true)
            {
                questlist[i].setAnswer(true);
            }
            else if(noBtn.Checked == true)
            {
                questlist[i].setAnswer(false);
            }

            if (questlist[i + 1] != null)
            {
                questionLbl.Text = questlist[i+1].getQuestion();
            }
            else
            {
                this.Dispose();
            }
        }


    }
}
