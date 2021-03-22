using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);//calcular los minutos
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);//calcular los segundos

        if(timeText != null)
        {
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);// mandar el tiempo en formato minutos : segundos
        }
        print(string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}
