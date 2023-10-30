using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class ConditionHandler : MonoBehaviour
{
    public GameObject instructionsScreen; // Assuming you have a UI screen for instructions
    public Camera mainCamera; // Reference to your main camera

    public void SelectCondition(Session session)
    {
        int conditionNumber = Random.Range(1, 4);
        session.settings.SetValue("condition_number", conditionNumber);
        Debug.Log(session.settings.GetInt("condition_number"));

        if (conditionNumber == 2)
        {
            HandleBirdsEyeViewCondition();
        }
        else if (conditionNumber == 3)
        {
            HandleWrittenDirectionsCondition();
        }
    }

    void HandleBirdsEyeViewCondition()
    {
        // Change camera angle here:
        // e.g., mainCamera.transform.eulerAngles = new Vector3(90, 0, 0);

        // Then wait for a button press to start the experiment
    }

    void HandleWrittenDirectionsCondition()
    {
        // Display instructions:
        // e.g., instructionsScreen.SetActive(true);

        // Then wait for a button press to start the experiment
    }
}