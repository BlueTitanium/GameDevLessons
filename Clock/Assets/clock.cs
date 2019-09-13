using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    const float degreesPerHour = 30f, 
                degreesPerMinute = 6f, 
                degreesPerSecond = 6f;

    public bool continuous;

    public Transform hoursTransform, minutesTransform, secondsTransform;
    void Update(){
        //To control whether or not the clock is continuous from inside the scene
        if(Input.GetKeyDown("tab")){
            continuous = !continuous;
        }
        if(continuous) UpdateContinuous();
        else UpdateDiscrete();
    }
    void UpdateContinuous(){
        TimeSpan time = DateTime.Now.TimeOfDay;
        Debug.Log(time);
        hoursTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
    }
    void UpdateDiscrete(){
        Debug.Log(DateTime.Now);
        hoursTransform.localRotation = Quaternion.Euler(0f, DateTime.Now.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, DateTime.Now.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, DateTime.Now.Second * degreesPerSecond, 0f);
    }
}
