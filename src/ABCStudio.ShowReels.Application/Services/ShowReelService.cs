using System;
using System.Xml.Linq;
using ABCStudio.ShowReels.Application.DTOs;
using ABCStudio.ShowReels.Core.Entities;
using ABCStudio.ShowReels.Core.Enums;
using ABCStudio.ShowReels.Core.Interfaces;

namespace ABCStudio.ShowReels.Application.Services
{
    public class ShowReelService
    {
        private readonly IShowReelRepository _showReelRepository;

        public ShowReelService(IShowReelRepository showReelRepository)
        {
            _showReelRepository = showReelRepository;
        }

        public List<ShowReelDTO> GetShowReels()
        { 
            var showReels = _showReelRepository.Get().Select(s => new ShowReelDTO
            {
                Name = s.Name,
                Description = s.Description,
                VideoClips = s.VideoClips.Select(v => new VideoClipDTO(v)).ToArray(),
                VideoDefinition = s.VideoDefinition,
                VideoStandard =s.VideoStandard
            }).ToList();

            return showReels;
        }

        public ShowReelDTO CreateShowReel(ShowReelDTO request)
        {
            var videoClips = request.VideoClips.Select(v =>
            new VideoClip(
                    v.Name,
                    v.Description,
                    v.Standard,
                    v.Definition,
                    new TimeCode(
                        v.StartTimeCode.Hours,
                        v.StartTimeCode.Minutes,
                        v.StartTimeCode.Seconds,
                        v.StartTimeCode.Frames,
                        (int)v.Standard
                        ),
                    new TimeCode(
                        v.EndTimeCode.Hours,
                        v.EndTimeCode.Minutes,
                        v.EndTimeCode.Seconds,
                        v.EndTimeCode.Frames,
                        (int)v.Standard
                        )
                )).ToList();

            var showReel = new ShowReel(
                request.Name,
                request.Description,
                request.VideoStandard,
                request.VideoDefinition,
                videoClips);

            _showReelRepository.Create(showReel);
            return new ShowReelDTO();
        }

    }
}

