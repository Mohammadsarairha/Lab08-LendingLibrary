using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary
{
    public class Library : ILibrary
    {
        int count { get; set; }

        private Dictionary<string, Book> books = new Dictionary<string, Book>();

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            Book newBook = new Book(title, firstName, lastName, numberOfPages);
            books.Add(title, newBook);
            count++;
        }

        public Book Borrow(string title)
        {
            if (books.ContainsKey(title))
            {
                Book BorrowBook = books[title];
                books.Remove(title);
                count--;
                return BorrowBook;
            }
            else
                return null;
        }

        public void Return(Book book)
        {
            books.Add(book.Title, book);
            count++;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in books.Values)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public interface ILibrary : IReadOnlyCollection<Book>
    {
        /// <summary>
        /// Add a Book to the library.
        /// </summary>
        void Add(string title , string firstName, string lastName, int numberOfPages);

        /// <summary>
        /// Remove a Book from the library with the given title.
        /// </summary>
        /// <returns>The Book, or null if not found.</returns>
        Book Borrow(string title);

        /// <summary>
        /// Return a Book to the library.
        /// </summary>
        void Return(Book book);
    }
}
