using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tohou_Project.Models
{
    public class InfoMangaContext: DbContext
    {
        public DbSet<InfoManga> infoManga { get; set; }
        public DbSet<AlreadyRed> alreadyRedPages { get; set; }

        public InfoMangaContext(DbContextOptions<InfoMangaContext> dbContextOptions): base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
      
    }
}
