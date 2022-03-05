using Microsoft.EntityFrameworkCore;

namespace MyCarsAPI.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options) 
        {
        
        }

        public virtual DbSet<User> Users { get; set; }
        
    }
}
