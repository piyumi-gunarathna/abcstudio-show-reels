using ABCStudio.ShowReels.Core.Entities;

namespace ABCStudio.ShowReels.Core.Interfaces
{
    public interface IShowReelRepository
    {
        ShowReel Create(ShowReel showReel);
        IEnumerable<ShowReel> Get();
    }
}

