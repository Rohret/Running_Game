using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
   
    public Slider slider;
    private bool pressedPlay;

    private void Start()
    {
        pressedPlay = false;
    }

    public void LoadLevel()
    {
        if (!pressedPlay)
        { 

            pressedPlay = true;
            StartCoroutine(LoadAsynchronously());
        }
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        

        while (!operation.isDone)
        {
            
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;
            //Debug.Log(progress);
            yield return null;
        }
    }
    
}
