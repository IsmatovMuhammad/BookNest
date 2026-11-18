using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure.Repositories;

public class GenresRepository(Database database) : IGenresRepository
{
    private Database data = database;
    public async Task<bool> AddGenre(Genres genre)
    {
        data.Genrs.Add(genre);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteGenre(int id)
    {
        var del = await data.Genrs.FirstOrDefaultAsync(x => x.Id == id);
        if(del != null)
        {
            data.Genrs.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Genres> GetGenr(int id)
    {
        var res = await data.Genrs.FirstOrDefaultAsync(x => x.Id == id);
        return res??new();
    }


    public async Task<List<Genres>> GetGenres()
    {
        return await data.Genrs.ToListAsync();
    }

    public async Task<bool> UpdateGenre(Genres genre)
    {
        var upd = await data.Genrs.FirstOrDefaultAsync(x => x.Id == genre.Id);
        if(upd != null)
        {
            upd.Name = genre.Name;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

}
