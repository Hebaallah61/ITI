using System.ComponentModel.DataAnnotations;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter size of array");
            int size=int.Parse(Console.ReadLine());

            int[] arr;
            arr= new int[size];

            for(int i = 0; i < size; i++)
            {
                Console.WriteLine("enter ele"+$"{i+1}");
                int element=int.Parse(Console.ReadLine());
                arr[i]=element;
            }

            int maxcellsdis=0;

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length; j++)
                {
                    if (arr[i]==arr[j])
                    {
                        //Console.WriteLine("j:"+j);
                        //Console.WriteLine("i:"+i);
                        if(maxcellsdis<(j-i)-1)
                            maxcellsdis = (j - i)-1 ;
                        //Console.WriteLine(maxcellsdis);
                    }
                }
            }

            Console.WriteLine("max dis cell: "+$"{maxcellsdis}");


            //foreach(int ele in arr)
            //{
              //  Console.WriteLine(ele);
            //}


        }
    }
}