namespace task1
{

    public delegate string Bookfuninfo(Book b);
    internal class Program
    {
        static void Main(string[] args)
        {


            String[] Authorsb1 = { "Joun Buchan ", "UN" };
            String[] Authorsb2 = { "Jules Verne ", "UN " };
            String[] Authorsb3 = { "Anthony Hope ", "UN " };
            String[] Authorsb4 = { "Jonathan Swift ", "UN " };

            DateTime date = new DateTime();

            Book book1 = new Book("978-977-6539-02-3", "The Thirty-Nine Steps", Authorsb1, date, 50.5M);
            Book book2 = new Book("970-972-6339-01-5", "Journey To The Center of The Earth", Authorsb2, date, 10.5M);
            Book book3 = new Book("971-997-6439-12-1", "The Prisoner of Zenda", Authorsb3, date, 11.5M);
            Book book4 = new Book("979-927-6529-20-2", "Gulliver’s Travels", Authorsb4, date, 40.75M);

            List<Book> Book_List = new List<Book> { book1, book2, book3, book4 };
            //uerdefine
            /*Bookfuninfo fptr_1 = new Bookfuninfo(BookFunctions.GetTitle);
             Bookfuninfo fptr_2 = new Bookfuninfo(BookFunctions.GetAuthors);
             Bookfuninfo fptr_3 = new Bookfuninfo(BookFunctions.GetPrice);
             LibraryEngine.ProcessBooks(Book_List, fptr_1);//title
             LibraryEngine.ProcessBooks(Book_List, fptr_2);//author
             LibraryEngine.ProcessBooks(Book_List, fptr_3);//price*/

            //BCL
            /* Func<Book, string> fptr_1 = BookFunctions.GetTitle;
             Func<Book, string> fptr_2 = BookFunctions.GetAuthors;
             Func<Book, string> fptr_3 = BookFunctions.GetPrice;
             LibraryEngine.ProcessBooks(Book_List, fptr_1);
             LibraryEngine.ProcessBooks(Book_List, fptr_2);
             LibraryEngine.ProcessBooks(Book_List, fptr_3);*/

            //Anonymous Method
             /*Func<Book, string> fptr_1 = delegate (Book book) { return $"Title:{book.Title}"; };
             LibraryEngine.ProcessBooks(Book_List, fptr_1);
             Func<Book, string> fptr_2 = delegate (Book book) { return $"Author:{string.Join(',', book.Authors)}"; };
             LibraryEngine.ProcessBooks(Book_List, fptr_2);
             Func<Book, string> fptr_3 = delegate (Book book) { return $"Price:{book.Price.ToString()}"; };
             LibraryEngine.ProcessBooks(Book_List, fptr_3);*/


            //Lambda Expression
            /*Func<Book, string> fptr_1 = (Book book) => $"PublicationDate:{book.PublicationDate.ToString()}";
            LibraryEngine.ProcessBooks(Book_List, fptr_1);
            Func<Book, string> fptr_2 = (Book book) => $"ISBN:{book.ISBN.ToString()}";
            LibraryEngine.ProcessBooks(Book_List, fptr_2);
            Func<Book, string> fptr_3 = (Book book) => $"Title:{book.Title}";
            LibraryEngine.ProcessBooks(Book_List, fptr_3);
            Func<Book, string> fptr_4 = (Book book) => $"Price:{book.Price.ToString()}";
            LibraryEngine.ProcessBooks(Book_List, fptr_4);
            Func<Book, string> fptr_5 = (Book book) => $"Author:{string.Join(',', book.Authors)}";
            LibraryEngine.ProcessBooks(Book_List, fptr_5);*/

        }
    }

   

}