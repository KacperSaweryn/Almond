using Firma.Data.Data.CMS;
using Firma.Data.Data.Sklep;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Firma.Data.Data
{
    public class AlmondContext
        : DbContext
    {
        public AlmondContext(DbContextOptions<AlmondContext> options)
            : base(options)
        {
        }

        public DbSet<Page> Page { get; set; } = default!;
        public DbSet<News> News { get; set; }
        public DbSet<Params>? Params { get; set; }
        public DbSet<Item>? Item { get; set; }
        public DbSet<ItemType>? ItemType { get; set; }
        public DbSet<CartElement>? CartElement { get; set; }
        public DbSet<DefaultTest>? DefaultTest { get; set; }
        public DbSet<User>? User { get; set; }
       // public DbSet<Order>? Order { get; set; }
    }
}