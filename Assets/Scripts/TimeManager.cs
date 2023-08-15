using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public DateTime oldTime;
    public DateTime newTime;

    public SaveManager saveManager;


    public void SetOldTime(DateTime oldT)
    {
        oldTime = oldT;
    }

    public void SetNewTime(DateTime newT)
    {
        newTime = newT;
    }

    public DateTime GetNewTime()
    {
        return newTime;
    }

    public DateTime GetOldTime()
    {
        return oldTime;
    }


    public int TimeInSeconds()
    {
        Debug.Log("Old Time: " + GetOldTime() + ", New Time: " + GetNewTime());

        TimeSpan difference = newTime.Subtract(oldTime);

        int seconds = (int)difference.TotalSeconds;

        return seconds;
    }

    public int TimeInMinutes()
    {
        TimeSpan difference = newTime.Subtract(oldTime);
        int minutes = (int)difference.TotalMinutes;
        return minutes;
    }

    public int TimeInHours()
    {
        TimeSpan difference = newTime.Subtract(oldTime);
        int hours = (int)difference.TotalHours;
        return hours;

    }
}
