using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotter : MonoBehaviour
{
    private int count = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Nu");
           ScreenCapture.CaptureScreenshot(@"C:\Users\rohre\OneDrive\Bilder\Screenshotstoappstore\screenshot" + count++ +".png");
        }
    }
}
