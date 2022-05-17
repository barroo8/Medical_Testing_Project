using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPJ
{
    class Question
    {
        string question;
        string symptom;
        bool answer;
        public Question()
        {
            question = "";
        }
        public Question(string new_question, string new_symptom)
        {
            question = new_question;
            symptom = new_symptom;
        }
        public void setAnswer(bool new_answer)
        {
            answer = new_answer;
        }
        public string getQuestion() { return question; }
        public bool getAnswer() { return answer; }

    }
}
