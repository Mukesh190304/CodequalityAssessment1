
using Microsoft.EntityFrameworkCore;
using CaptchaGeneratorService.Model;

using System.Security.Cryptography.X509Certificates;

namespace CaptchaGeneratorService.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<CaptchaGenerator> Generators { get; set; }



    }
}



