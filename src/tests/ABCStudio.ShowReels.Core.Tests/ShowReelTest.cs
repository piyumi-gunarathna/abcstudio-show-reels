using ABCStudio.ShowReels.Core.Entities;
using ABCStudio.ShowReels.Core.Enums;
using ABCStudio.ShowReels.Core.Exceptions;

namespace ABCStudio.ShowReels.Core.Tests
{
    public class ShowReelTest
    {
        public ShowReelTest()
        {
        }

        [Fact]
        public void AllConstructorParametersShouldNotBeNullOrWhiteSpace()
        {
            Assert.Throws<ShowReelException>(() => new ShowReel(
                null,
                "Show Reel Description",
                VideoStandard.PAL,
                VideoDefinition.SD,
                new List<VideoClip>()));

            Assert.Throws<ShowReelException>(() => new ShowReel(
                "ShowReel1",
                null,
                VideoStandard.PAL,
                VideoDefinition.SD,
                new List<VideoClip>()));
        }

        [Fact]
        public void VideoClipShouldHaveTheSameShowReelStandard()
        {
            Assert.Throws<ShowReelException>(() => new ShowReel(
                   "ShowReel1",
                   "Show Reel Description",
                   VideoStandard.PAL,
                   VideoDefinition.SD,
                   new List<VideoClip>() {
                    new VideoClip(
                        "BudLight",
                        "AfactoryisworkingonthenewBudLightPlatinum.",
                        VideoStandard.NTSC,
                        VideoDefinition.SD,
                        new TimeCode(0, 0, 0, 0, (int)VideoStandard.PAL),
                        new TimeCode(0, 0, 30, 12, (int)VideoStandard.PAL))
                   }));
        }

        [Fact]
        public void ShowReelShouldHaveAtleastOneVideoClip()
        {
            Assert.Throws<ShowReelException>(() => new ShowReel(
                "ShowRee1",
                "Show Reel Description",
                VideoStandard.PAL,
                VideoDefinition.SD,
                new List<VideoClip>()));

            Assert.True(new ShowReel(
                    "ShowReel1",
                    "Show Reel Description",
                    VideoStandard.PAL,
                    VideoDefinition.SD,
                    new List<VideoClip>() {
                        new VideoClip(
                        "BudLight",
                        "AfactoryisworkingonthenewBudLightPlatinum.",
                        VideoStandard.PAL,
                        VideoDefinition.SD,
                        new TimeCode(0, 0, 0, 0, (int)VideoStandard.PAL),
                        new TimeCode(0, 0, 30, 12, (int)VideoStandard.PAL))
                    }) != null);
        }

        [Fact]
        public void VideoClipsWithDifferectDefinitionShouldThrowException()
        {
            Assert.Throws<ShowReelException>(() => new ShowReel(
                "ShowReel1",
                "Show Reel Description",
                VideoStandard.PAL,
                VideoDefinition.SD,
                new List<VideoClip>() {
                    new VideoClip(
                        "BudLight",
                        "AfactoryisworkingonthenewBudLightPlatinum.",
                        VideoStandard.PAL,
                        VideoDefinition.SD,
                        new TimeCode(0, 0, 0, 0, (int)VideoStandard.PAL),
                        new TimeCode(0, 0, 30, 12, (int)VideoStandard.PAL)),
                    new VideoClip(
                        "CaptainAmericaTheFirstAvenger",
                        "VideoPromo",
                        VideoStandard.NTSC,
                        VideoDefinition.HD,
                        new TimeCode(0, 0, 30, 13, (int)VideoStandard.PAL),
                        new TimeCode(0, 1, 30, 0, (int)VideoStandard.PAL)),
                }));

        }

        [Fact]
        public void CorrectVideoClipShouldBeAbleToAddToVideoClips()
        {
            var showReel = new ShowReel(
                "ShowReel1",
                "Show Reel Description",
                VideoStandard.PAL,
                VideoDefinition.SD,
                new List<VideoClip>() {
                    new VideoClip(
                        "BudLight",
                        "AfactoryisworkingonthenewBudLightPlatinum.",
                        VideoStandard.PAL,
                        VideoDefinition.SD,
                        new TimeCode(0, 0, 0, 0, (int)VideoStandard.PAL),
                        new TimeCode(0, 0, 30, 12, (int)VideoStandard.PAL)),
                });

            Assert.True(showReel.VideoClips.Count == 1);

            showReel.AddVideoClip(
                    new VideoClip(
                        "CaptainAmericaTheFirstAvenger",
                        "VideoPromo",
                        VideoStandard.PAL,
                        VideoDefinition.SD,
                       new TimeCode(0, 0, 30, 13, (int)VideoStandard.PAL),
                        new TimeCode(0, 1, 10, 0, (int)VideoStandard.PAL)
                    )
                );

            Assert.True(showReel.VideoClips.Count == 2);
        }
    }
}

