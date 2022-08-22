using ABCStudio.ShowReels.Core.Enums;
using ABCStudio.ShowReels.Core.Exceptions;

namespace ABCStudio.ShowReels.Core.Entities
{
    public class ShowReel
    {
        public ShowReel(
            string name,
            string description,
            VideoStandard videoStandard,
            VideoDefinition videoDefinition,
            List<VideoClip> videoClips
            )
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ShowReelException("Name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ShowReelException("Description cannot be null or empty.");
            }

            if (videoClips == null || videoClips.Count < 1)
            {
                throw new ShowReelException("Atleast one video clip is required.");
            }

            //This condition is based on assumption that first video clip should start with 00:00:00:00:00 time code
            if (videoClips?.FirstOrDefault()?.StartTimeCode.TotalFrames != 0)
            {
                throw new ShowReelException("First video clip should start with 00:00:00:00:00 time code.");
            }

            for (int i = 0; i < videoClips.Count - 1; i++)
            {
                if (videoClips[i].EndTimeCode >= videoClips[i + 1].StartTimeCode)
                {
                    throw new ShowReelException("Video clips shoud not overlap.");
                }
            }

            var hasDifferentVideoStandard = videoClips.Exists(v => v.Standard != videoStandard);
            if (hasDifferentVideoStandard)
            {
                throw new ShowReelException("All video clips should have the same show reel standard.");
            }

            var hasDifferentVideoDefinition = videoClips.Exists(v => v.Definition != videoDefinition);
            if (hasDifferentVideoDefinition)
            {
                throw new ShowReelException("All video clips should have the same show reel definition.");
            }

            Name = name;
            Description = description;
            VideoStandard = videoStandard;
            VideoDefinition = videoDefinition;
            VideoClips = videoClips;
        }


        public string Name { get; private set; }
        public string Description { get; private set; }
        public VideoStandard VideoStandard { get; private set; }
        public VideoDefinition VideoDefinition { get; private set; }
        public List<VideoClip> VideoClips { get; private set; }
        public TimeCode TotalDuration
        {
            get
            {
                return VideoClips.Last().EndTimeCode;
            }
        }


        public void AddVideoClip(VideoClip videoClip)
        {
            if (videoClip.Standard != VideoStandard)
            {
                throw new ShowReelException("Video clip should have the same show reel standard.");
            }
            if (videoClip.Definition != VideoDefinition)
            {
                throw new ShowReelException("Video clip should have the same show reel definition.");
            }
            if (VideoClips.Last().EndTimeCode >= videoClip.StartTimeCode)
            {
                throw new ShowReelException("Video clips shoud not overlap.");
            }

            VideoClips.Add(videoClip);
        }
    }
}

