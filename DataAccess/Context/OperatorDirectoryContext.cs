using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Context
{
    public partial class OperatorDirectoryContext : DbContext
    {
        public OperatorDirectoryContext()
        {
        }

        public OperatorDirectoryContext(DbContextOptions<OperatorDirectoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PhoneNumber> PhoneNumber { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.HasOne(d => d.PhoneNumber);
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.CostForMonth).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.PhoneNumber);
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}