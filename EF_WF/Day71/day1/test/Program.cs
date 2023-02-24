using test.Context;
using test.Entities;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(LibraryContext context=new LibraryContext())
            {
                #region create DB

                context.Database.EnsureDeleted();//used if we change any thing or modified in entity [drop data base and create it with yhe new structure]
                context.Database.EnsureCreated();

                //context.Database.EnsureCreated();//if db not exist create it 


                // var Result = context.Titles.FirstOrDefault();//linq to entity =converted to=>Select statement 

                // Console.WriteLine(Result?.AuthorName??"NA");
                #endregion

                #region Insert
                //Title title = new() { AuthorName = "Heba", Price = 10003.5M, PromotionalPrice=1000 };//M for decimal money

                ////context.Add(title); new in EF
                //context.Titles.Add(title);//Local Reposatry (Titles)

                //context.SaveChanges(); //Commit Changes to DB
                //Console.WriteLine(title.ID);

                //Title T2 = new() { AuthorName = "JKR", Price = 20 };
                //Console.WriteLine($"{context.Entry(T2).State}");//show me the state of object
                //context.Add(T2);
                //Console.WriteLine($"{context.Entry(T2).State}");
                //context.SaveChanges();
                //Console.WriteLine($"{context.Entry(T2).State}");
                #endregion

                #region Update

                //var Result = (from T in context.Titles
                //              where T.PromotionalPrice == null
                //              select T).First();

                //Result.PromotionalPrice = 0.75M * Result.Price;
                //context.SaveChanges();
                #endregion

                #region Delete  
                //immediate execution it is not deffered

                //var T = context.Titles.FirstOrDefault(t => t.AuthorName == "JKR");

                //if (T != null)
                //    context.Titles.Remove(T);

                //context.SaveChanges();

                #endregion

                #region if we alert in structure of db
                context.Add(new Branch() { City = "Cairo", OpenHour = 10, ZipCode = "12111" });
                context.SaveChanges();
                #endregion


            }

        }
    }
}
