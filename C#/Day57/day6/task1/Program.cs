using System.Security.Cryptography.X509Certificates;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region data entry
            Question[] qs = new Question[6];
            choose_one[] chone = new choose_one[6 / 3];
            choose_all[] chone_all = new choose_all[6 / 3];
            T_F[] t_F = new T_F[6 / 3];
            string[] s1 = new string[] { "1-me" };
            string[] s2 = new string[] { "2-three" };
            string[] s3 = new string[] { "2-three,3-four" };
            string[] s4 = new string[] { "1-me, 3-four" };
            string[] s5 = new string[] { "1-true" };
            string[] s6 = new string[] { "2-false" };
            //=====================================================
            Answers []answers1 = new Answers[1] ;
            answers1[0]=new Answers(s1);
            Answers[] answers2 = new Answers[1];
            answers2[0] = new Answers(s2);
            Answers[] answers3 = new Answers[1];
            answers3[0] = new Answers(s3);
            Answers[] answers4 = new Answers[1];
            answers4[0] = new Answers(s4);
            Answers[] answers5 = new Answers[1];
            answers5[0] = new Answers(s5);
            Answers[] answers6 = new Answers[1];
            answers6[0] = new Answers(s6);
            //=====================================================
            choose_one obj1 = new choose_one(1, 10, "first question of choose one", "me,he,you what is correct", Type.Choose_One, new string[] { "1-me", "2-three", "3-four" }, answers1 );
            choose_one obj2= new choose_one(2,5,"second question of choose one","me,he,you what is correct", Type.Choose_One,new string[] {"1-me", "2-three", "3-four"},answers2);
            choose_all obj3 = new choose_all(3, 10, "first question of choose all", "me,he,you what is correct", Type.Choose_All, new string[] { "1-me", "2-three", "3-four" },answers3);
            choose_all obj4 = new choose_all(4, 5, "second question of choose all", "me,he,you what is correct", Type.Choose_All, new string[] { "1-me", "2-three", "3-four" },answers4);
            T_F obj5 = new T_F(5, 10, "first question of t/f", "me,he,you what is correct", Type.True_False, new string[] { "1-true", "2-false" },answers5);
            T_F obj6 = new T_F(6, 5, "second question of t/f", "me,he,you what is correct", Type.True_False, new string[] { "1-true", "2-false" },answers6);
            //=====================================================
            qs[0] = obj1;
            qs[1] = obj2;
            qs[2] = obj3;
            qs[3] = obj4;
            qs[4] = obj5;
            qs[5] = obj6;
            //=====================================================
            chone[0] = obj1;
            chone[1] = obj2;
            chone_all[0] = obj3;
            chone_all[1] = obj4;
            t_F[0] = obj5;
            t_F[1] = obj6;
            //====================================================
            #endregion

            string x;
            do
            {
                Console.WriteLine("              a-Practical Exame           b-Final Exam");
                x = Console.ReadLine();
            } while (!(x == "a" || x == "b"));

            if (x == "a")
            {
                Console.Clear();
                Practical_exam p = new Practical_exam("2hours", 6, qs, chone_all, chone, t_F);
                p.SHOWEXAM();
            }
            else
            {
                Console.Clear();
                Final_exam f = new Final_exam("2hours", 6, qs, chone_all, chone, t_F);
                f.SHOWEXAM();
            }







            #region test
            //=====================================================test=========
            /*Exam ex1 = new Exam("2h", 6);
            ex1.ShowExam(qs,chone, chone_all,t_F);*/


            /*Practical_exam p=new Practical_exam("2h",6);
            p.ShowExam(qs, chone, chone_all, t_F);
            Console.ReadLine();
            Console.Clear();
            Final_exam f = new Final_exam("3h", 6);
            f.ShowExam(qs, chone, chone_all, t_F);*/


            /* Console.WriteLine("============================================");
             for (int i = 0; i < 6; i++)
             {
                 Console.WriteLine(qs[i]);
             }
             Console.WriteLine("============================================");
             for (int i = 0; i < 6; i++)
             {
                 Console.WriteLine(answers[i].ToString());
             }
            */

            /*Exam ex1= new Exam("2h",6,qs,chone_all,chone,t_F);
            ex1.show();*/
            #endregion






        }
    }
}