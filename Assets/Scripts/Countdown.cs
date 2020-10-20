using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {

        textComp = this.GetComponent<Text>();
        textComp.text = sec.ToString();

        //gross time in seconds
        time = min * 60 + sec;

    }

    // Update is called once per frame
    void Update()
    {
        //counting down
        if (time >= 0)
        {
            time -= Time.deltaTime * countdownRate;
        }
            
        //print out in format of 'min:sec'
        int timeInt = Mathf.RoundToInt(time);
        textComp.text =  "Time Left - " + (timeInt / 60).ToString() + ":" + (timeInt % 60).ToString();
    }
}
