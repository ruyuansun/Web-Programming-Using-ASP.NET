using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegisterLoginPractice.Models;

namespace RegisterLoginPractice.Data
{
   public class ApplicationDbContext : IdentityDbContext
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
      {
      }
      public DbSet<Note>Notes { get; set; }
   }
}
