using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
   public class Library
    {
        public List<Book> Books = new List<Book>();
        public List<Book> CheckedOut = new List<Book>();


        public Library()
        {
            Book book1 = new Book
            {
                Title = "Headfirst With C#",
                Author = "Matt",
                ID = "1",
            };
            Book book2 = new Book
            {
                Title = "Mastering the Console App",
                Author = "Jake",
                ID = "2",
            };
            Book book3 = new Book
            {
                Title = "C# Game Programming: For Serious Game Creation",
                Author = "Chance",
                ID = "3",
            };
            Book book4 = new Book
            {
                Title = "Pro C# 5.0 and the .Net 4.5 Framework",
                Author = "Zach",
                ID = "4",
            };
            Books.Add(book1);
            Books.Add(book2);
            Books.Add(book3);
            Books.Add(book4);

        }
        public void WriteMenu(Library library)
        {
            Console.WriteLine("Select a Book to Checkout:");
            Console.WriteLine();
            var k = 0;
            for(var i = 0; i<library.Books.Count; i++)
            {
                k = i + 1;
                Console.WriteLine(k.ToString() + ". Author: " + library.Books[i].Author + "," + " Title: " + library.Books[i].Title + "," + " ID: " + library.Books[i].ID);
            }
            k += 1;
            Console.WriteLine(k.ToString() + ". Return Book");
            Console.WriteLine();
            Console.WriteLine("Select the Book you would like to Checkout by number.");
            var selection = Console.ReadKey().KeyChar.ToString();
            try
            {
                int j = int.Parse(selection);
                if (j <= library.Books.Count)
                {
                    library.SelectBook(library.Books[j - 1], library);
                }
                else if (j == library.Books.Count + 1)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Book ID:");
                    var selection1 = Console.ReadLine().ToString();
                foreach(Book checkedBook in CheckedOut)
                    {
                        if(selection1 == checkedBook.ID)
                        {
                            ReturnBook(checkedBook, library);
                            break;
                        }
                    }            
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Choice, Choose valid number");
                Console.ReadLine();
            }

            return;
        }

        public void Checkout(Book book)
        {
            Books.Remove(book);
            CheckedOut.Add(book);
            Console.WriteLine("You have checked out " + book.Title);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return;
        }
        public void SelectBook(Book book, Library library)
        {
            Console.Clear();
            Console.WriteLine("You have selected " + book.Title);
            Checkout(book);
            return;
        }
        public void ReturnBook(Book book, Library library)
        {
            foreach(Book returnedBook in library.CheckedOut)
            {
                if(book.Title == returnedBook.Title)
                {
                    library.CheckedOut.Remove(book);
                    library.Books.Add(returnedBook);
                    Console.WriteLine("You returned " + book.Title);
                    break;
                }
            }
            Console.WriteLine("You added " + book.Title + " to the Library.");
        }

    }
}
