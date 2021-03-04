using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButton : MonoBehaviour
{
    

    void Start()
    {
       
    }

    public void TimePause()
    {
        Time.timeScale = 0;
    }

    public void TimePlay()
    {
        Time.timeScale = 1;
    }


    void Update()
    {
        
    }
}
