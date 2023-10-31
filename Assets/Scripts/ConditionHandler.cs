using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;
using TMPro;

public class ConditionHandler : MonoBehaviour
{
    public Camera mainCamera; // Reference to your main camera
    public CameraSwitch cameraSwitch;
    public TMP_Text goInstructions;
    public PlayerMovementHandler playerMovementHandler;

    public void SelectCondition(Session session)
    {
        int conditionNumber = Random.Range(1, 4);
        session.settings.SetValue("condition_number", conditionNumber);
        Debug.Log(session.settings.GetInt("condition_number"));

        if (conditionNumber == 2)
        {
            cameraSwitch.EnableBirdsEyeView();
        }
        else if (conditionNumber == 3)
        {
            cameraSwitch.EnableRouteView();
        }
        else
        {
            goInstructions.gameObject.SetActive(true);
            playerMovementHandler.EnablePlayerMovement();
            Invoke("DisableGoInstructions", 1f);
        }
    }

    private void DisableGoInstructions()
    {
        Debug.Log("Disabling go instructions");
        goInstructions.gameObject.SetActive(false);
    }
}