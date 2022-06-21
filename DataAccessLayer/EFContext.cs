using DataAccessLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EFContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=EPUADNIW02B7;Initial Catalog=ContosoUniversity2;Integrated Security=True");
        }
    }
}
