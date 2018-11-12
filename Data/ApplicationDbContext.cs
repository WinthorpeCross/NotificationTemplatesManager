using Microsoft.EntityFrameworkCore;
using NotificationTemplateManager.Models;
using System;

namespace NotificationTemplateManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<NotificationTemplate> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NotificationTemplate>().HasData(new NotificationTemplate { Id=1, Name = "Test", Body = "HTML<>", CreatedDate = DateTime.Now, IsInactive = false });
        }
    }
}
