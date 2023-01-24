namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] myArray = { 1, 2, 3 };
            Console.WriteLine(myArray.GetHashCode());

            Passbyval(myArray);
            for(int i = 0;i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);

            }
            Console.WriteLine(myArray.GetHashCode());
            
            Passbyref(ref myArray);
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);

            }
            Console.WriteLine(myArray.GetHashCode());



        }



        //ref by val
        public static void Passbyval(int[] array)
        {
           
            array = new int[] { 7, 8, 9 };

        } 

        //ref by ref
        public static void Passbyref(ref int[] array)
        {
          
            array = new int[] { 10, 11, 12 };
        }  
    }
}