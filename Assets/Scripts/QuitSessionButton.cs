using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UXF;

public class QuitSessionButton : MonoBehaviour
{
    public Session session;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(QuitSession);
    }

    void QuitSession()
    {
        Debug.Log("Quit Session"); 

        session.settings.SetValue("session_ended", "participant_quit");

        session.End();
        // End the session here
        Application.Quit();

    }
}

