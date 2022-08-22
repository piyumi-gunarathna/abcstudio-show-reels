using System;
using ABCStudio.ShowReels.Core.Enums;
using ABCStudio.ShowReels.Core.Exceptions;

namespace ABCStudio.ShowReels.Core.Entities
{
    public class VideoClip
    {
        public VideoClip(
            string name,
            string description,
            VideoStandard standard,
            VideoDefinition definition,
            TimeCode startTimeCode,
            TimeCode endTimeCode
            )
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                throw new ShowReelException("Name and description cannot be null or empty.");
            }

            if (startTimeCode == null || endTimeCode == null)
            {
                throw new ShowReelException("Start and End timecodes cannot be null.");
            }

            if (startTimeCode.FramesPerSecond != endTimeCode.FramesPerSecond)
            {
                throw new ShowReelException("Start and end timecodes should have the equal number of frames per second");
            }

            if (startTimeCode >= endTimeCode)
            {
                throw new ShowReelException("End time code should be grater than start time code.");
            }

            Name = name;
            Description = description;
            Standard = standard;
            Definition = definition;
            StartTimeCode = startTimeCode;
            EndTimeCode = endTimeCode;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public VideoStandard Standard { get; private set; }
        public VideoDefinition Definition { get; private set; }
        public TimeCode StartTimeCode { get; private set; }
        public TimeCode EndTimeCode { get; private set; }
    }
}

