using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week3Day3XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"books.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/catalog/book");

            List<Books> books = new List<Books>();

            foreach (XmlNode node in nodes)
            {
                Books book = new Books();

                book.Id = node.Attributes["id"].Value;
                book.Author = node.SelectSingleNode("author").InnerText;
                book.Title = node.SelectSingleNode("title").InnerText;
                book.Genre = node.SelectSingleNode("genre").InnerText;
                book.Price = node.SelectSingleNode("price").InnerText;
                book.Publish_date = node.SelectSingleNode("publish_date").InnerText;
                book.Description = node.SelectSingleNode("description").InnerText;

                books.Add(book);
            }
            System.Console.WriteLine("Total books: " + books.Count);
            
            foreach (XmlNode xn in nodes)
            {
                Console.WriteLine(xn.InnerText.ToString());
            }

            Console.ReadLine();
        }
    }
}
