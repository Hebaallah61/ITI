using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Answerstd
    {
        public string[] answer_std { get; set; }
        public Question question { get; set; }
        public Answerstd() { 
        }

        
        public Answerstd(int _id, string []choosed)
        {
            question = new Question();
            answer_std = choosed;
            question.id = _id;
        }

        public Answerstd( string[] choosed) 
        {
            answer_std = choosed;
        }

        public override string ToString()
        {
            return $" ID: {question.id} / Student Answer: {string.Join(", ", answer_std)}";
        }
    }
}
