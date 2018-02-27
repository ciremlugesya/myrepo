using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Entities
{
    public class CustomIdentityDBContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public CustomIdentityDBContext(DbContextOptions<CustomIdentityDBContext> options) : base(options)
        {

        }
    }
}
