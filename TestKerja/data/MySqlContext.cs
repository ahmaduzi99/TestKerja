using Microsoft.EntityFrameworkCore;
using TestKerja.Models;

namespace TestKerja.data
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions options) : base(options){}

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Agen> Agens { get; set; }

        public DbSet<Registrasi> Regis { get; set; }

        public DbSet<DataArray> dataArrays { get; set; }
    }
}
