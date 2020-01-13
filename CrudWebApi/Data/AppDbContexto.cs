using System;
using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Data
{
    public class AppDbContexto : DbContext
    {
        public AppDbContexto(DbContextOptions<AppDbContexto> options) : base(options)
        {

        }

        public DbSet<Contacto> ContactoItems { get; set; }
    }
}
