﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;

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
        public float lymph;//precenr
        public float neut;
        public float wbc;
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
        public int[] Diagnosis()
        //return array with diagnos [wbc,neut,lymph,RBC,hct,Urea,hb,Crtn,iron,hdl,ap]
        {
            int[] first_diagnos = new int[11];// each one 0 - ok | 1 - high | -1 - low
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
            return first_diagnos;
        }
        private float precentStrToFloat(string value)
        {
            return float.Parse(value) * 100;
        }
        public Question[] questionGeneratior(int[] diagnos)
        //  [wbc, neut, lymph, RBC, hct, Urea, hb, Crtn, iron, hdl, ap]
        //  [0,     1,     2,    3,   4,   5,   6,   7,    8,   9,  10]
        {
            Question[] question_lst = new Question[7];
            int j = 0;
            if (diagnos[0] == 1)
            {
                question_lst[j] = new Question("?האם קיימת מחלת חום", "wbc : +");
                j++;
            }
            if (diagnos[3] == 1)
            {
                question_lst[j] = new Question("האם את.ה מעשן", "rbc : +");
                j++;
                question_lst[j] = new Question(" חולה במחלת ריאות", "rbc : +");
                j++;
            }
            if (diagnos[4] == 1)
            {
                question_lst[j] = new Question("האם את.ה מעשן ", "hct : +");
                j++;
            }
            if (diagnos[5] == 1)
            {
                question_lst[j] = new Question("האם את.ה בדיאטה עתירת חלבונים ", "urea : +");
                j++;
            }
            if (diagnos[5] == -1)
            {
                question_lst[j] = new Question("האם את.ה בדיאטה דלת חלבון ", "urea : -");
                j++;
                question_lst[j] = new Question("האם את בהריון ", "urea : -");
                j++;
            }
            return question_lst;
        }
        public HashSet<string> FinalDiagnosis(int[] diagnos, Question[] questions)
        {

            HashSet<string> finaldiagnosis = new HashSet<string>();
            int i = 0;
            //WBC
            if (diagnos[0] == 1 && questions[i].getAnswer())
            {
                finaldiagnosis.Add("זיהום");
                i++;
            }
            else if (diagnos[0] == 1 && questions[i].getAnswer() == false)
            {
                finaldiagnosis.Add("מחלת דם");
                finaldiagnosis.Add("סרטן");
                i++;
            }
            else if (diagnos[0] == -1)
            {
                finaldiagnosis.Add("מחלה ויראלית");
                finaldiagnosis.Add("סרטן");

            }
            //Neut
            if (diagnos[1] == 1)
            {
                finaldiagnosis.Add("זיהום");
            }
            else if (diagnos[1] == -1)
            {
                finaldiagnosis.Add("הפרעה ביצירת הדם");
                finaldiagnosis.Add("זיהום");
                finaldiagnosis.Add("סרטן");
            }
            //Lymph
            if (diagnos[2] == 1)
            {
                finaldiagnosis.Add("הפרעה ביצירת הדם");
            }
            else if (diagnos[2] == -1)
            {
                finaldiagnosis.Add("זיהום");
                finaldiagnosis.Add("סרטן");
            }
            //RBC
            if (diagnos[3] == 1)
            {
                finaldiagnosis.Add("הפרעה ביצירת הדם");
                if (questions[i].getAnswer())
                {
                    finaldiagnosis.Add("מעשנים");
                    i++;
                    if (questions[i].getAnswer())
                    {
                        finaldiagnosis.Add("מחלת ריאות");
                        i++;
                    }
                    else
                        i++;
                }
                else
                {
                    i++;
                    if (questions[i].getAnswer())
                    {
                        finaldiagnosis.Add("מחלת ריאות");
                        i++;
                    }
                    else
                        i++;
                }
            }
            else if (diagnos[3] == -1)
            {
                finaldiagnosis.Add("אנמיה");
                finaldiagnosis.Add("דימום");
            }
            //hct
            if (diagnos[4] == 1 && questions[i].getAnswer())
            {
                finaldiagnosis.Add("מעשנים");
                i++;
            }
            else if (diagnos[4] == -1)
            {
                finaldiagnosis.Add("אנמיה");
                finaldiagnosis.Add("דימום");
            }
            //Urea
            if (diagnos[5] == 1)
            {
                if (questions[i].getAnswer())
                {
                    finaldiagnosis.Add("דיאטה");
                    i++;
                }
                else
                {
                    i++;
                    finaldiagnosis.Add("מחלה כליה");
                    finaldiagnosis.Add("התייבשות");
                }
            }
            else if (diagnos[5] == -1)
            {
                if (questions[i].getAnswer())
                {
                    i++;
                    finaldiagnosis.Add("דיאטה");
                }
                else
                {
                    i++;
                    if (questions[i].getAnswer())
                    {
                        i++;
                    }
                    else
                    {
                        i++;
                        finaldiagnosis.Add("תת תזונה");
                        finaldiagnosis.Add("מחלת כבד");
                    }
                }
            }
            //hb
            if (diagnos[6] == -1)
            {
                finaldiagnosis.Add("אנמיה");
                finaldiagnosis.Add("הפרעה המטולוגית");
            }
            //ctrn
            if (diagnos[7] == 1)
            {
                finaldiagnosis.Add("מחלת כליה");
                finaldiagnosis.Add("מחלות שריר");
                finaldiagnosis.Add("צריכה מוגברת של בשר");
            }
            else if (diagnos[7] == -1)
            {
                finaldiagnosis.Add("תת תזונה");
            }
            //Iron
            if (diagnos[8] == 1)
            {
                finaldiagnosis.Add("הרעלת ברזל");
            }
            if (diagnos[8] == -1)
            {
                finaldiagnosis.Add("דימום");
            }
            //HDL
            if (diagnos[9] == -1)
            {
                finaldiagnosis.Add("מחלות לב");
                finaldiagnosis.Add("היפרליפידמיה");
                finaldiagnosis.Add("סוכרת מבוגרים");
            }
            //ap
            if (diagnos[10] == 1)
            {
                finaldiagnosis.Add("מחלות כבד");
                finaldiagnosis.Add("מחלות בדרכי המרה");
                finaldiagnosis.Add("שימוש בתרופות שונות");
                finaldiagnosis.Add("פעילות יתר של בלוטת התריס");
            }
            else if (diagnos[10] == -1)
            {
                finaldiagnosis.Add("דיאטה");
                finaldiagnosis.Add("חוסר בוויטמינים");
            }
            return finaldiagnosis;
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
                    return " הפנייה לאבחנה ספציפית לצורך קביעת טיפולי";
                case "מחלה כליה":
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
                    return "Propylthiouracil" + "להקטנת פעילות בלוטת התריס";
                case "סוכרת מבוגרים":
                    return "התאמת אינסולין למטופל";
                case "סרטן":
                    return " אנטרקטיניב ";
                case "צריכה מוגברת של בשר":
                    return "לתאם פגישה עם תזונאי";
                case "שימוש בתרופות שונות":
                    return "פנייה לרופא המשפחה לצורך בדיקת התאמה בין התרופות";
                case "תת תזונה":
                    return "לתאם פגישה עם תזונאי";
                default:
                    return "טעות";
            }
        }
    }
}
