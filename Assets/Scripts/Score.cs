using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    void Start()
    {
        Bird.instance.OnDied += BirdOnDied;
    }

    private static void BirdOnDied(object sender, System.EventArgs e)
    {
        TrySetNewHighscore(Bird.instance.ShowScore());
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("highscore");
    }

    public static bool TrySetNewHighscore(int score)
    {
        int currentHighscore = GetHighScore();
        if (score > currentHighscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            return true;
        }
        else { return false; }
    }
}
