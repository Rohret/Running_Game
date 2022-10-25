using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public GameObject inGameToggle;
    public GameObject TextShoes;
    public GameObject SpeakerOFF;
    float HighScoreATM;
    public Slider VolumeSlide;
    private float ScreenCalc;
    private bool pressedPlay = false;
    public TextMeshProUGUI TotalScore;
    public TextMeshProUGUI TotalRuns;
    void Start()
    {
        TotalRuns.text = "Number of runs " + PlayerPrefs.GetInt("NumberOfRuns", 0);
        TotalScore.text = "Total score " + PlayerPrefs.GetInt("TotalScore", 0);
        VolumeSlide.value = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        //print((PlayerPrefs.GetInt("Sound") == 1));
        inGameToggle.GetComponent<Toggle>().isOn = (PlayerPrefs.GetInt("Shoes") != 0);
        HighScoreATM = PlayerPrefs.GetInt("HighScore", 0);
        SpeakerOFF.SetActive((PlayerPrefs.GetInt("Sound") == 1));

        if((PlayerPrefs.GetInt("Sound") == 1))
        {
            AudioListener.volume = 0;
        }
        else
        {
            VolumeSlider(VolumeSlide.value);
        }


        //var identifier = SystemInfo.deviceModel;
        //if (identifier.StartsWith("iPad"))
        //{
        //    print("Ipad");
        //}
        //else
        //{
        //    print("Inte Ipad");
        //    print(identifier);
        //}
        ScreenCalc = (float)Screen.height / (float)Screen.width;
        //print(Screen.width);
        //print(Screen.height);
        //print(ScreenCalc);
        if(ScreenCalc > 0.68)
        {
            print("ipad");
        }
        pressedPlay = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HighScoreATM > 5000 || PlayerPrefs.GetInt("TotalScore", 0) > 100000)
        {
            TextShoes.SetActive(false);
            inGameToggle.GetComponent<Toggle>().interactable = true;
            inGameToggle.GetComponent<CanvasGroup>().alpha = 1f;
        }
        else
        {
            TextShoes.SetActive(true);
            inGameToggle.GetComponent<Toggle>().interactable = false;
            inGameToggle.GetComponent<CanvasGroup>().alpha = 0.3f;
            

        }
    }

    public void UserToggle(bool tog)
    {
        PlayerMovement.shoes = tog;
        PlayerPrefs.SetInt("Shoes", (tog ? 1 : 0));
       
       
    }

    public void PlayGame()
    {
      //  if (!pressedPlay)
      //  {
            pressedPlay = true;
            
            SceneManager.LoadScene(1);
       // }
        
    }

    public void testClick()
    {
       
    }

    public void muteFunction()
    {
        if (SpeakerOFF.activeInHierarchy)
        {
            SpeakerOFF.SetActive(false);
            PlayerPrefs.SetInt("Sound", 2);
            //AudioListener.volume = 1;
            VolumeSlider(VolumeSlide.value);

        }
        else
        {
            SpeakerOFF.SetActive(true);
            PlayerPrefs.SetInt("Sound", 1);
            AudioListener.volume = 0;
        }
        
    }

    public void VolumeSlider(float volume)
    {
        
        if (!SpeakerOFF.activeInHierarchy)
        {
            
            AudioListener.volume = volume;
            PlayerPrefs.SetFloat("SoundVolume", volume);
            

        }
        
    }
    
}
