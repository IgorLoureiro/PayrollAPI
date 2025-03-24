using System.Data.Entity;
using PayrollApi.Models;

namespace PayrollApi.Data
{
    public class DbContextOracle : DbContext
    {
        public DbContextOracle() : base("OracleDbConnection"){}
        
        public DbSet<Payroll> Payrolls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = "C##PAYROLDB";

            modelBuilder.HasDefaultSchema(schema);

            base.OnModelCreating(modelBuilder);
        }

    }
}