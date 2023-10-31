using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera birdsEyeCamera;

    public GameObject targetColorSquare;
    public GameObject startingColorSquare;

    public PlayerMovementHandler playerMovementHandler;

    public Countdown countdown;

    public void EnableBirdsEyeView()
    { 
        firstPersonCamera.enabled = false;
        birdsEyeCamera.enabled = true;
        playerMovementHandler.DisablePlayerMovement();
        targetColorSquare.SetActive(true);
        startingColorSquare.SetActive(true);
        countdown.StartCountdown();
        Invoke("EnableFirstPersonView", 15f);
    }

    public void EnableFirstPersonView()
    {
        birdsEyeCamera.enabled = false;
        firstPersonCamera.enabled = true;
        playerMovementHandler.EnablePlayerMovement();
        targetColorSquare.SetActive(false);
    }
}