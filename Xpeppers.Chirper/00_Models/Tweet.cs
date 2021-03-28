using System;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public class Tweet : ITweet
    {
        public Tweet(IUser user, string text, DateTime dateAdded)
        {
            this.User = user;
            this.Text = text;
            this.DateAdded = dateAdded;
        }
        public Tweet(IUser user, string text) : this(user, text, DateTime.Now) { }

        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public IUser User { get; set; }
    }
}
