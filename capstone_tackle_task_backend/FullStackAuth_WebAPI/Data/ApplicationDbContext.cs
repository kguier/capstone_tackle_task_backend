﻿using FullStackAuth_WebAPI.Configuration;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackAuth_WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Entry> Entries { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<TaskItem> TaskItems { get; set; }

        public DbSet<TaskList> TaskLists { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options)
    : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolesConfiguration());
        }
    }
}
