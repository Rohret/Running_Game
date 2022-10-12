using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject inGameToggle;
    public GameObject TextShoes;
    float HighScoreATM;
    void Start()
    {
        inGameToggle.GetComponent<Toggle>().isOn = PlayerMovement.shoes;
        HighScoreATM = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (HighScoreATM > 500)
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
        print(HighScoreATM);
       
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void testClick()
    {
        print("click");
    }
    
}
