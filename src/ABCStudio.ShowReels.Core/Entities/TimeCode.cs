using ABCStudio.ShowReels.Core.Exceptions;

namespace ABCStudio.ShowReels.Core.Entities
{
    public class TimeCode
    {
        public TimeCode(int hours, int minutes, int seconds, int frames, int framesPerSecond)
        {
            if (framesPerSecond <= 1)
            {
                throw new ShowReelException("Number of frames per second should be greater than 1");
            }
            if (frames >= framesPerSecond)
            {
                throw new ShowReelException("Frames should be less than number of farmes per second");
            }
            if (hours < 0 || minutes < 0 || seconds < 0 || frames < 0)
            {
                throw new ShowReelException("Hours, minutes, seconds and frames should be greater than 0.");
            }
            if (minutes >= 60 || seconds >= 60)
            {
                throw new ShowReelException("Minutes and seconds should be less than 60.");
            }

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Frames = frames;
            FramesPerSecond = framesPerSecond;
        }

        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public int Frames { get; private set; }
        public int FramesPerSecond { get; set; }
        public int TotalFrames { get { return getTotalFrames(); } }

        private int getTotalFrames()
        {
            return Frames + (Seconds + Minutes * 60 + Hours * 3600) * FramesPerSecond;
        }

        private static void ValidateFrameReates(TimeCode a, TimeCode b)
        {
            if (a.FramesPerSecond != b.FramesPerSecond)
            {
                throw new ShowReelException("Number of frames per second should be same");
            }
        }

        private static void compare(TimeCode a, TimeCode b)
        {
            ValidateFrameReates( a, b);

        }

        public TimeCode AddTimeCodes(TimeCode timeCode)
        {
            ValidateFrameReates(this, timeCode);

            var totalFrames = Frames + timeCode.Frames;
            var calculatedSeconds = totalFrames / FramesPerSecond;
            var frames = totalFrames % FramesPerSecond;

            var totalSeconds = Seconds + timeCode.Seconds + calculatedSeconds;
            var calculatedMinutes = totalSeconds / 60;
            var seconds = totalSeconds % 60;

            var totalMinutes = Minutes + timeCode.Minutes + calculatedMinutes;
            var calculatedHours = totalMinutes / 60;
            var minutes = totalMinutes % 60;

            var totalHours = Hours + timeCode.Hours + calculatedHours;

            return new TimeCode(totalHours, minutes, seconds, frames, FramesPerSecond);
        }

        public static bool operator >=(TimeCode a, TimeCode b)
        {
            ValidateFrameReates(a, b);

            return a.TotalFrames >= b.TotalFrames;
        }


        public static bool operator >(TimeCode a, TimeCode b)
        {
            ValidateFrameReates(a, b);

            return a.TotalFrames > b.TotalFrames;
        }

        // This is not used in the code, but had to implemented to go with the operater ">=" above.
        public static bool operator <=(TimeCode a, TimeCode b)
        {
            ValidateFrameReates(a, b);

            return a.TotalFrames <= b.TotalFrames;
        }

        // This is not used in the code, but had to implemented to go with the operater ">" above.
        public static bool operator <(TimeCode a, TimeCode b)
        {
            ValidateFrameReates(a, b);

            return a.TotalFrames < b.TotalFrames;
        }
    }
}

