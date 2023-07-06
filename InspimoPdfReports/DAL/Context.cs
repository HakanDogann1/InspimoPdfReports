using Microsoft.EntityFrameworkCore;

namespace InspimoPdfReports.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NOMRM5V\\SQLEXPRESS;initial catalog=DbReports;integrated security=true");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
