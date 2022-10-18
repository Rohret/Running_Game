using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateArrowKeyUI : MonoBehaviour
{
    ArrowUI arrowUI;
    public GameObject arrow;
    void Start()
    {
        arrowUI = arrow.GetComponent<ArrowUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void activeUpKeey()
    {
        arrowUI.acitvateUIarrow();
    }
}
