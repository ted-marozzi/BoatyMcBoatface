﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Countdown : MonoBehaviour
{
    Text textComp;

    [Range(0,10)]
    public int min = 0;

    [Range(0, 60)]
    public int sec = 0;

    [Range(1, 10)] 
    public int countdownRate = 1;

    float time;
    bool timerOn;

    public GameObject LevelControl;

    // Start is called before the first frame update
    void Start()
    {

        textComp = this.GetComponent<Text>();
        textComp.text = sec.ToString();

        //gross time in seconds
        time = min * 60 + sec;

        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            //counting down
            if (time > 0)
            {
                time -= Time.deltaTime * countdownRate;
            }
            else
            {
                time = 0;
                timerOn = false;
                LevelControl.GetComponent<LevelGeneralControl>().LevelClear();
            }
        }  
        //print out in format of 'min:sec'
        int timeInt = Mathf.RoundToInt(time);
        textComp.text =  "Time Left - " + (timeInt / 60).ToString() + ":" + (timeInt % 60).ToString();
    }
}
