using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
   
    void Start()
    {
        TimerOn = true;
        //TimeLeft = PlayerPrefs.GetFloat("Time");
    }

    void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("Player")) 
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>().text = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreCounter>().GetScore().ToString();
        }
    }

    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
