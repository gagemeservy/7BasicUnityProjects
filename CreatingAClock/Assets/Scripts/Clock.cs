using System;
using UnityEngine;

public class Clock : MonoBehaviour {
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;
    const float hoursToDegrees = -30f;
    const float minutesToDegrees = -6f;
    const float secondsToDegrees = -6f;
    void Update(){
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        Debug.Log("The current time is " + DateTime.Now);
        Debug.Log("The current TimeOfDay time is " + currentTime);
        Debug.Log("The current TimeOfDay total hours is " + currentTime.TotalHours);
        Debug.Log("The current TimeOfDay total minutes is " + currentTime.TotalMinutes);
        Debug.Log("The current TimeOfDay total seconds is " + currentTime.TotalSeconds);
        hoursPivot.localRotation = Quaternion.Euler(0,0,hoursToDegrees * (float)currentTime.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0,0,minutesToDegrees * (float)currentTime.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0,0,secondsToDegrees * (float)currentTime.TotalSeconds);
    }
    
}