using MeetingOrganizer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingOrganizer.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext>options) : base(options)
        {
        }
        public DbSet<Meeting> Meetings { get; set; }
    }
}
