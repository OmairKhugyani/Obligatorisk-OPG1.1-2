using System;
using BookLibValidatorUnitTest;

public class BooksRepository
{
    private List<Book> books;

    public BooksRepository()
    {
        // Opret en liste af bogobjekter
        books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Price = 100 },
            new Book { Id = 2, Title = "Book 2", Price = 200 },
            new Book { Id = 3, Title = "Book 3", Price = 150 },
            new Book { Id = 4, Title = "Book 4", Price = 300 },
            new Book { Id = 5, Title = "Book 5", Price = 50 }
        };
    }

    public List<Book> Get()
    {
        // Returner en kopi af listen ved hjælp af en copy constructor
        return new List<Book>(books);
    }

    public List<Book> Get(decimal maxPrice)
    {
        // Returner en kopi af listen filtreret efter pris
        return new List<Book>(books.Where(book => book.Price <= maxPrice));
    }

    public List<Book> Get(string sortBy)
    {
        // Returner en kopi af listen sorteret efter titel eller pris
        if (sortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
        {
            return new List<Book>(books.OrderBy(book => book.Title));
        }
        else if (sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
        {
            return new List<Book>(books.OrderBy(book => book.Price));
        }
        else
        {
            throw new ArgumentException("Invalid sort option. Use 'Title' or 'Price'.");
        }
    }

    public Book GetById(int id)
    {
        // Find og returner bogen med det angivne id, eller returner null
        return books.FirstOrDefault(book => book.Id == id);
    }

    public Book Add(Book book)
    {
        // Tildel et nyt id til bogen og tilføj den til listen
        int newId = books.Max(b => b.Id) + 1;
        book.Id = newId;
        books.Add(book);
        return book;
    }

    public Book Delete(int id)
    {
        // Find og fjern bogen med det angivne id fra listen, eller returner null
        Book bookToRemove = books.FirstOrDefault(book => book.Id == id);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
        }
        return bookToRemove;
    }

    public Book Update(int id, Book values)
    {
        // Find bogen med det angivne id og opdater dens egenskaber med values
        Book bookToUpdate = books.FirstOrDefault(book => book.Id == id);
        if (bookToUpdate != null)
        {
            bookToUpdate.Title = values.Title;
            bookToUpdate.Price = values.Price;
        }
        return bookToUpdate;
    }
}


















