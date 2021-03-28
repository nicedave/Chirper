using System;

namespace Xpeppers.Chirper.Abstraction
{
    public interface ITweet
    {
        DateTime DateAdded { get; set; }
        string Text { get; set; }
        IUser User { get; set; }
    }
}