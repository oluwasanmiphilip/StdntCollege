using Microsoft.EntityFrameworkCore;
using StdntCollege.Data.Config;
using System.Security.Cryptography.Xml;

namespace StdntCollege.Data
{
    public class SchDbContext : DbContext
    {
        public SchDbContext(DbContextOptions<SchDbContext> options) : base(options)
        {
                
        }
        DbSet<Student> Students
        {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Table 1
            modelBuilder.ApplyConfiguration(new StudentConfig());  

            //Table 2
            //Table 3
        }
    }
}
