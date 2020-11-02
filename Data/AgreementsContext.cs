using Interviu.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Interviu.Data
{
    public class AgreementsContext : DbContext
    {
        public AgreementsContext(DbContextOptions<AgreementsContext> opt) : base(opt)
        {

        }

        public DbSet<Agreement> Agreements { get; set; }

    }
}
