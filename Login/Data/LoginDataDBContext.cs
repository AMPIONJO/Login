using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Data
{
    public class LoginDataDBContext : DbContext
    {
        public LoginDataDBContext(DbContextOptions<LoginDataDBContext> options)
            : base(options)
        {

        }
        
        public DbSet<LoginData> LoginDatas { get; set; }
    }
}
