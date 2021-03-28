using System.Collections.Generic;

namespace Xpeppers.Chirper.Abstraction
{
    public interface IOutputPrinter
    {
        void PrintTweets(List<ITweet> tweets, bool showUserName);
    }
}