using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookLibrary
{
    public class BinBookRepozitory :IBookRepozitory<Book>
    {   
        private readonly string filePath;
        public  BinBookRepozitory()
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            filePath = Path.Combine(folderPath, "Library");
        }
        public BinBookRepozitory(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException();
            this.filePath = filePath;
        }

        public IEnumerable<Book> Load()
        {
            List<Book> listOfbooks = new List<Book>();

            if (!File.Exists(filePath)) throw new FileNotFoundException("filePath not found");
            Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using (BinaryReader reader = new BinaryReader(stream))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Book book = new Book();
                    book.Author = reader.ReadString();
                    book.Title = reader.ReadString();
                    book.Publisher = reader.ReadString();
                    book.Year = reader.ReadInt32();
                    book.Page = reader.ReadInt32();
                    listOfbooks.Add(book);
                }
            }
            return listOfbooks;
        }

        public void Save(IEnumerable<Book> listOfbooks)
        {
            if (listOfbooks == null) throw new ArgumentNullException();
            Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using (BinaryWriter binWriter = new BinaryWriter(fileStream))
            {
                foreach (Book book in listOfbooks)
                {
                    binWriter.Write(book.Title);
                    binWriter.Write(book.Author);
                    binWriter.Write(book.Publisher);
                    binWriter.Write(book.Year);
                    binWriter.Write(book.Page);
                }
            }
        }
    }
}
