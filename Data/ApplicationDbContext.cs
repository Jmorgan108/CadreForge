using CadreForge.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CadreForge.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Alignment> Alignments { get; set; }

        public DbSet<Faction> Factions { get; set; }

        public DbSet<Army> Armies { get; set; }

        public DbSet<ArmyList> ArmyLists { get; set; }

        public DbSet<ListUnit> ListUnits { get; set; }

        public DbSet<ListUnitModel> ListUnitModels { get; set; }

        public DbSet<ModelStatus> ModelStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alignment>()
                .HasOne(a => a.Game)
                .WithMany()
                .HasForeignKey(a => a.GameId)
                .OnDelete(DeleteBehavior.Cascade);
            // If Game is deleted, its Alignments should go too

            //(REQUIRED)
            modelBuilder.Entity<Faction>()
                .HasOne(f => f.Game)
                .WithMany()
                .HasForeignKey(f => f.GameId)
                .OnDelete(DeleteBehavior.Restrict);
            // Prevent deleting Game if factions exist

            // (OPTIONAL)
            modelBuilder.Entity<Faction>()
                .HasOne(f => f.Alignment)
                .WithMany()
                .HasForeignKey(f => f.AlignmentId)
                .OnDelete(DeleteBehavior.SetNull);
            // If Alignment deleted, faction still exists under Game

            modelBuilder.Entity<Army>()
                .HasOne(a => a.Game)
                .WithMany()
                .HasForeignKey(a => a.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Army>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArmyList>()
                .HasOne(l => l.Army)
                .WithMany(a => a.Lists)
                .HasForeignKey(l => l.ArmyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ListUnit>()
                .HasOne(u => u.ArmyList)
                .WithMany(l => l.Units)
                .HasForeignKey(u => u.ArmyListId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ListUnitModel>()
                .HasOne(m => m.ListUnit)
                .WithMany(u => u.Models)
                .HasForeignKey(m => m.ListUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ListUnitModel>()
                .HasOne(m => m.Status)
                .WithMany()
                .HasForeignKey(m => m.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
