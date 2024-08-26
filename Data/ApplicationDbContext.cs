using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-V48V9BD\\MSSQLSERVER01;Database=EmpSystem9;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Employee>Employees { get; set; }
    }
}
