using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            //AnswersList answer1 = new();
            //AnswersList answer2 = new();
            //AnswersList answer3 = new();
            //AnswersList answer4 = new();
            //AnswersList answer5 = new();
            //AnswersList answer6 = new();

            //answer1.Add(new Answers(new string[] { "1-me"}));//model answer
            //answer2.Add(new Answers(new string[] { "2-three" }));
            //answer3.Add(new Answers(new string[] { "2-three,3-four" }));
            //answer4.Add(new Answers(new string[] { "1-me,3-four" }));
            //answer5.Add(new Answers(new string[] { "1-true" }));
            //answer6.Add(new Answers(new string[] { "2-false" }));
            //Console.WriteLine(answer3[0].answer[0]);
            /*

 
             */

            //=====================================================
            choose_one obj1 = new choose_one(1, 10, "First Question of Choose One", "which phase of complier is sentiment analysis", Type.Choose_One, new string[] { "a.First", "b.Second", "c.Third", "d.None" }, "d.None");
            choose_one obj2= new choose_one(2,5,"Second Question of Choose One", " From where does syntax analysis take its input?", Type.Choose_One,new string[] { "a.Lexical analyzer", "b.Sentiment analyzer", "c.Syntactic analyzer", "d.None" }, "a.Lexical analyzer");
            choose_all obj3 = new choose_all(3, 10, "First Question of Choose All The Correct", "A compiler can check.... ", Type.Choose_All, new string[] { "a.Logical error", "b.Syntax error", "d.Non logical and syntax error" }, "a.Logical error,b.Syntax error");
            choose_all obj4 = new choose_all(4, 5, "Second Question of Choose All The Correct", "A monitor is a module that encapsulates", Type.Choose_All, new string[] { "a.shared data structures", "b.procedures that operate on shared data structure", "c.synchronization between concurrent procedure invocation" }, "a.shared data structures,b.procedures that operate on shared data structure,c.synchronization between concurrent procedure invocation");
            T_F obj5 = new T_F(5, 10, "First question of T/F", "Based on client-server model and Distributed application architecture it is called second platform ", Type.True_False, new string[] { "1-True", "2-False" }, "1-True");
            T_F obj6 = new T_F(6, 5, "Second Question of T/F", "A cloud service is a hardware resources that are offered for consumption by a provider", Type.True_False, new string[] { "1-True", "2-False" }, "2-False");
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
                Console.WriteLine("              A-Practical Exame           B-Final Exam");
                x = Console.ReadLine();
            } while (!(x == "A" || x == "B"));

            if (x == "A")
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