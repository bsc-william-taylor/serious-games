using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FpsKeyboard : MonoBehaviour
{
    private CharacterController characterController;
    private float gravity = -9.8f;
    private float speed = 1.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var deltaX = Input.GetAxis("Horizontal") * speed;
        var deltaZ = Input.GetAxis("Vertical") * speed;

        transform.Translate(deltaX, 0, deltaZ);

        var movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        characterController.Move(movement);
    }
}
