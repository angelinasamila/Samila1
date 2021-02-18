using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Samila1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Samila1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<News> News { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
