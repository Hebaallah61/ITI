using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    
        public class Book
        {
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string[] Authors { get; set; }
            public DateTime PublicationDate { get; set; }
            public decimal Price { get; set; }
            public Book(string _ISBN, string _Title,
            string[] _Authors, DateTime _PublicationDate,
           decimal _Price)
            {
                
                this.ISBN = _ISBN;
                this.Title = _Title;
                this.Authors = _Authors;
                this.PublicationDate = _PublicationDate;
                this.Price = _Price;
            }
            public override string ToString()
            {
               
                return $"ISBN:{ISBN}  Title:{Title}   Authors:{String.Join(',', Authors)}   Price:{Price}    PublicationDate:{PublicationDate}";
            }
        }






        public class BookFunctions
        {
            public static string GetTitle(Book B)
            {
                
                return $"Title:{B.Title}";
            }
            public static string GetAuthors(Book B)
            {


                if (B.Authors != null)
                {
                   
                    return $"Author:{string.Join(',', B.Authors)}";
                   
                }
                return $"not found";
            }
            public static string GetPrice(Book B)
            {
               
                return $"Price:{B.Price.ToString()}";
            }
        }
        public class LibraryEngine
        {

            public static void ProcessBooks(List<Book> bList, Bookfuninfo fptr)
            {
                foreach (Book B in bList)
                {

                    Console.WriteLine(fptr(B));
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("//////////////////////////////////////////");
                    Console.WriteLine("--------------------------------------------");


            }
        }

            public static void ProcessBooks(List<Book> bList, Func<Book, string> fptr)//rerurn sting
            {
                foreach (Book B in bList)
                {

                    Console.WriteLine(fptr(B));
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||");
                    Console.WriteLine("--------------------------------------------");
               

            }
        }
        }

    }
//}
