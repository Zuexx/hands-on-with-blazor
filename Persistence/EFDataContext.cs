using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HandsOnWithBlazor.Persistence
{
    public class EFDataContext : IdentityDbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options)
           : base(options)
        {
        }
    }
}