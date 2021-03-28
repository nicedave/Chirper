using System.Collections.Generic;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public class User : IUser
    {
        public User(string userName)
        {
            this.Name = userName;
        }

        public string Name { get; private set; }

        public ICollection<ITweet> Tweets { get; set; }
        public ICollection<IUser> Followed { get; set; }
    }
}
