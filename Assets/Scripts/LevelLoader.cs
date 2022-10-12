using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
   
    public Slider slider;

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        

        while (!operation.isDone)
        {
            
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }
    
}
