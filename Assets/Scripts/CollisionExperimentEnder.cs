using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UXF;

public class CollisionExperimentEnder : MonoBehaviour
{
    public Session session; // Reference to the UXF session
    public TMP_Text winTextBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if the object is the player
        {
            session.settings.SetValue("session_ended", "participant_success");
            winTextBox.gameObject.SetActive(true);
            session.End(); // End the UXF session
        }
    }
}
