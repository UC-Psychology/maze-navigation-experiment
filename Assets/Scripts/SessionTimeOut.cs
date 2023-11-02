using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UXF;

public class SessionTimeOut : MonoBehaviour
{
    public float timeRemaining = 240;
    public TMP_Text timeOutTextBox;
    private bool countdownActive = false;
    public Session session;
    
    public void StartCountdown()
    {
        countdownActive = true;
    }
    
    void Update () 
    {
        if(countdownActive && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining < 0)
        {
            timeOutTextBox.gameObject.SetActive(true);
            countdownActive = false;
            session.settings.SetValue("session_ended", "participant_timeout");
            session.End();
        }
    }
}