using ARTiculateDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARTiculateDataAccessLibrary.DataAccess
{
    class ArtistContext : DbContext
    {
        public ArtistContext(DbContextOptions options) : base(options) { }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArtItem> ArtItems { get; set; }
        public DbSet<Vernisage> Vernisages { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Studio> Studio { get; set; }
        public DbSet<Link> Link { get; set; }
    }
}
