using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
