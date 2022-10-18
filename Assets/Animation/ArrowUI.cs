using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUI : MonoBehaviour
{
    public float timerArrow = 0;
    public bool timerArrowActive = false;
    public Animator animator;
    void Start()
    {
        gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerArrowActive)
        {
            timerArrow += Time.deltaTime;
            animator.SetTrigger("arrowdis");
            if (timerArrow > 3)
            {
                gameObject.SetActive(false);
                timerArrowActive = false;
                timerArrow = 0;
            }
        }
    }


    public void acitvateUIarrow()
    {
        gameObject.SetActive(true);
    }
    public void decitvateUIarrow()
    {
        timerArrowActive = true;
        
    }
}
