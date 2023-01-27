using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class choose_all:Question
    {
        public string[] choices { get; set; }
        public choose_all(int _id, int _marks, string _header, string _body, Type _type, string[] choices, Answers[] ans) : base(_id,_marks, _header, _body, _type,ans)
        {
            this.choices = choices;
        }
        //-------------------
        
        //------------------
        public choose_all(int _id, int _marks, string _header, string _body, Type _type, string[] choices) : base(_id, _marks, _header, _body, _type)
        {
            this.choices = choices;
        }
        public choose_all() { }

        public override string ToString()
        {
            return $"ID: {id} / Marks: {marks} / Header: {header} / Body: {body} / Type: {type} / Choices: {string.Join(",", choices)} / Correct Answer:{answers}";

        }
    }
}
