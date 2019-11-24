using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimeText;
    public float TimeStamp;
    public bool UsingTimer = false;

    private void Start()
    {
        SetTimer(40);
    }

    private void Update()
    {
        if (UsingTimer)
            SetUIText();
    }

    public void SetTimer(float time)
    {
        if (UsingTimer)
            return;

        TimeStamp = Time.time + time;
        UsingTimer = true;
    }

    public void SetUIText()
    {
        float timeLeft = TimeStamp - Time.time;
        if(timeLeft <= 0)
        {
            FinishAction();
        }
        float hours;
        float minutes;
        float seconds;
        float miniseconds;
        GetTimeValues(timeLeft, out hours, out minutes, out seconds, out miniseconds);

        if (hours > 0 )
        {
            TimeText.text = string.Format("{0}:{1}", hours, minutes);
        }  
        else if(minutes > 0)
        {
            TimeText.text = string.Format("{0}:{1}", minutes, seconds);
        }
        else
        {
            TimeText.text = string.Format("{0}:{1}", seconds, miniseconds);
        }
    }

    public void GetTimeValues(float time, out float hours, out float minutes, out float seconds, out float miniseconds)
    {
        hours = (int)(time / 3600f);
        minutes = (int)((time - hours * 3600) / 60f);
        seconds = (int)((time - hours * 3600 - minutes * 60));
        miniseconds = (int)((time - hours * 3600 - minutes * 60 - seconds) * 100);

    }

    public void FinishAction()
    {
        Debug.Log("Boom");
        TimeText.text = "00:00";
        UsingTimer = false;
    }
}
