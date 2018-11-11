using Microsoft.EntityFrameworkCore;
using NotificationTemplateManager.Models;

namespace NotificationTemplateManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<NotificationTemplate> Templates { get; set; }
    }
}
