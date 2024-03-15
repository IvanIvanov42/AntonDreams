using Microsoft.EntityFrameworkCore;

namespace AntonApi.Models
{
    public partial class DreamContext : DbContext
    {
        public DreamContext(DbContextOptions<DreamContext> options)
           : base(options)
        {
        }
        public virtual DbSet<Dream> Dream { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dream>(entity => {
                entity.HasKey(k => k.Id);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
