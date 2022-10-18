using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject inGameToggle;
    public GameObject TextShoes;
    public GameObject SpeakerOFF;
    float HighScoreATM;
    public Slider VolumeSlide;
    void Start()
    {
        VolumeSlide.value = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        print((PlayerPrefs.GetInt("Sound") == 1));
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HighScoreATM > 5000)
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
        SceneManager.LoadScene(1);
    }

    public void testClick()
    {
        print("click");
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
            print("heere");
            AudioListener.volume = volume;
            PlayerPrefs.SetFloat("SoundVolume", volume);
            Debug.Log(volume);

        }
        
    }
    
}
