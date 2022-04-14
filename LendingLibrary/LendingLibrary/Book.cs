using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfPages { get; set; }

        public Book(string Title , string FirstName ,string LastName, int NumberOfPages)
        {
            this.Title = Title;
            this.Author = FirstName + " " + LastName;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.NumberOfPages = NumberOfPages;
        }
        public Book()
        {

        }
    }
    
}
