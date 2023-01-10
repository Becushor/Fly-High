using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public Text currentScoreText = null;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Bird.instance.CountScore();
        currentScoreText.text = Bird.instance.ShowScore().ToString();
    }
}
