using ABCStudio.ShowReels.Core.Entities;

namespace ABCStudio.ShowReels.Application.DTOs
{
    public class TimeCodeDTO
    {
        public TimeCodeDTO()
        {
        }

        public TimeCodeDTO(TimeCode timeCode)
        {
            Hours = timeCode.Hours;
            Minutes = timeCode.Minutes;
            Seconds = timeCode.Seconds;
            Frames = timeCode.Frames;
        }

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Frames { get; set; }
    }
}

