using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Advertisements;
public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject AdCanvas;
    public float growRate = 1;
    private bool textAnimActivate = false;
    private float score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI CopyCoin;
    public TextMeshProUGUI CopyDistance;
    PlayerMovement player;
    public Health health;
    public AfterAdWall afterAdWall;
    public float TimerToScore = 0;
    public float TimerStart = 0;
    public float Scorestart = 0;
    private float timeScore = 1;
    private Vector3 startPos;
    public float timerAfterAd = 0;
    public bool timerAfterAdStart = false;
    public float startGameAfterAd = 10;
    [SerializeField] RewardedAdsButton rewardedAdsButton;
    public static int NumberOfAdsCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        startPos = player.transform.position;
        gameOverCanvas.SetActive(false);
        AdCanvas.SetActive(false);
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

        if (timerAfterAdStart)
        {
            timerAfterAd += Time.unscaledDeltaTime;
            if (timerAfterAd > startGameAfterAd)
            {
                timerAfterAdStart = false;
                timerAfterAd = 0;
                StartTime();
                
            }
        }

        
    }

    public void GameOver()
    {
        if(NumberOfAdsCounter == 0)
        {

            rewardedAdsButton.LoadAd();
            AdCanvas.SetActive(true);
            Time.timeScale = 0;
            NumberOfAdsCounter = 1;

        }
        else
        {
            
            RealGameover();
           
        }

    }

    public void RealGameover()
    {
        //uncomment if app should have 0 highscore
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        AdCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        textAnimActivate = true;
        Time.timeScale = 0;
        NumberOfAdsCounter = 0;
        //print(startPos.x);
        //print(startPos.y);
        //print(startPos.z);


    }

    public void Rewarded()
    {
        
        deleteAllWalls();
        health.numOfHearts = 2;
        AdCanvas.SetActive(false);
        timerAfterAdStart = true;
        player.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
        afterAdWall.spawnWallAfterAd();
        player.velocity.x = 20;
       
    }

    public void StartTime()
    {

        Time.timeScale = 1;

    }


    public void Replay()
    {
       SceneManager.LoadScene(1);
       //coinScript.numberOfCoins = 0;
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(0);
        //coinScript.numberOfCoins = 0;
    }

    public void deleteAllWalls()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Walls");
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        } 

    }

    }
