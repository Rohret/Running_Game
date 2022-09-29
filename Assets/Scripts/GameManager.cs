using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public float growRate = 1;
    private bool textAnimActivate = false;
    private float score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI CopyCoin;
    public TextMeshProUGUI CopyDistance;
    PlayerMovement player;
    public float TimerToScore = 0;
    public float TimerStart = 0;
    public float Scorestart = 0;
    private float timeScore = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        textAnimActivate = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        CopyCoin.text = coinScript.numberOfCoins.ToString() + "x20";
        CopyDistance.text = ((int)player.distance).ToString();
       // CopyCoin.text = "aa"+"x30";
        if (textAnimActivate)
        {
            float scorecheck = player.distance + coinScript.numberOfCoins * 20;
            if(scorecheck > 500)
            {
                timeScore = 0.0001f;
                
            }
            else
            {
                timeScore = 0.001f;
            }
            TimerStart += Time.unscaledDeltaTime;
            if (TimerStart > Scorestart)
            {
                if (TimerToScore > timeScore)
                {
                    if (score <= (player.distance + coinScript.numberOfCoins * 20) - 3 * growRate)
                    {
                        scoreText.text = score.ToString() + " points";
                        TimerToScore = 0;
                        score += growRate;

                    }
                    else if (score <= player.distance + coinScript.numberOfCoins * 20)
                    {

                        scoreText.text = score.ToString() + " points";
                        TimerToScore = 0;
                        score += 1;
                    }
                }
                TimerToScore += Time.unscaledDeltaTime;
            }
        }
        
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        textAnimActivate = true;
        Time.timeScale = 0;
    }

    public void Replay()
    {
       SceneManager.LoadScene(1);
       coinScript.numberOfCoins = 0;
    }
}
