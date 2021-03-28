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

        public ICollection<ITweet> Tweets { get; private set; }
        public ICollection<IUser> Followed { get; private set; }

        public void AddFollowed(IUser userToFollow)
        {
            if (Followed == null)
                Followed = new List<IUser>();

            Followed.Add(userToFollow);
        }
        public void RemoveFollowed(IUser userToUnfollow)
        {
            if (Followed == null)
                return;
         
            Followed.Remove(userToUnfollow);
        }

        public ITweet AddTweet(string text)
        {
            if (Tweets == null)
            {
                Tweets = new List<ITweet>();
            }

            Tweet newTweet = new Tweet(this, text);
            Tweets.Add(newTweet);

            return newTweet;
        }


    }
}
