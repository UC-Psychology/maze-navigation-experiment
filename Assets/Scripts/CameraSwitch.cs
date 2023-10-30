using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera birdsEyeCamera;

    public GameObject player;

    public GameObject targetColorSquare;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (firstPersonCamera.enabled)
            {
                firstPersonCamera.enabled = false;
                birdsEyeCamera.enabled = true;
                player.GetComponent<FirstPersonController>().enabled = false;
                targetColorSquare.SetActive(true);
            }
            else
            {
                birdsEyeCamera.enabled = false;
                firstPersonCamera.enabled = true;
                player.GetComponent<FirstPersonController>().enabled = true;
                targetColorSquare.SetActive(false);
            }
        }
    }
}