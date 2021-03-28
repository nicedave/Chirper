using System.Collections.Generic;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public class FakeChirperContext : IChirperContext
    {
        public ICollection<IUser> Users { get; set; }

        public FakeChirperContext()
        {
            List<IUser> users = new List<IUser>();

            var alice = new User("Alice");
            var bob = new User("Bob");
            var charlie = new User("Charlie");

            alice.Tweets = new List<ITweet>();
            alice.Tweets.Add(new Tweet(alice, "I love the weather today"));

            bob.Tweets = new List<ITweet>();
            bob.Tweets.Add(new Tweet(bob, "Damn! We lost!"));
            bob.Tweets.Add(new Tweet(bob, "Good game though."));

            //pippo.Followed.Add(anna);
            //pippo.Tweets.Add(new BaseTweet(pippo, "ciao sono pippo"));
            //pippo.Tweets.Add(new BaseTweet(pippo, "bello questo twitter"));

            users.Add(alice);
            users.Add(bob);
            users.Add(charlie);

            Users = users;
        }
    }
}
