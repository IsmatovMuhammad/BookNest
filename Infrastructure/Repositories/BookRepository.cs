using System.Data.Common;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Repositories;

public class BookRepository(Database database) : IBookRepository
{
    private Database data = database;

    public async Task<bool> AddBook(Book book)
    {
        data.Books.Add(book);
        var ad = await data.SaveChangesAsync();
        return ad > 0;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var del = await data.Books.FirstOrDefaultAsync(x => x.Id == id);
        if(del != null)
        {
            data.Books.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Book> GetBook(int id)
    {
        var res = await data.Books.FirstOrDefaultAsync(x => x.Id == id);
        return res??new();
    }

    public async Task<List<Book>> GetBooks()
    {
        return await data.Books.ToListAsync();
    }

    public async Task<bool> UpdateBook(Book book)
    {
        var upd = await data.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
        if(upd != null)
        {
            upd.Title = book.Title;
            upd.PublishedYear = book.PublishedYear;
            upd.TotalCopies = book.TotalCopies;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

}
