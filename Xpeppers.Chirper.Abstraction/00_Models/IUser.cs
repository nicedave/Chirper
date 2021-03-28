using System.Collections.Generic;

namespace Xpeppers.Chirper.Abstraction
{
    public interface IUser
    {
        string Name { get; }
        ICollection<IUser> Followed { get; }
        ICollection<ITweet> Tweets { get; }

        void AddFollowed(IUser userToFollow);
        void RemoveFollowed(IUser userToUnfollow);
        ITweet AddTweet(string text);
    }
}