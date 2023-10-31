using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class CollisionExperimentEnder : MonoBehaviour
{
    public Session session; // Reference to the UXF session

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if the object is the player
        {
            session.End(); // End the UXF session
            Debug.Log("Session ended");
        }
    }
}
