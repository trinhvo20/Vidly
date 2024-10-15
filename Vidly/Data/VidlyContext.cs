// This file make connect to database and create tables Movies and table Customers
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class VidlyContext : DbContext
    {
        public VidlyContext(DbContextOptions<VidlyContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<MembershipType> MembershipTypes { get; set; }
        
        public DbSet<Genre> Genres { get; set; }
    }
}
