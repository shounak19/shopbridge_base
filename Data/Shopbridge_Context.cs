﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;

namespace Shopbridge_base.Data
{
    public class Shopbridge_Context : DbContext
    {
        public Shopbridge_Context (DbContextOptions<Shopbridge_Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}