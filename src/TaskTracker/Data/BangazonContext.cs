using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;
using System;
using System.Collections.Generic;

namespace TaskTracker.Data
{
    // define what tables you'll be interacting with here 
    public class BangazonContext : DbContext
    {
        public BangazonContext(DbContextOptions<BangazonContext> options)
            : base(options)
        { }

        public DbSet<ToDo> ToDo { get; set;}


     
    }
}