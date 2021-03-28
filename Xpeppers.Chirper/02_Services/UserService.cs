using System.Collections.Generic;
using System.Linq;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IUser Find(string UserName)
        {
            return _userRepository.Find(UserName);
        }

        public IUser Register(string UserName)
        {
            IUser existingUser = _userRepository.Find(UserName);
            if (existingUser != null)
            {
                return existingUser;
            }

            return _userRepository.Add(UserName);
        }

        public void Tweet(string UserName, string text)
        {
            IUser user = _userRepository.Find(UserName);
            
            if (user == null)
            {
                user = _userRepository.Add(UserName);
            }

            if (user.Tweets == null)
            {
                user.Tweets = new List<ITweet>();
            }

            user.Tweets.Add(new Tweet(user, text));
        }

        public void Follow(string UserName, string UserNameToFollow)
        {
            IUser user = _userRepository.Find(UserName);
            if (user == null)
            {
                return;
            }

            IUser userToFollow = _userRepository.Find(UserNameToFollow);
            if (userToFollow == null)
            {
                return;
            }

            if (user.Followed == null)
                user.Followed = new List<IUser>();

            user.Followed.Add(userToFollow);
        }

        public void Unfollow(string UserName, string UserNameToUnFollow)
        {
            IUser user = _userRepository.Find(UserName);
            if (user == null)
            {
                return;
            }

            if (user.Followed == null)
                return;

            IUser userToUnfollow = _userRepository.Find(UserNameToUnFollow);

            if (userToUnfollow == null)
                return;
            
            user.Followed.Remove(userToUnfollow);
        }

        public List<ITweet> GetTweets(string UserName)
        {
            IUser user = _userRepository.Find(UserName);
            if (user == null)
            {
                return null;
            }

            return user.Tweets?.OrderByDescending(t => t.DateAdded).ToList();
        }

        public List<ITweet> GetWall(string UserName)
        {
            IUser user = _userRepository.Find(UserName);
            if (user == null)
            {
                return null;
            }

            List<ITweet> allTweets = new List<ITweet>();
            if (user.Tweets != null)
            {
                allTweets.AddRange(user.Tweets);
            }

            if (user.Followed != null)
            {
                allTweets.AddRange((from f in user.Followed
                                    where f.Tweets != null
                                    from t in f.Tweets
                                    select t));
            }

            return allTweets.OrderByDescending(t => t.DateAdded).ToList();
        }
    }
}
