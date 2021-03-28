using System.Collections.Generic;

namespace Xpeppers.Chirper.Abstraction
{
    public interface IUser
    {
        ICollection<IUser> Followed { get; set; }
        string Name { get; }
        ICollection<ITweet> Tweets { get; set; }
    }
}