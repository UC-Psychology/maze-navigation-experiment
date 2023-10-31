using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float timeStart = 30;
    public TMP_Text textBox;
    private bool countdownActive = false;
    
    public void StartCountdown()
    {
        countdownActive = true;
    }
    
    void Update () 
    {
        if(countdownActive && timeStart > 0)
        {
            timeStart -= Time.deltaTime;
            textBox.text = Mathf.Round(timeStart).ToString();
        }
        else if (timeStart < 0)
        {
            textBox.text = "";
            countdownActive = false;
        }
    }
}
