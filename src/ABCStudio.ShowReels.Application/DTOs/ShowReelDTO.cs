using System;
using ABCStudio.ShowReels.Core.Enums;

namespace ABCStudio.ShowReels.Application.DTOs
{
    public class ShowReelDTO
    {
        public ShowReelDTO()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public VideoStandard VideoStandard { get; set; }
        public VideoDefinition VideoDefinition { get; set; }
        public VideoClipDTO[] VideoClips { get; set; }
    }
}

