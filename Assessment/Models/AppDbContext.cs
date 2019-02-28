/**
 * 
 * name         :   AppDbContext.cs
 * author       :   Kevin McDonald
 * email        :   kevin.mcdonald@dundeeandangus.ac.uk
 * version      :   1.0
 * date         :   15th February 2019
 * description  :   Derived Database Context class for Database Interaction
 *
 * */
namespace Assessment.Models
{
    using System.Data.Entity;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=AppDbContext") { }

        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
    }
}
//--    End of File --//