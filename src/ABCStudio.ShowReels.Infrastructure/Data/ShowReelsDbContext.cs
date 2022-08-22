using ABCStudio.ShowReels.Core.Entities;
using ABCStudio.ShowReels.Infrastructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ABCStudio.ShowReels.Infrastructure.Data
{
    public class ShowReelsDbContext: DbContext
    {
        public ShowReelsDbContext(DbContextOptions<ShowReelsDbContext> options) : base(options)
        {
        }

        internal DbSet<VideoClip> VideoClips { get; set; }
        internal DbSet<ShowReelDbModel> ShowReels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VideoClipEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShowReelEntityConfiguration());
        }
    }
}

