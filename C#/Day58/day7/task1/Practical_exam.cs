using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Practical_exam : Exam
    {
        public Practical_exam() { }
        public Practical_exam(string time, int num_of_q) : base(time, num_of_q) { }

        public Practical_exam(string time, int number_of_Questions, Question[] _questions, choose_all[] _ch_all, choose_one[] _chone, T_F[] _t_f) : base(time, number_of_Questions, _questions, _ch_all, _chone, _t_f) { }



        //preversion
        public override void ShowExam(Question[] qs, choose_one[] chone, choose_all[] chone_all, T_F[] t_F)
        {

            Console.WriteLine("================================PRACTICAL EXAM=============================" + "Time:" + Time);
            string[] s = new string[6];
            for (int i = 0; i < number_of_Questions; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (qs[i].type == Type.True_False)
                    {
                        Console.WriteLine($"Q{i + 1}: " + t_F[j].header + "\n" + t_F[j].body + "\n" +
                            string.Join(",", t_F[j].choices));
                        s[i] = Console.ReadLine();

                    }
                    else if (qs[i].type == Type.Choose_All)
                    {
                        Console.WriteLine($"Q{i + 1}: " + chone_all[j].header + "\n" + chone_all[j].body + "\n" +
                            string.Join(",", chone_all[j].choices));
                        //Console.ReadLine();
                        s[i] = Console.ReadLine();


                    }
                    else if (qs[i].type == Type.Choose_One)
                    {
                        Console.WriteLine($"Q{i + 1}:" + chone[j].header + "\n" + chone[j].body + "\n" +
                            string.Join(",", chone[j].choices));
                        //Console.ReadLine();
                        s[i] = Console.ReadLine();
                        //ansstd[i] = new Answerstd(i, s);

                    }
                }



            }
            Answerstd[] ansstd = new Answerstd[6];

            for (int i = 0; i < s.Length; i++)
            {
                ansstd[i] = new Answerstd(i, new string[] { s[i] });
            }


            Console.Clear();



            for (int i = 0; i < number_of_Questions; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (qs[i].type == Type.True_False)
                    {
                        Console.WriteLine($"Q{i + 1}: " + t_F[j].header + "\n" + t_F[j].body + "\n" +
                            string.Join(",", t_F[j].choices));
                        Console.WriteLine(ansstd[i].ToString());

                    }
                    else if (qs[i].type == Type.Choose_All)
                    {
                        Console.WriteLine($"Q{i + 1}: " + chone_all[j].header + "\n" + chone_all[j].body + "\n" +
                            string.Join(",", chone_all[j].choices));
                        Console.WriteLine(ansstd[i].ToString());
                    }
                    else if (qs[i].type == Type.Choose_One)
                    {
                        Console.WriteLine($"Q{i + 1}:" + chone[j].header + "\n" + chone[j].body + "\n" +
                            string.Join(",", chone[j].choices));
                        Console.WriteLine(ansstd[i].ToString());
                    }
                }
            }


            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"Correct Answer of Q{i + 1} " + qs[i].answers[0]);
            }




        }



         //new version


string[] s = new string[6];//for show answer of user
public virtual void SHOWEXAM()
{
            Console.WriteLine("================================PRACTICAL EXAM=============================" + "Time:" + Time);


            string? choicetemp;
    string[] stemp = new string[6];//for split answer
    for (int i = 0; i < number_of_Questions; i++)
    {

        Console.WriteLine(question_[i].header + "\n" + question_[i].body);
        for (int j = 0; j < 1; j++)
        {
            if (question_[i].type == Type.True_False)
            {
                Console.WriteLine(
                    string.Join("      ", t_F[j].choices));
                Console.WriteLine("Enter Your Answer");
                choicetemp = Console.ReadLine();
                s[i] = choicetemp;
                if (choicetemp != null)
                {

                    Question_CH[question_[i]] = choicetemp;




                }
            }
            else if (question_[i].type == Type.Choose_All)
            {
                Console.WriteLine(
                    string.Join("      ", chone_all[j].choices));
                Console.WriteLine("Enter Your Answer Separate It by','");
                choicetemp = Console.ReadLine();
                s[i] = choicetemp;
                if (choicetemp != null)
                {

                    Question_CH[question_[i]] = choicetemp;


                }

            }
            else if (question_[i].type == Type.Choose_One)
            {
                Console.WriteLine(
                    string.Join("      ", chone[j].choices));
                Console.WriteLine("Enter Your Answer");
                choicetemp = Console.ReadLine();
                s[i] = choicetemp;
                if (choicetemp != null)
                {

                    Question_CH[question_[i]] = choicetemp;
                }

            }
        }

    }


    Answerstd[] ansstd = new Answerstd[6];//--


    for (int i = 0; i < s.Length; i++)
    {
        ansstd[i] = new Answerstd(i, new string[] { s[i] });
    }

    //----------------------------------------
    Console.Clear();



    for (int i = 0; i < number_of_Questions; i++)
    {
        Console.WriteLine($"Q{i + 1}: " + question_[i].header + "\n" + question_[i].body);

        for (int j = 0; j < 1; j++)
        {
            if (question_[i].type == Type.True_False)
            {
                Console.WriteLine(
                    string.Join("      ", t_F[j].choices));
                Console.WriteLine(ansstd[i].ToString());
                        Console.WriteLine("\n");

                    }
                    else if (question_[i].type == Type.Choose_All)
            {
                Console.WriteLine(
                    string.Join("      ", chone_all[j].choices));
                Console.WriteLine(ansstd[i].ToString());
                        Console.WriteLine("\n");


                    }
                    else if (question_[i].type == Type.Choose_One)
            {
                Console.WriteLine(
                    string.Join("      ", chone[j].choices));
                Console.WriteLine(ansstd[i].ToString());
                        Console.WriteLine("\n");


                    }
                }




    }

    for (int i = 0; i < 6; i++)
    {
        Console.WriteLine("==============================");
        Console.WriteLine($"Correct Answer of Q{i + 1} " + question_[i].choanwers);

    }

    Console.WriteLine("---------------------------------------------------------------------------------");
    correctexam();




}

public void correctexam()
{
    string[] stemp;

    int i = 0;
    foreach (KeyValuePair<Question, string> item in Question_CH)
    {

        if (item.Key.choanwers == item.Value)
        {
            i += item.Key.marks;
        }

    }
    Console.WriteLine("Your Grad is: " + i);

}
    }
}