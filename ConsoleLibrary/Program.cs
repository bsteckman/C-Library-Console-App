using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            Library library = new Library();
            while (displayMenu)
            {
                Console.Clear();
                library.WriteMenu(library);
            }
        

            
            
        }
    }
}
