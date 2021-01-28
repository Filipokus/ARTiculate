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
        public DbSet<Studio> Studio { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Vernisage> Vernisages { get; set; }
        public DbSet<Vernisage_Tag> Vernisage_Tags { get; set; }
        public DbSet<Exhibition_Tag> Exhibition_Tags { get; set; }
        public DbSet<ArtItem_Tag> ArtItem_Tags { get; set; }
        public DbSet<Artist_Tag> Artist_Tags { get; set; }
        public DbSet<Studio_Tag> Studio_Tags { get; set; }
    }
}
