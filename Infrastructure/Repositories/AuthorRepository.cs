using System.Runtime.CompilerServices;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Repositories;

public class AuthorRepository(Database database) : IAuthorRepository
{
    private Database data = database;
    public async Task<bool> AddAuthor(Author author)
    {
        data.Authors.Add(author);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteAuthor(int id)
    {
        var del = await data.Authors.FirstOrDefaultAsync(x => x.Id == id);
        if(del != null)
        {
            data.Authors.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Author> GetAuthor(int id)
    {
        var res = await data.Authors.FirstOrDefaultAsync(x => x.Id == id);
        return res??new();
    }

    public async Task<List<Author>> GetAuthors()
    {
        return await data.Authors.ToListAsync();
    }

    public async Task<bool> UpdateAuthor(Author author)
    {
        var upd = await data.Authors.FirstOrDefaultAsync(x => x.Id == author.Id);
        if(upd != null)
        {
            upd.FullName = author.FullName;
            upd.Country = author.Country;
            upd.BirthYear = author.BirthYear;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }
}
