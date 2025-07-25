using System;
using HelperBackendAPI.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace HelperBackendAPI.Entity.DataContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<MasterService> MasterService { get; set; }
        public DbSet<SearchHistory> SearchHistory{ get; set; }
    }
}
