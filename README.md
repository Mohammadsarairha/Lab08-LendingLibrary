# Lab08-LendingLibrary

# CONTENTS OF THIS FILE
---------------------
- [Introduction](#introduction)
- [About](#about)
- [How To Use?](#how-to-use)
- [Features](#features)
- [Design the Project models](#design-the-project-models)
- [Unit Tests](#unit-tests)
- [Future Work](#future-work)
- [Code Reference](#code-reference)
 ## Introduction

**Phil’s Lending Library**  is a library from which books are lent out.that contains a large collection of diverse books from different sections and different interests such as information technology books, medicine books, literature and different languages ... etc. 

## About

This program is a lending library , Through which you can choose one of these books available in the library and borrow it and add it directly to your backpack,
which contains all the books that were borrowed by you, 
And you have the option to view all the books you borrowed before and all the books in the bag, 
And in case you choose a book that is not in the library, the program will tell you that the book is not available at the moment, 
That it was borrowed by you, or that you are trying to borrow a book that is already in your backpack, and you can also return the book that you borrowed at any time,  
Do not worry, the program will know if the book is already in your bag or not.

## Getting Started

All the steps that the user will go through during this journey will now be displayed within the library.

## How to Use?

* The first stage is to show the menu to the user in which the following list of options appears

```bash

Welcome To Phils Lending Library

please choose number in menu

1. Show All books in Library
2. Choose the book you need to borrow
3. Write book title need to return
4. Show All books in you backpack
5. Exit

```

Let's through all this options together , to have full understanding how the project work

1. Choose first option : Show All books in Library is showing all books in Library with all details like , Book Tilte , Author Name, Number of pages .

```bash
Book Tilte : Vahana Masterclass| Author Name : Alfredo Covelli| Number of pages : 290

Book Tilte : Right Under Our Nose| Author Name : R.Giridharan Giridharan| Number of pages : 673

Book Tilte : The Little Book of Encouragement| Author Name : Dalai Lama| Number of pages : 123

Book Tilte : Clean Code| Author Name : Robert Martin| Number of pages : 420

Book Tilte : Algorithms| Author Name : Thomas Cormen| Number of pages : 300

Book Tilte : Design Patterns| Author Name : Gamma Erich| Number of pages : 589
```

2. Second option Choose the book you need to borrow : it's waiting for user to enter book title need to borrow .

```bash
Please add the title of the book you need to borrow
Clean Code

A book has been successfully added to your backpack
```
- If user trying to enter book name not in the Library , its telling user the book not found

```bash
Please add the title of the book you need to borrow
The Pragmatic Programmer

Book not found
```

- Also If user trying to enter book name already in his backpak , its telling user book name Already in your backpack

```bash
Please add the title of the book you need to borrow
Clean Code

Clean Code : Already in your backpack
```

3. third option Write book title need to return : it's waiting for user to enter book index need to borrow, Also program show user all book already in his backpack to pick up one of them.  

```bash
Please add the number of the book you want to return

This all books in your backpack
1.Clean Code

1

Thank you for return book
```

 - If user trying to enter book index not in the Backback , its telling user the book not found in you backpack

```bash
Please add the number of the book you want to return

This all books in your backpack
1.Vahana Masterclass
2

Book not found in you backpack
```
- Also If user trying to return and his backpack is empty , its telling user backpack is empty

 ```bash
There is no book in your backpake
 ```

 4. Fourth option Show All books in you backpack : Its showing all books title in your backpack . 

 ```bash
All Books in your backpack

1. Book Tilte: Vahana Masterclass

2. Book Tilte: Clean Code
 ```

 5. The last option is to exit the project, and display a farewell message

 ```bash
See you next time thank you
 ```

 ## Features

This program offers many features through which it is possible to deal in chains with the books in the library in an easy and simple way, 
And it provides many services to enable the user to deal with the program and interact with it more, 
And the program deals with all the inputs that come through the user,
And be the reaction of the program is appropriate and guides the user to a correct way to deal with these inputs without making mistakes that make this experience bad.

## Design the Project models

Model provides a way to describe software architecture models using diagrams as code, And how the code structure look like.

Library Class : Its inherent from ILibrary interface.

- ILibrary interface

```C#
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
```
- Providing implementation for Interface functions

- Add function 

```C#
 public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            Book newBook = new Book(title, firstName, lastName, numberOfPages);
            books.Add(title, newBook);
            count++;
        }
```
- Borrow function

```C#
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
```

- Return function 

```C#
public void Return(Book book)
        {
            books.Add(book.Title, book);
            count++;
        }
```

- IReadOnlyCollection<Book> : Its inherent tow function and Count filed

```C#
int count { get; set; }

public int Count
        {
            get
            {
                return count;
            }
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
```

Backpack class : Its inherent from IBag interface.

- IBag interface

```C#
public interface IBag<T> : IEnumerable<T>
    {
        /// <summary>
        /// Add an item to the bag. <c>null</c> items are ignored.
        /// </summary>
        void Pack(T item);

        /// <summary>
        /// Remove the item from the bag at the given index.
        /// </summary>
        /// <returns>The item that was removed.</returns>
        T Unpack(int index);
    }
```
- Pack function
```C#
public void Pack(T item)
        {
            backPack.Add(item);
        }
```
- Unpack function
```C#
public T Unpack(int index)
        {
            try
            {
                T item = backPack[index];
                backPack.RemoveAt(index);
                return item;
            }
            catch(Exception)
            {
                return default (T);
            }
        }
```
- IEnumerable : Its inherent tow function.
```C#
public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in backPack)
            {
                yield return item; 
            }
        }

IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
````

## Unit Tests

- [x] Test Add a Book to your Library
- [x] Test Borrowing an existing title returns the Book 
- [x] Test Borrowing a missing title returns null
- [x] Test Returned book is once again in the Library
- [x] Test Pack and Unpack your Backpack


- Test Add a Book to your Library

```c#
[Fact]
        public void Test1()
        {
            Library PhilesLibrary = new Library();
            PhilesLibrary.Add("Vahana Masterclass", "Alfredo", "Covelli", 290);

            Assert.Single(PhilesLibrary);
        }
```
2. Test Borrowing an existing title returns the Book 

```C#
[Fact]
        public void Test2()
        {
            Library PhilesLibrary = new Library();
            PhilesLibrary.Add("Vahana Masterclass", "Alfredo", "Covelli", 290);
            PhilesLibrary.Borrow("Vahana Masterclass");
            Assert.Empty(PhilesLibrary);
        }

```

3. Borrowing a missing title returns null
```C#
        [Fact]
        public void Test3()
        {
            Library PhilesLibrary = new Library();
            PhilesLibrary.Add("Vahana Masterclass", "Alfredo", "Covelli", 290);
            Assert.Null(PhilesLibrary.Borrow("A"));
        }
```

4. Test Returned book is once again in the Library

```c#
[Fact]
        public void Test4()
        {
            Library PhilesLibrary = new Library();
            PhilesLibrary.Add("Vahana Masterclass", "Alfredo", "Covelli", 290);
            Book book = new Book("Vahana Masterclass", "Alfredo", "Covelli", 290);
            
            Assert.Null(PhilesLibrary.Borrow("A"));
        }
```

5. Test Pack and Unpack your Backpack

```C#
[Fact]
        public void Test5()
        {
            Backpack<int> backpack = new Backpack<int>();
            backpack.Pack(1);
            Assert.Equal(1, backpack.Unpack(0));
        }
```

## Future Work

In the future, many functions can be added to this project and new features such as dividing all the existing books into various sections to enable the user to choose the appropriate section for the user’s interests to facilitate the process of moving between books and to take an overview of the books in the section and their titles,
And this will save the user time to borrow the book  Required

## Code Reference

[LendingLibrary](./LendingLibrary/LendingLibrary/)