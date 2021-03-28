using System;
using System.Collections.Generic;
using System.Linq;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public class ConsoleOutputPrinter : IOutputPrinter
    {
        private IDateFormatter _dateFormatter;
        public ConsoleOutputPrinter(IDateFormatter dateFormatter)
        {
            _dateFormatter = dateFormatter;
        }

        public void PrintTweets(List<ITweet> tweets, bool showUserName)
        {
            if (tweets == null)
                return;

            foreach (ITweet tweet in tweets.OrderByDescending(t => t.DateAdded))
            {
                //if (tweet == null)
                //    continue;

                Console.Write(" - ");
                Console.WriteLine(BuildTweetData(tweet, showUserName));
            }
        }

        private string BuildTweetData(ITweet tweet, bool showUserName)
        {
            string user = "";
            if (showUserName == true)
            {
                user = tweet.User.Name.FirstCharToUpper() + " - ";
            }

            return string.Format("{0}{1} {2}",
                user,
                tweet.Text,
                _dateFormatter.FormatDate(tweet.DateAdded));
        }


    }
}
