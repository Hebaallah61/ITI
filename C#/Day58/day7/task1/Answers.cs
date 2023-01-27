using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Answers
    {
        public string[] answer { get; set; }
        public Question question { get; set; }
        
        public Answers(int _id,string[] _answer)
        {
            answer = _answer;
            question.id= _id;
        }

        public Answers()
        {

        }
        public Answers(string[] _answer)
        {
            answer= _answer;
        }

        public override string ToString()
        {
            return $" Answer: {string.Join(", ", answer)}";
        }





    }
}
