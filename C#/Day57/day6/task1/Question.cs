using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Question
    {
        public int id { get; set; }
        public int marks { get; set; }
        public string header { get; set; }
        public string body { get; set; }
        public Type type { get; set; }

        public Answers[] answers { get; set; }

        public Question() { }

        public Question(int _id) { id = _id; }

        public Question(int _id, Answers[]ans) { id = _id; answers = ans; }


        public Question(int _id, int _marks, string _header, string _body,Type _type,Answers[] _ans)
        {
            id= _id;
            marks = _marks;
            header = _header;
            body = _body;
            type = _type;
            answers = _ans;
        }

        public Question(int _id, int _marks, string _header, string _body, Type _type)
        {
            id = _id;
            marks = _marks;
            header = _header;
            body = _body;
            type = _type;
            
        }

        public override string ToString()
        {
            return $"ID: {id} / Marks: {marks} / Header: {header} / Body: {body} / Type: {type} / Correct Answer:{answers}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Question q= obj as Question;
            if (this.type==q.type && this.id==q.id && this.marks==q.marks && this.header==q.header && this.body==q.body) return true;
            else return false;
            
        }

    }

    enum Type
    {
        True_False=1, Choose_One=2 , Choose_All=3
    }
}
