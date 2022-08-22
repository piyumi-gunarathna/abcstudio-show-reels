using ABCStudio.ShowReels.Core.Entities;
using ABCStudio.ShowReels.Core.Enums;
using ABCStudio.ShowReels.Core.Exceptions;

namespace ABCStudio.ShowReels.Core.Tests
{
    public class TimeCodeTest
    {
        private const int fpsPAL = ((int)VideoStandard.PAL);
        private const int fpsNTSC = ((int)VideoStandard.NTSC);


        public TimeCodeTest()
        {
        }

        [Fact]
        public void FramePerSecondsShouldBeGreaterThan0()
        {
            Assert.Throws<ShowReelException>(() => new TimeCode(1, 1, 1, 1, 0));
            Assert.True(new TimeCode(1, 1, 1, 1, fpsNTSC) != null);
        }

        [Fact]
        public void FramesShouldBeLessThanFramesPerSecond()
        {
            Assert.Throws<ShowReelException>(() => new TimeCode(1, 1, 1, 50, fpsNTSC));
            Assert.True(new TimeCode(1, 1, 1, fpsNTSC - 1, fpsNTSC) != null);
        }

        [Fact]
        public void AllParametersShouldBePositive()
        {
            Assert.Throws<ShowReelException>(() => new TimeCode(-1, 1, 1, 1, fpsNTSC));
            Assert.Throws<ShowReelException>(() => new TimeCode(1, -1, 1, 1, fpsNTSC));
            Assert.Throws<ShowReelException>(() => new TimeCode(1, 1, -1, 1, fpsNTSC));
            Assert.Throws<ShowReelException>(() => new TimeCode(1, 1, 1, -1, fpsNTSC));
            Assert.True(new TimeCode(1, 1, 1, 1, fpsNTSC) != null);
        }

        [Fact]
        public void TimeCodeSecondsShouldBeLessThan60()
        {
            Assert.Throws<ShowReelException>(() => new TimeCode(1, 1, 80, 1, fpsPAL));
            Assert.True(new TimeCode(1, 1, 59, 1, fpsNTSC) != null);
        }

        [Fact]
        public void TimeCodeMinutesShouldBeLessThan60()
        {
            Assert.Throws<ShowReelException>(() => new TimeCode(1, 80, 1, 1, fpsPAL));
            Assert.True(new TimeCode(1, 59, 1, 1, fpsNTSC) != null);
        }

        [Fact]
        public void AddTimeCodesWithDiffenetStandardsShouldThrowError()
        {
            var timeCode1 = new TimeCode(1, 1, 1, 1, fpsNTSC);
            var timeCode2 = new TimeCode(1, 1, 1, 1, fpsPAL);
            Assert.Throws<ShowReelException>(() => timeCode1.AddTimeCodes(timeCode2));
        }

        [Fact]
        public void TimeCodesWithDiffenetFramesPerSecondsShouldThrowError()
        {
            var timeCode1 = new TimeCode(1, 1, 1, 1, fpsPAL);
            var timeCode2 = new TimeCode(2, 1, 1, 1, fpsNTSC);

            Assert.Throws<ShowReelException>(() => timeCode1 < timeCode2);
            Assert.Throws<ShowReelException>(() => timeCode2 > timeCode1);
        }

        [Fact]
        public void ComparisonOfTwoTimeCodesShouldGiveBooleanReturn()
        {
            var timeCode1 = new TimeCode(1, 1, 1, 1, fpsNTSC);
            var timeCode2 = new TimeCode(10, 1, 1, 1, fpsNTSC);

            Assert.True(timeCode2 > timeCode1);
            Assert.True(timeCode2 >= timeCode1);
            Assert.False(timeCode2 < timeCode1);
            Assert.False(timeCode2 <= timeCode1);
        }

    }

}

