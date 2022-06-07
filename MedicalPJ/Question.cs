using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPJ
{
    public class Question
    {
        string question;
        bool answer;
        public Question()
        {
            question = "";
        }
        public Question(string new_question)
        {
            question = new_question;
        }
        public void setAnswer(bool new_answer)
        {
            answer = new_answer;
        }
        public string getQuestion() { return question; }
        public bool getAnswer() { return answer; }

    }
}
