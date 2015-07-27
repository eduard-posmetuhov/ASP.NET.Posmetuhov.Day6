using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using System.IO;

namespace BookLibraryTest
{
   class Program
    {
        private const string fileName = "BookLib.dat";
        static void Main(string[] args)
        {
            try
            {
                BinBookRepozitory rep = new BinBookRepozitory(fileName);
                SaveDefaultValues();
                BookListService bls = new BookListService(rep);             
                Book[] find = bls.FindByTag("1999", EnumTag.Year); 
                foreach (Book b in find)
                Console.WriteLine(b);
                Console.WriteLine("-------------------------");
                Book[] sort = bls.SortBooksByTag(EnumTag.Page);
                foreach (Book b in sort)
                    Console.WriteLine(b);
                //bls.AddBook(sort[0]); 
                bls.RemoveBook(sort[0]);
                bls.RemoveBook(sort[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private static void SaveDefaultValues()
        {
            BinBookRepozitory rep = new BinBookRepozitory(fileName);
            List<Book> listOfBook = new List<Book>();
            Book first = new Book("Author1", "Title1", "Pub1", 1990, 200);
            Book second = new Book("Author2", "Title2", "Pub1", 1999, 250);
            Book third = new Book("Author3", "Title3", "Pub1", 1998, 205);                 
            listOfBook.Add(first);
            listOfBook.Add(second);
            listOfBook.Add(third);
            rep.Save(listOfBook);
            
        }
    }
}


