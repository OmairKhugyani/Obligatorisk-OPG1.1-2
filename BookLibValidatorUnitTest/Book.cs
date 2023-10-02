namespace BookLibValidatorUnitTest;
using System;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Price: {Price:C}";
    }

    public void ValidateId()
    {
        if (Id < 1)
            throw new ArgumentException("Id must be a positive integer.");
    }

    public void ValidateTitle()
    {
        if (string.IsNullOrEmpty(Title) || Title.Length < 3)
            throw new ArgumentException("Title must be at least 3 characters long and cannot be null or empty.");
    }

    public void ValidatePrice()
    {
        if (Price <= 0 || Price > 1200)
            throw new ArgumentException("Pris skal være i mellem 1 og 1200.");
    }

    public void ValidateBook()
    {
        ValidateId();
        ValidateTitle();
        ValidatePrice();
    }
}
