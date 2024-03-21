using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UXF;

public class QuitSessionButton : MonoBehaviour
{
    public Session session;
    public TMP_Text quitTextBox;


    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(QuitSession);
    }

    void QuitSession()
    {
        Debug.Log("Quit Session"); 

        

        if (session.InTrial)
        {
            session.settings.SetValue("session_ended", "participant_quit");
            quitTextBox.gameObject.SetActive(true);
            session.End();
        }

        // End the session here
        // Application.Quit();
    }
}

