using UnityEngine;
using TMPro;
using UXF;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera birdsEyeCamera;
    public Camera routeCamera;

    public GameObject targetColorSquare;
    public GameObject startingColorSquare;

    public PlayerMovementHandler playerMovementHandler;
    public TMP_Text birdsEyeViewInstructions;
    public TMP_Text routeViewInstructions;
    public SpawnTrial spawnTrial;
    public float conditionViewDuration = 30f;

    public Countdown countdown;
    public Session session;

    public void EnableBirdsEyeView()
    { 
        firstPersonCamera.enabled = false;
        routeCamera.enabled = false;
        birdsEyeCamera.enabled = true;
        birdsEyeViewInstructions.gameObject.SetActive(true);
        routeViewInstructions.gameObject.SetActive(false);
        playerMovementHandler.DisablePlayerMovement();
        targetColorSquare.SetActive(true);
        startingColorSquare.SetActive(true);
        countdown.StartCountdown();
        Invoke("EnableFirstPersonView", conditionViewDuration);
    }

    public void EnableRouteView()
    {   
        birdsEyeCamera.enabled = false;
        routeCamera.enabled = true;
        firstPersonCamera.enabled = false;
        birdsEyeViewInstructions.gameObject.SetActive(false);
        routeViewInstructions.gameObject.SetActive(true);
        playerMovementHandler.DisablePlayerMovement();
        countdown.StartCountdown();
        Invoke("EnableFirstPersonView", conditionViewDuration);
    }

    public void EnableFirstPersonView()
    {
        spawnTrial.trialSpawner(session);
        Debug.Log("Enabling first person view");
        birdsEyeCamera.enabled = false;
        routeCamera.enabled = false;
        firstPersonCamera.enabled = true;
        birdsEyeViewInstructions.gameObject.SetActive(false);
        routeViewInstructions.gameObject.SetActive(false);
        playerMovementHandler.EnablePlayerMovement();
        targetColorSquare.SetActive(false);
    }
}