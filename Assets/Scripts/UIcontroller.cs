using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIcontroller : MonoBehaviour
{


    PlayerMovement player;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI HighScore;
    //Text distanceText;
    //Text coinText;
    //Text HighScore;
    private int HighScoreATM = 0;
    private Animator animator;
    private int score;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        //coinText = GameObject.Find("Coins").GetComponent<Text>();
        //distanceText = GameObject.Find("Distance").GetComponent<Text>();
        //HighScore = GameObject.Find("HighScore").GetComponent<Text>();
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        // uncomment to reset highscore
        //PlayerPrefs.SetInt("HighScore", 0);
        HighScoreATM = PlayerPrefs.GetInt("HighScore",0);
        HighScore.text =  "High Score " + HighScoreATM.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        int distance = Mathf.FloorToInt(player.distance);
        score = distance + coinScript.numberOfCoins * 20;
        //int distance = Mathf.FloorToInt(racoon.distance);
        distanceText.text = distance + " m";
        coinText.text = coinScript.numberOfCoins + " coins";
        if (HighScoreATM < score)
        {
            HighScore.text = "High Score " + score;
            PlayerPrefs.SetInt("HighScore", score);
        }

    }


    public void ActivateAnimations()
    {
        animator.SetTrigger("Distance_animation");
    }
}
