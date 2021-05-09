using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TimeScaleManager : MonoBehaviour
{

    public Flowchart intro;
    public static bool start_pause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        start_pause = intro.GetBooleanVariable("start");
        if (start_pause == true)
        {

            //scrollBegin.hasStarted
            Time.timeScale = 1;
            //musicClip.UnPause();
            //pause.interactable = true;

        }
        else
        {

            Time.timeScale = 0;
            //musicClip.Pause();
        }
    }

    void timeControlPara() {
        start_pause = !start_pause;
    }
}
