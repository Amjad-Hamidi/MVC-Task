using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class ApplicationDbContext:DbContext
    {
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //this is called when i make a connection : Connection String (not good) , لان اذا بدي اشتغل عاكثر من سيرفر كل شوي بدي اغيرها بالاضافة لموضوع التشفير لازم تكون مشفرة مش هيك مفتوح للكل 
            optionsBuilder.UseSqlServer("Server=DESKTOP-V48V9BD\\MSSQLSERVER01;Database=EmpSystem9;Trusted_Connection=True;TrustServerCertificate=True");
            
        }
        */
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee>Employees { get; set; }
    }
}
