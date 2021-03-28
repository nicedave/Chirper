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

            user.AddTweet(text);
            _userRepository.Save(user);
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

            user.AddFollowed(userToFollow);

            _userRepository.Save(user);
        }

        public void Unfollow(string UserName, string UserNameToUnFollow)
        {
            IUser user = _userRepository.Find(UserName);
            if (user == null)
            {
                return;
            }

            IUser userToUnfollow = _userRepository.Find(UserNameToUnFollow);
            if (userToUnfollow == null)
            {
                return;
            }

            user.RemoveFollowed(userToUnfollow);
         
            _userRepository.Save(user);
        }

        public List<ITweet> GetTweets(string UserName)
        {
            IUser user = _userRepository.Find(UserName);
            if (user == null)
            {
                return null;
            }

            return user.Tweets.OrderByDescending(t => t.DateAdded).ToList();
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
