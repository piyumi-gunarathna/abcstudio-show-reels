using System;
using ABCStudio.ShowReels.Core.Entities;
using ABCStudio.ShowReels.Core.Interfaces;
using static ABCStudio.ShowReels.Infrastructure.Data.ShowReelRepository;

namespace ABCStudio.ShowReels.Infrastructure.Data
{
    public class ShowReelRepository : IShowReelRepository
    {
        private readonly ShowReelsDbContext _dbContext;

        public ShowReelRepository(ShowReelsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ShowReel Create(ShowReel showReel)
        {
            _dbContext.Database.EnsureCreated();

            var showReelDbModel = new ShowReelDbModel();
            showReelDbModel.Name = showReel.Name;
            showReelDbModel.Description = showReel.Description;
            showReelDbModel.VideoDefinition = showReel.VideoDefinition;
            showReelDbModel.VideoStandard = showReel.VideoStandard;
            showReelDbModel.VideoClips = showReel.VideoClips;

            _dbContext.ShowReels.Add(showReelDbModel);
            _dbContext.SaveChanges();
            return showReel;
        }

        public IEnumerable<ShowReel> Get()
        {
            _dbContext.Database.EnsureCreated();

            var showReels = _dbContext.ShowReels
                .Where(s => s.Id > 0)
                .Select(s => new ShowReel(
                        s.Name,
                        s.Description,
                        s.VideoStandard,
                        s.VideoDefinition,
                        s.VideoClips
                    )).ToList();

            return showReels;
        }
    }

}

