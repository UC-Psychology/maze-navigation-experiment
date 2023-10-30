using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 8.0f;
    public float rotationSpeed = 80.0f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift)) // check if left shift is held down
        {
            translation *= 1.4f; // increase speed by 40%
        }

        Vector3 moveDirection = transform.forward * translation;

        controller.Move(moveDirection);

        transform.Rotate(0, rotation, 0);
    }
}