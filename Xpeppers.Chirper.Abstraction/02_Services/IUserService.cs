using System.Collections.Generic;

namespace Xpeppers.Chirper.Abstraction
{
    public interface IUserService
    {
        IUser Find(string UserName);
        IUser Register(string UserName);

        void Follow(string UserName, string UserNameToFollow);
        void Unfollow(string UserName, string UserNameToUnfollow);

        void Tweet(string UserName, string text);

        List<ITweet> GetTweets(string UserName);
        List<ITweet> GetWall(string UserName);
    }
}