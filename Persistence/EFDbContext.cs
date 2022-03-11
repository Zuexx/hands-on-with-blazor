using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HandsOnWithBlazor.Persistence
{
    public class EFDbContext : IdentityDbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
           : base(options)
        {
        }
    }
}