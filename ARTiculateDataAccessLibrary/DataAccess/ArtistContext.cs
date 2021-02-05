using ARTiculateDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.DataAccess
{
    public class ArtistContext : DbContext
    {
        public ArtistContext(DbContextOptions options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtItem> ArtItems { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Vernisage> Vernisages { get; set; }
        public DbSet<Vernisage_Tag> Vernisage_Tags { get; set; }
        public DbSet<Exhibition_ArtItem> Exhibition_ArtItems { get; set; }
        public DbSet<Exhibition_Tag> Exhibition_Tags { get; set; }
        public DbSet<ArtItem_Tag> ArtItem_Tags { get; set; }
        public DbSet<Artist_Tag> Artist_Tags { get; set; }
        public DbSet<Artist_Exhibition> Artist_Exhibitions { get; set; }
        public DbSet<Artist_Vernisage> Artist_Vernisages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Exhibition>()
                .HasKey(ae => new { ae.ArtistId, ae.ExhibitionId });

            modelBuilder.Entity<Artist_Tag>()
              .HasKey(at => new { at.ArtistId, at.TagId });

            modelBuilder.Entity<Artist_Vernisage>()
                .HasKey(av => new { av.ArtistId, av.VernisageId });

            modelBuilder.Entity<ArtItem_Tag>()
                .HasKey(ait => new { ait.ArtItemId, ait.TagId });

            modelBuilder.Entity<Exhibition_Tag>()
                .HasKey(et => new { et.ExhibitionId, et.TagId });

            modelBuilder.Entity<Exhibition_ArtItem>()
                .HasKey(ea => new { ea.ExhibitionId, ea.ArtItemId });

            modelBuilder.Entity<Vernisage_Tag>()
               .HasKey(vt => new { vt.VernisageId, vt.TagId });

            modelBuilder.Entity<ArtItem>()
              .HasOne(a => a.Artist)
              .WithMany(a => a.ArtItems)
              .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(z => z.ArtistId);
                entity.HasOne(p => p.Artist)
                     .WithOne(a => a.Link)
                     .HasForeignKey<Link>(a => a.ArtistId);
            });
        }
    }
}
