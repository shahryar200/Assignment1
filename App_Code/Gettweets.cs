using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Gettweets
{
        private SingleUserAuthorizer authorizer =
         new SingleUserAuthorizer
         {
             CredentialStore =
            new SingleUserInMemoryCredentialStore
            {
                ConsumerKey =
                "qztDMgZkSDpFqBHCCxTt5pRBn",
                ConsumerSecret =
               "H4kg1oLIhiIT21eSOscMrWrdpzu9SA3zjEOI7eN2K0on9r4jLQ",
            }
         };
    public List<Status> currentTweets;
    public void GetMostRecent25TimeLine()
    {
        var twitterContext = new TwitterContext(authorizer);

        var tweets = from tweet in twitterContext.Status
                     where tweet.Type == StatusType.User &&
                           tweet.ScreenName == "realDonaldTrump" &&
                           tweet.Count == 25
                     select tweet;

        currentTweets = tweets.ToList();
    }
}