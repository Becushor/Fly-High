using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text finalScoreText;
    public Text highScoreText;

    void Start()
    {
        Bird.instance.OnDied += BirdOnDied;
        HideWindow();
    }

    private void BirdOnDied(object sender, System.EventArgs e)
    {
        finalScoreText.text = Bird.instance.ShowScore().ToString();

        if (Bird.instance.ShowScore() > Score.GetHighScore())
        {
            highScoreText.text = "NEW HIGHSCORE";
        }
        else
        {
            highScoreText.text = "HIGHSCORE " + Score.GetHighScore();
        }
        ShowWindow();
    }

    private void ShowWindow()
    {
        gameObject.SetActive(true);
    }

    private void HideWindow()
    {
        gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
