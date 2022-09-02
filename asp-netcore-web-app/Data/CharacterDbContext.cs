using asp_netcore_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_netcore_web_app.Data
{
    public class CharacterDbContext : DbContext
    {
        public CharacterDbContext(DbContextOptions<CharacterDbContext> options) : base(options)
        {
        }
        public DbSet<Character> characters { get; set; }
    }
}
