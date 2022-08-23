using ABCStudio.ShowReels.Core.Entities;
using ABCStudio.ShowReels.Core.Enums;

namespace ABCStudio.ShowReels.Application.DTOs
{
    public class VideoClipDTO
    {
        public VideoClipDTO()
        {
        }

        public VideoClipDTO(VideoClip videoClip)
        {
            Name = videoClip.Name;
            Description = videoClip.Description;
            Definition = videoClip.Definition;
            Standard = videoClip.Standard;
            StartTimeCode = new TimeCodeDTO(videoClip.StartTimeCode);
            EndTimeCode = new TimeCodeDTO(videoClip.EndTimeCode);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public VideoStandard Standard { get; set; }
        public VideoDefinition Definition { get; set; }
        public TimeCodeDTO StartTimeCode { get; set; }
        public TimeCodeDTO EndTimeCode { get; set; }
    }
}

