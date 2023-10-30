using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    // Constant rotation rate in degrees per frame
    private const float ROTATION_RATE = 90f;

    // Sound to play when the coin is collided with
    public AudioClip collectionSound;

    // Update is called once per frame
    void Update()
    {
        // Rotate the game object in the Z axis at a constant rate
        transform.Rotate(0f, 0f, ROTATION_RATE * Time.deltaTime);
    }

    // Called when the coin collides with another object
    void OnTriggerEnter(Collider other)
    {
        // Check if the other object is the player
        if (other.CompareTag("Player"))
        {
            // Play the collision sound
            AudioSource.PlayClipAtPoint(collectionSound, transform.position);

            // Destroy the coin object
            Destroy(gameObject);
            
        }
    }

}
