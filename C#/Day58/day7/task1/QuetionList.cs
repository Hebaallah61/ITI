using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class QuetionList:List<Question>
    {

        new public void Add(Question question)
        {
            base.Add(question);

            using (StreamWriter openfile = File.AppendText("E:\\CS problem solving\\c#pd_heba\\first_use\\D07\\task1\\firt.txt"))
            {
                openfile.WriteLine(question);
                openfile.WriteLine("===============================================");
            }
        }


    }
}
