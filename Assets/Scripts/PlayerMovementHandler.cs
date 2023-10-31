using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DisablePlayerMovement();  
    }

    public void EnablePlayerMovement()
    {
        player.GetComponent<FirstPersonController>().enabled = true;
        Debug.Log("Player movement enabled");
    }

    public void DisablePlayerMovement()
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        Debug.Log("Player movement disabled");
    }
    
}
