using System;
using ABCStudio.ShowReels.Core.Entities;
using ABCStudio.ShowReels.Core.Enums;
using ABCStudio.ShowReels.Core.Exceptions;

namespace ABCStudio.ShowReels.Core.Tests
{
    public class VideoClipTest
    {
        private const int fpsPAL = ((int)VideoStandard.PAL);
        private const int fpsNTSC = ((int)VideoStandard.NTSC);

        public VideoClipTest()
        {
        }


        [Fact]
        public void AllConstructorParametersShouldNotBeNullOrWhiteSpace()
        {
            Assert.Throws<ShowReelException>(() => new VideoClip(
                "",
                "AfactoryisworkingonthenewBudLightPlatinum.",
                VideoStandard.PAL, VideoDefinition.SD,
                new TimeCode(0, 0, 0, 0, fpsPAL), new TimeCode(0, 0, 30, 12, fpsPAL)));

            Assert.Throws<ShowReelException>(() => new VideoClip(
                "BudLight",
                "",
                VideoStandard.PAL, VideoDefinition.SD,
                new TimeCode(0, 0, 0, 0, fpsPAL), new TimeCode(0, 0, 30, 12, fpsPAL)));

            Assert.Throws<ShowReelException>(() => new VideoClip(
                "BudLight",
                "AfactoryisworkingonthenewBudLightPlatinum.",
                VideoStandard.PAL, VideoDefinition.SD,
                null, new TimeCode(0, 0, 30, 12, fpsPAL)));

            Assert.Throws<ShowReelException>(() => new VideoClip(
                "BudLight",
                "AfactoryisworkingonthenewBudLightPlatinum.",
                VideoStandard.PAL, VideoDefinition.SD,
                new TimeCode(0, 0, 0, 0, fpsPAL), null));

            Assert.True(new VideoClip(
                "BudLight",
                "AfactoryisworkingonthenewBudLightPlatinum.",
                VideoStandard.PAL, VideoDefinition.SD,
                new TimeCode(0, 0, 0, 0, fpsPAL),
                new TimeCode(0, 0, 30, 12, fpsPAL)) != null);
        }

        [Fact]
        public void EndTimeCodeShouldBeGreaterThanStartTimeCode()
        {
            Assert.Throws<ShowReelException>(() => new VideoClip(
                "BudLight",
                "AfactoryisworkingonthenewBudLightPlatinum.",
                VideoStandard.PAL, VideoDefinition.SD,
                new TimeCode(0, 0, 30, 12, fpsPAL),
                new TimeCode(0, 0, 0, 0, fpsPAL)));
         }

        [Fact]
        public void StartndEndTimeCodesShouldHaveSameFramesPerSecond()
        {
            Assert.Throws<ShowReelException>(() => new VideoClip(
                "BudLight",
                "AfactoryisworkingonthenewBudLightPlatinum.",
                VideoStandard.PAL, VideoDefinition.SD,
                new TimeCode(0, 0, 0, 0, fpsPAL),
                new TimeCode(0, 0, 30, 12, fpsNTSC)));
        }
    }
}

