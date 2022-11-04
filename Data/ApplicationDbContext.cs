using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WDP2022A2Win.Models;
using Microsoft.AspNetCore.Identity;


namespace WDP2022A2Win.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<WDP2022A2Win.Models.Company> Company { get; set; }
   

    }
}