using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task1
{
    internal class Exam 
    {
        public string Time { get; set; }
        public int number_of_Questions { get; set; }
        public Answerstd [] Question_Answer { get; set; }
        public Question[] questions { get; set; }

        public choose_one[] chone { get; set; }

        public choose_all[] chone_all { get; set; }

        public T_F[] t_F { get; set; }

        public Exam() { }
        public Exam(string time, int number_of_Questions, Answerstd[] question_Answer)
        {
            Time = time;
            this.number_of_Questions = number_of_Questions;
            Question_Answer = question_Answer;
           
        }

        public Exam(string time, int number_of_Questions)
        {
            Time = time;
            this.number_of_Questions = number_of_Questions;
            questions = new Question[number_of_Questions];
            chone=new choose_one[number_of_Questions/3];
            chone_all=new choose_all[number_of_Questions/3];
            t_F=new T_F[number_of_Questions/3];
        }

      

        

        public Exam(string time, int number_of_Questions, Question[] _questions, choose_all[] _ch_all, choose_one[] _chone, T_F[] _t_f) :this(time,number_of_Questions)
        {

            for (int i = 0; i < _questions.Length; i++)
            {
                questions[i] = _questions[i];
            }
            for (int i = 0; i < _ch_all.Length; i++)
            {
                chone_all[i] = _ch_all[i];
            }
            for (int i = 0; i < _chone.Length; i++)
            {
                chone[i] = _chone[i];
            }
            for (int i = 0; i < _t_f.Length; i++)
            {
                t_F[i] = _t_f[i];
            }
        }

        //preversion 
        public virtual void ShowExam(Question[] qs, choose_one[] chone, choose_all[] chone_all, T_F[]t_F)
        {
            for (int i=0;i<number_of_Questions;i++)
            {
                for(int j = 0; j < 1; j++)
                {
                if (qs[i].type == Type.True_False)
                {
                    Console.WriteLine($"Q{i+1}: " +t_F[j].header + "\n" + t_F[j].body +"\n"+
                        string.Join(",", t_F[j].choices));
                }
                else if (qs[i].type == Type.Choose_All)
                {
                    Console.WriteLine($"Q{i + 1}: "+chone_all[j].header + "\n" + chone_all[j].body + "\n" +
                        string.Join(",", chone_all[j].choices));
                }
                else if(qs[i].type == Type.Choose_One)
                {
                    Console.WriteLine($"Q{i + 1}:"+chone[j].header + "\n" + chone[j].body + "\n" + 
                        string.Join(",", chone[j].choices));
                }
                }
                
                

            }
        }

        //new version
        public virtual void SHOWEXAM()
        {
            for (int i = 0; i < number_of_Questions; i++)
            {
               
                Console.WriteLine(questions[i].header + "\n" + questions[i].body );
                for (int j = 0; j < 1; j++)
                {
                    if (questions[i].type == Type.True_False)
                    {
                        Console.WriteLine(
                            string.Join(",", t_F[j].choices));
                        Console.WriteLine("enter answer");
                    }
                    else if (questions[i].type == Type.Choose_All)
                    {
                        Console.WriteLine(
                            string.Join(",", chone_all[j].choices));
                        Console.WriteLine("enter answer");

                    }
                    else if (questions[i].type == Type.Choose_One)
                    {
                        Console.WriteLine(
                            string.Join(",", chone[j].choices));
                        Console.WriteLine("enter answer");

                    }
                }

            }

        

           
        }
    }
}
