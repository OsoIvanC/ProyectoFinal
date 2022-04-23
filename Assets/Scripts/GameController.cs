using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    float waveDuration;


    [Header("UI")]
    [SerializeField]
    TMP_Text timerText;

    float timer;

    private void Start()
    {
        timer = waveDuration;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            DisplayTime(timer);
            //Debug.Log(timer);
            yield return null;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
