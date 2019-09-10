using System;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):
            base(options)
        {

        }

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

