using System;
using System.Collections.Generic;
namespace LendingLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Backpack<Book> backpack = new Backpack<Book>();
            Library PhilesLibrary = new Library();
            PhilesLibrary.Add("Vahana Masterclass", "Alfredo", "Covelli", 290);
            PhilesLibrary.Add("Right Under Our Nose", "R.Giridharan", "Giridharan", 673);
            PhilesLibrary.Add("The Little Book of Encouragement", "Dalai", "Lama", 123);
            PhilesLibrary.Add("Clean Code", "Robert", "Martin", 420);
            PhilesLibrary.Add("Algorithms", "Thomas", "Cormen", 300);
            PhilesLibrary.Add("Design Patterns", "Gamma", "Erich", 589);

            Console.WriteLine("Welcome To Phil’s Lending Library");
            int menu = 0;
            int packCount = 0;
            while (menu < 5)
            {
                Console.WriteLine();
                Console.WriteLine("please choose number in menu");
                Console.WriteLine();
                Console.WriteLine("1. Show All books in Library");
                Console.WriteLine("2. Choose the book you need to borrow");
                Console.WriteLine("3. Write book title need to return");
                Console.WriteLine("4. Show All books in you backpack");
                Console.WriteLine("5. Exit");
                Console.WriteLine();

                menu = Int32.Parse(Console.ReadLine());

                if (menu == 1)
                {
                    foreach (Book item in PhilesLibrary)
                    {
                        Console.WriteLine("Book Tilte : " + item.Title + "| Author Name : " + item.Author + "| Number of pages : "+item.NumberOfPages);
                        Console.WriteLine();
                    }
                }
                else if (menu == 2)
                {
                    Console.WriteLine("Please add the title of the book you need to borrow");
                    string title = Console.ReadLine();
                    string insidePack = null;
                    Book borrowBook = PhilesLibrary.Borrow(title);
                    //search if book need to borrow already in backpack
                    foreach (Book back in backpack)
                    {
                        if (back.Title == title)
                        {
                            insidePack = back.Title;
                        }
                    }

                    if (borrowBook != null)
                    {
                        backpack.Pack(borrowBook);
                        packCount++;
                        Console.WriteLine();
                        Console.WriteLine("A book has been successfully added to your backpack");
                        Console.WriteLine();
                    }
                    else if (insidePack == title)
                    {
                        Console.WriteLine();
                        Console.WriteLine(title + " : Already in your backpack");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Book not found");
                        Console.WriteLine();
                    }
                }
                else if (menu == 3)
                {
                    if (packCount > 0)
                    {
                        Console.WriteLine("Please add the number of the book you want to return");
                        Console.WriteLine();
                        Console.WriteLine("This all books in your backpack");
                        int count = 0;
                        foreach (Book back in backpack)
                        {
                            count++;
                            Console.WriteLine(count + "." + back.Title);
                        }
                        int index = Int32.Parse(Console.ReadLine()) - 1;

                        var res = backpack.Unpack(index);
                        if (res != null)
                        {
                            PhilesLibrary.Add(res.Title,res.FirstName,res.LastName,res.NumberOfPages);
                            Console.WriteLine();
                            Console.WriteLine("Thank you for return book");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Book not found in you backpack");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no book in your backpake");
                    }
                    
                }else if(menu == 4)
                {
                    int count = 0;
                    foreach (Book back in backpack)
                    {
                        count++;
                        if (count == 1)
                        {
                            Console.WriteLine("All Books in your backpack");
                        }
                        Console.WriteLine();
                        Console.WriteLine(count +". Book Tilte: " + back.Title);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("See you next time thank you");
        }
    }
}