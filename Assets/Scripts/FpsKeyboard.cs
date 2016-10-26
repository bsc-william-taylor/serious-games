using System;
using UnityEngine;
using System.Collections;
using SimpleJSON;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FpsKeyboard : MonoBehaviour
{
    private CharacterController characterController;

    public const float Gravity = -9.8f;
    public const float Speed = 0.25f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private static void HandlePost(JSONNode response)
    {
        Debug.Log(response.ToString());
    }

    private static void HandleGet(JSONNode response)
    {
        Debug.Log(response);
    }

    private void Update()
    {
        var deltaX = Input.GetAxis("Horizontal") * Speed;
        var deltaZ = Input.GetAxis("Vertical") * Speed;

        transform.Translate(deltaX, 0, deltaZ);

        var movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, Speed);
        //movement.y = Gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        characterController.Move(movement);
    }
}
