using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPJ
{
    public class Patient
    {
        public string name;
        public string last_name;
        public int id;
        public float age;
        public bool ethiopian;
        public bool east;
        public bool gender;//male - true || female - false
        public float ap;
        public float hdl;
        public float iron;
        public float crtn;
        public float hb;
        public float urea;
        public float hct;//precent
        public float rbc;
        public float lymph;//precent
        public float neut;
        public float wbc;
        int[] first_diagnos;
        Question[] question_lst;
        HashSet<string> finaldiagnosis;
        public Patient()
        {
            id = 0;
            name = "";
            last_name = "";
            age = 0;
            ethiopian = false;
            east = false;
            gender = false;
            ap = 0;
            hdl = 0;
            iron = 0;
            crtn = 0;
            hb = 0;
            urea = 0;
            hct = 0;
            rbc = 0;
            lymph = 0;
            neut = 0;
            wbc = 0;
            


        }

        public void insert_values(string value, int index)
        {
            switch (index)
            {
                case 0:
                    id = int.Parse(value);
                    break;
                case 1:
                    name = value;
                    break;
                case 2:
                    last_name = value;
                    break;
                case 3:
                    age = float.Parse(value);
                    break;
                case 4:
                    if (value == "False")
                    {
                        gender = false;
                    }
                    else
                    {
                        gender = true;
                    }
                    break;
                case 5:
                    if (value == "False")
                    {
                        east = false;
                    }
                    else
                    {
                        east = true;
                    }
                    break;
                case 6:
                    if (value == "False")
                    {
                        ethiopian = false;
                    }
                    else
                    {
                        ethiopian = true;
                    }
                    break;
                case 7:
                    wbc = float.Parse(value);
                    break;
                case 8:
                    neut = precentStrToFloat(value);
                    break;
                case 9:
                    lymph = precentStrToFloat(value);
                    break;
                case 10:
                    rbc = float.Parse(value);
                    break;
                case 11:
                    hct = precentStrToFloat(value);
                    break;
                case 12:
                    urea = float.Parse(value);
                    break;
                case 13:
                    hb = float.Parse(value);
                    break;
                case 14:
                    crtn = float.Parse(value);
                    break;
                case 15:
                    iron = float.Parse(value);
                    break;
                case 16:
                    hdl = float.Parse(value);
                    break;
                case 17:
                    ap = float.Parse(value);
                    break;
            }
        }
        public void Diagnosis()
        //return array with diagnos [wbc,neut,lymph,RBC,hct,Urea,hb,Crtn,iron,hdl,ap]
        {
            this.first_diagnos = new int[11];// each one 0 - ok | 1 - high | -1 - low
            //wbc
            if ((age >= 18 && wbc > 11000) || (age < 18 && age >= 4 && wbc > 15500) || (age < 4 && age >= 0 && wbc > 17500))
            {
                first_diagnos[0] = 1;
            }
            else if ((age >= 18 && wbc < 4500) || (age < 18 && age >= 4 && wbc < 5500) || (age < 4 && age >= 0 && wbc < 6000))
            {
                first_diagnos[0] = -1;
            }
            else
            {
                first_diagnos[0] = 0;
            }

            //neut
            if (neut > 54)
            {
                first_diagnos[1] = 1;
            }
            else if (neut < 28)
            {
                first_diagnos[1] = -1;
            }
            else
            {
                first_diagnos[1] = 0;
            }
            //lymph
            if (lymph > 52)
            {
                first_diagnos[2] = 1;
            }
            else if (lymph < 36)
            {
                first_diagnos[2] = -1;
            }
            else
            {
                first_diagnos[2] = 0;
            }
            //RBC
            if (rbc > 6)
            {
                first_diagnos[3] = 1;
            }
            else if (rbc < 4.5)
            {
                first_diagnos[3] = -1;
            }
            else
            {
                first_diagnos[3] = 0;
            }
            //hct
            if ((gender == true && hct > 54) || (gender == false && hct > 47))
            {
                first_diagnos[4] = 1;
            }
            else if ((gender == true && hct < 37) || (gender == false && hct < 33))
            {
                first_diagnos[4] = -1;
            }
            else
            {
                first_diagnos[4] = 0;
            }
            //Urea
            if ((east == true && urea > 47.3) || (east == false && urea > 43))
            {
                first_diagnos[5] = 1;
            }
            else if (urea < 17)
            {
                first_diagnos[5] = -1;
            }
            else
            {
                first_diagnos[5] = 0;
            }
            //Hemoglobin / hb
            if ((age > 17 && gender == true && hb > 18) || (age > 17 && gender == false && hb > 16) || (age < 18 && hb > 15.5))
            {
                first_diagnos[6] = 1;
            }
            else if ((age > 17 && hb < 12) || (age < 18 && hb < 11.5))
            {
                first_diagnos[6] = -1;
            }
            else
            {
                first_diagnos[6] = 0;
            }
            //Crtn
            if ((age >= 0 && age < 3 && crtn > 0.5) || (age >= 3 && age < 60 && crtn > 1) || (age >= 60 && crtn > 1.2))
            {
                first_diagnos[7] = 1;
            }
            else if ((age >= 0 && age < 3 && crtn < 0.2) || (age >= 3 && age < 18 && crtn < 0.5)
                || (age >= 18 && crtn < 0.6))
            {
                first_diagnos[7] = -1;
            }
            else
            {
                first_diagnos[7] = 0;
            }
            //iron
            if ((gender == true && iron > 160) || (gender == false && iron > (160 * 0.2)))
            {
                first_diagnos[8] = 1;
            }
            else if ((gender == true && iron < 60) || (gender == false && iron < (60 * 0.2)))
            {
                first_diagnos[8] = -1;
            }
            else
            {
                first_diagnos[8] = 0;
            }
            //hdl
            if ((gender == true && ethiopian == true && hdl > (62 * 1.2)) || (gender == false && ethiopian == true && hdl > (82 * 1.2))
                || (gender == true && ethiopian == false && hdl > 62) || (gender == false && ethiopian == false && hdl > 82))
            {
                first_diagnos[9] = 1;
            }
            else if ((gender == true && ethiopian == true && hdl < (29 * 1.2)) || (gender == false && ethiopian == true && hdl < (34 * 1.2))
                || (gender == true && ethiopian == false && hdl < 29) || (gender == false && ethiopian == false && hdl < 34))
            {
                first_diagnos[9] = -1;
            }
            else
            {
                first_diagnos[9] = 0;
            }
            //ap
            if ((east == true && ap > 120) || (east == false && ap > 90))
            {
                first_diagnos[10] = 1;
            }
            else if ((east == true && ap < 60) || (east == false && ap < 30))
            {
                first_diagnos[10] = -1;
            }
            else
            {
                first_diagnos[10] = 0;
            }
        }
        private float precentStrToFloat(string value)
        {
            return float.Parse(value) * 100;
        }
        public void questionGeneratior()
        //  [wbc, neut, lymph, RBC, hct, Urea, hb, Crtn, iron, hdl, ap]
        //  [0,     1,     2,    3,   4,   5,   6,   7,    8,   9,  10]
        {
            question_lst = new Question[6];
            //[הריון , דיאטת דלת חלבון , דיאטת עתירת חלבון ,מחלת ריאות , מעשן ,מחלת חום]
            //[     0  ,    1  ,        2   ,       3            ,      4           ,   5   ]
            if (first_diagnos[0] == 1)
            {
                question_lst[0] = new Question("?האם המטופל חולה במחלת חום");
            }
            if (first_diagnos[3] == 1 || first_diagnos[4] == 1)
            {
                question_lst[1] = new Question("?האם המטופל/ת מעשן");
            }
            if (first_diagnos[3] == 1) { 
                question_lst[2] = new Question("?האם המטופל/ת חולה במחלת ריאות");
            }
            if (first_diagnos[5] == 1) { 
                question_lst[3] = new Question("האם המטופל/ת בדיאטה עתירת חלבונים ");
            }
            if (first_diagnos[5] == -1)
            {
                question_lst[4] = new Question("האם המטופל/ת בדיאטה דלת חלבון ");
                if (this.gender == false)
                {
                    question_lst[5] = new Question("?האם המטופלת בהריון");
                }
            }
            if (first_diagnos[10] == 1 && this.gender == false )
            {
                question_lst[5] = new Question("?האם המטופלת בהריון");
            }
        }
        public void FinalDiagnosis()
        {

            finaldiagnosis = new HashSet<string>();
            //WBC
            //[הריון , דיאטת דלת חלבון , דיאטת עתירת חלבון ,מחלת ריאות , מעשן ,מחלת חום]
            //[     0  ,    1  ,        2   ,       3            ,      4           ,   5   ]
            if (first_diagnos[0] == 1 && question_lst[0].getAnswer())
                finaldiagnosis.Add("זיהום");
            else if (first_diagnos[0] == 1 && question_lst[0].getAnswer() == false)
            {
                finaldiagnosis.Add("מחלת דם");
                finaldiagnosis.Add("סרטן");
            }
            else if (first_diagnos[0] == -1)
            {
                finaldiagnosis.Add("מחלה ויראלית");
                finaldiagnosis.Add("סרטן");
            }
            //Neut
            if (first_diagnos[1] == 1)
                finaldiagnosis.Add("זיהום");
            else if (first_diagnos[1] == -1)
            {
                finaldiagnosis.Add("הפרעה ביצירת הדם");
                finaldiagnosis.Add("זיהום");
                finaldiagnosis.Add("סרטן");
            }
            //Lymph
            if (first_diagnos[2] == 1)
                finaldiagnosis.Add("הפרעה ביצירת הדם");
            else if (first_diagnos[2] == -1)
            {
                finaldiagnosis.Add("זיהום");
                finaldiagnosis.Add("סרטן");
            }
            //RBC
            if (first_diagnos[3] == 1)
            {
                finaldiagnosis.Add("הפרעה ביצירת הדם");
                if (question_lst[1].getAnswer())
                {
                    finaldiagnosis.Add("מעשנים");
                    if (question_lst[2].getAnswer())
                    {
                        finaldiagnosis.Add("מחלת ריאות");
                    }

                }
                else
                {
                    if (question_lst[2].getAnswer())
                        finaldiagnosis.Add("מחלת ריאות");
                }
            }
            else if (first_diagnos[3] == -1)
            {
                finaldiagnosis.Add("אנמיה");
                finaldiagnosis.Add("דימום");
            }
            //hct
            if (first_diagnos[4] == 1 && question_lst[1].getAnswer())
                finaldiagnosis.Add("מעשנים");
            else if (first_diagnos[4] == -1)
            {
                finaldiagnosis.Add("אנמיה");
                finaldiagnosis.Add("דימום");
            }
            //Urea
            if (first_diagnos[5] == 1)
            {
                if (question_lst[3].getAnswer())
                    finaldiagnosis.Add("דיאטה");
                else
                {
                    finaldiagnosis.Add("מחלת כליה");
                    finaldiagnosis.Add("התייבשות");
                }
            }
            else if (first_diagnos[5] == -1)
            {
                if (question_lst[4].getAnswer())
                    finaldiagnosis.Add("דיאטה");
                else
                {
                    if (this.gender == false)
                        if (!question_lst[5].getAnswer())
                        {
                            finaldiagnosis.Add("תת תזונה");
                            finaldiagnosis.Add("מחלות כבד");
                        }
                }
            }
            //hb
            if (first_diagnos[6] == -1)
            {
                finaldiagnosis.Add("אנמיה");
                finaldiagnosis.Add("הפרעה המטולוגית");
            }
            //ctrn
            if (first_diagnos[7] == 1)
            {
                finaldiagnosis.Add("מחלת כליה");
                finaldiagnosis.Add("מחלות שריר");
                finaldiagnosis.Add("צריכה מוגברת של בשר");
            }
            else if (first_diagnos[7] == -1)
                finaldiagnosis.Add("תת תזונה");
            //Iron
            if (first_diagnos[8] == 1)
                finaldiagnosis.Add("הרעלת ברזל");
            if (first_diagnos[8] == -1)
                finaldiagnosis.Add("דימום");
            //HDL
            if (first_diagnos[9] == -1)
            {
                finaldiagnosis.Add("מחלות לב");
                finaldiagnosis.Add("היפרליפידמיה");
                finaldiagnosis.Add("סוכרת מבוגרים");
            }
            //ap
            if (first_diagnos[10] == 1)
            {
                if (this.gender == false)
                {
                    if (question_lst[5].getAnswer() == false)
                    {
                        finaldiagnosis.Add("מחלות כבד");
                        finaldiagnosis.Add("מחלות בדרכי המרה");
                        finaldiagnosis.Add("שימוש בתרופות שונות");
                        finaldiagnosis.Add("פעילות יתר של בלוטת התריס");
                    }
                }
                else
                {
                    finaldiagnosis.Add("מחלות כבד");
                    finaldiagnosis.Add("מחלות בדרכי המרה");
                    finaldiagnosis.Add("שימוש בתרופות שונות");
                    finaldiagnosis.Add("פעילות יתר של בלוטת התריס");
                }

            }
            else if (first_diagnos[10] == -1)
            {
                finaldiagnosis.Add("דיאטה");
                finaldiagnosis.Add("חוסר בוויטמינים");
            }
            if (finaldiagnosis.Count() == 0)
            {
                finaldiagnosis.Add("הכל תקין");
            }
            
        }
        //  [wbc, neut, lymph, RBC, hct, Urea, hb, Crtn, iron, hdl, ap]
        //  [0,     1,     2,    3,   4,   5,   6,   7,    8,   9,  10]


        public Dictionary<string, string> DictDiagnos()
        {
            Dictionary<string, string> dictdiagnos = new Dictionary<string, string>();
            foreach (string j in finaldiagnosis)
            {
                dictdiagnos.Add(j, DiagnosisToRecommendation(j));
            }
            return dictdiagnos;
        }
        public Question[] GetQuestions() { return question_lst; }
        public HashSet<string> GetFinalDiagnosis() { return finaldiagnosis; }
        public int[] GetFirstDiagnosis() { return first_diagnos; }
        public float[] normolizevalues()
        {
            float[] normal_values = new float[11];
            normal_values[0] = (wbc - 11000) / 6500;
            normal_values[1] = (neut - 41) / 13;
            normal_values[2] = (lymph - 44) / 8;
            normal_values[3] = (rbc - 5.25F) / 0.75F;
            normal_values[4] = (hct - 43.5F) / 10.5F;
            normal_values[5] = (urea - 32) / 15;
            normal_values[6] = (hb - 14.5F) / 3.25F;
            normal_values[7] = (crtn - 0.7F) / 0.5F;
            normal_values[8] = (iron - 104) / 56;
            normal_values[9] = (hdl - 64.5F) / 35.5F;
            normal_values[10] = (ap - 75) / 45;
            
            for (int i = 0; i < 11; i++)
            {
                if(this.GetFirstDiagnosis()[i]==1)
                    normal_values[i] += 4;
                else if(this.GetFirstDiagnosis()[i] == -1)
                    normal_values[i] -= 4;
            }
            float min = normal_values.Min();
            if (min < 0)
            {
                min *= -1;
                for (int i = 0; i < 11; i++)
                {
                    normal_values[i] += min+ 0.1F;
                }
            }

            return normal_values;
        }
        public string DiagnosisToRecommendation(string diagnosis)
        {
            switch (diagnosis)
            {
                case "אנמיה":
                    return "שני כדורי 10 מ''ג של" + " B12 " + "ביום למשך חודש";
                case "דיאטה":
                    return "לתאם פגישה עם תזונאי";
                case "דימום":
                    return "להתפנות בדחיפות לבית החולים";
                case "היפרליפידמיה":
                    return "לתאם פגישה עם תזונאי, כדור 5 מ''ג של סימוביל ביום למשך שבוע";
                case "הפרעה ביצירת הדם":
                    return "כדור 10 מ''ג של" + " B12 " + "ביום למשך חודש" + " כדור 5 מ''ג של פולית ביום למשך חודש";
                case "הפרעה המטולוגית":
                    return "זריקה של הורמון לעידוד ייצור תאי הדם האדומים";
                case "הרעלת ברזל":
                    return "להתפנות לבית החולים";
                case "התייבשות":
                    return "למנוחה מוחלטת בשכיבה, החזרת נוזלים בשתייה";
                case "זיהום":
                    return "אנטיביוטיקה ייעודית";
                case "חוסר בוויטמינים":
                    return " הפנייה לבדיקת דם לזיהוי הוויטמינים החסרים";
                case "מחלה ויראלית":
                    return "לנוח בבית";
                case "מחלות בדרכי המרה":
                    return "הפנייה לטיפול כירורגי";
                case "מחלות לב":
                    return "לתאם פגישה עם תזונאי";
                case "מחלת דם":
                    return "שילוב של ציקלופוספאמיד וקורטיקוסרואידים";
                case "מחלות כבד":
                    return "הפנייה לאבחנה ספציפית לצורך קביעת טיפולי";
                case "מחלת כליה":
                    return "איזון את רמות הסוכר בדם";
                case "מחסור בברזל":
                    return "שני כדורי 10 מ''ג של" + " B12 " + "ביום למשך חודש";
                case "מחלות שריר":
                    return "שני כדורי 5 מ''ג של כורכום" + " C3 " + "של אלטמן ביום למשך חודש";
                case "מעשנים":
                    return "להפסיק לעשן";
                case "מחלת ריאות":
                    return "להפסיק לעשן / הפנייה לצילום רנטגן של הריאות";
                case "פעילות יתר של בלוטת התריס":
                    return "Propylthiouracil " + "להקטנת פעילות בלוטת התריס";
                case "סוכרת מבוגרים":
                    return "התאמת אינסולין למטופל";
                case "סרטן":
                    return " אנטרקטיניב";
                case "צריכה מוגברת של בשר":
                    return "לתאם פגישה עם תזונאי";
                case "שימוש בתרופות שונות":
                    return "פנייה לרופא המשפחה לצורך בדיקת התאמה בין התרופות";
                case "תת תזונה":
                    return "לתאם פגישה עם תזונאי";
                case "הכל תקין":
                    return "תהיה בריא";
                default:
                    return "טעות";
            }
        }
    }
}