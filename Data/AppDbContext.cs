using CrazyMusiciansPractice.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CrazyMusiciansPractice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Musician> Musicians { get; set; }
    }
}

