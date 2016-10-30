using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System.Collections.Generic;

public class GooglePlay : MonoBehaviour
{

    public enum Achievement
    {
        Meters50,
        Meters100,
        Meters150,
        Meters200,
        Meters250,
    }

    public Dictionary<Achievement, string> Achievements = new Dictionary<Achievement, string>()
    {
        {Achievement.Meters50, "CgkIgJf9lrQZEAIQAQ"},
        {Achievement.Meters100, "CgkIgJf9lrQZEAIQAg"},
        {Achievement.Meters150, "CgkIgJf9lrQZEAIQAw"},
        {Achievement.Meters200, "CgkIgJf9lrQZEAIQBA"},
        {Achievement.Meters250, "CgkIgJf9lrQZEAIQBQ"}
    };

    //leaderboard strings
    private string leaderboard = "CgkIgJf9lrQZEAIQBg";
    //achievement strings
    //private string achievement = "CgkI966C18cCEAIQAQ";
    //private string incremental = "CgkI966C18cCEAIQAg";

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        PlayGamesPlatform.Activate();
        LogIn();
    }


    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("You've successfully logged in");
            }
            else
            {
                Debug.Log("Login failed for some reason");
            }
        });
    }

    public void CompleteAchievement(string achievementID)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100.0f, (bool success) => 
            {
                
            });
        }
    }

    public void IncrementAchievement(string achievementID)
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.IncrementAchievement(achievementID, 1, (bool success) =>
            {
                //The achievement unlocked successfully
            });
        }
    }

    public void ReportLeaderBoardScore(int metersTraveled)
    {
        //Post your points to the leaderboard
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(metersTraveled, leaderboard, (bool success) =>
            {
                if (success)
                {
                    //((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
                }
                else
                {
                    //Debug.Log("Login failed for some reason");
                }
            });
        }
    }

    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    public void ShowSpecificLeaderBoard()
    {
        //Show Specific Leaderboard
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
    }

    public void ShowAchievements()
    {
        Social.ShowAchievementsUI();
    }

    public void SignOut()
    {
        PlayGamesPlatform.Instance.SignOut();
    }

}
