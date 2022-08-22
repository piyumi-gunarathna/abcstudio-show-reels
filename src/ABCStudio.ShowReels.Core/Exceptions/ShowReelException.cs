using System;
namespace ABCStudio.ShowReels.Core.Exceptions
{
    public class ShowReelException:Exception
    {

        public ShowReelException()
        {
        }

        public ShowReelException(string message)
            : base(message)
        {
        }
    }
}

