﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class T_F:Question
    {
        public string[] choices { get; set; }
        public T_F(int _id,int _marks, string _header, string _body, Type _type, string[] choices, string ans) : base(_id,_marks, _header, _body, _type,ans)
        {
            this.choices = choices;
        }

        public T_F(int _id, int _marks, string _header, string _body, Type _type, string[] choices) : base(_id, _marks, _header, _body, _type)
        {
            this.choices = choices;
        }
        public T_F() { }

        public override string ToString()
        {
            return $"ID: {id} / Marks: {marks} / Header: {header} / Body: {body} / Type: {type} / Chooises: {string.Join(",", choices)} ";

        }
    }

    //enum chooices
    //{
    //    True=1, False=2,
    //}
}