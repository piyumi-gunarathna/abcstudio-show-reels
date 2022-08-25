namespace ABCStudio.ShowReels.Core.Enums
{
    public enum VideoStandard
    {
        //number of frames per seconds is used as values.
        PAL = 1,
        NTSC = 2
    }

    public class VideoStandardFrameRates
    {
        public static int GetFrameRate(VideoStandard videoStandard)
        {
            if (videoStandard == VideoStandard.PAL)
            {
                return 25;
            }

            return 30;
        }
    }
}

