using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionTimeOut : MonoBehaviour
{
    public float timeRemaining = 240;
    public TMP_Text timeOutTextBox;
    private bool countdownActive = false;
    
    public void StartCountdown()
    {
        countdownActive = true;
    }
    
    void Update () 
    {
        if(countdownActive && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log(timeRemaining);
        }
        else if (timeRemaining < 0)
        {
            timeOutTextBox.gameObject.SetActive(true);
            countdownActive = false;
        }
    }
}