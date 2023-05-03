using Firma.Data.Data.CMS;
using Firma.Data.Data.Sklep;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data
{
    public class AlmondContext : DbContext
    {
        public AlmondContext(DbContextOptions<AlmondContext> options)
            : base(options)
        {
        }

        public DbSet<Page> Page { get; set; } = default!;

        public DbSet<News> News { get; set; }

        public DbSet<Params>? Params { get; set; }
        public DbSet<Cat>? Cat { get; set; }
        public DbSet<CatTree>? CatTree { get; set; }
        public DbSet<Item>? Item { get; set; }
        public DbSet<ItemType>? ItemType { get; set; }
    
    }
}

