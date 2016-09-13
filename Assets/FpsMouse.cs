using UnityEngine;

public class FpsMouse : MonoBehaviour
{
    public const float SensitivityHorizontal = 6.0f;
    public const float SensitivityVertical = 6.0f;
    public const float CameraHeight = 2.0f;

    private float rotationX;

    private void Start()
    {
        Debug.Log("Begining first person camera script");
    }

    private void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y") * SensitivityVertical;
        rotationX = Mathf.Clamp(rotationX, -45.0f, 45.0f);

        var delta = Input.GetAxis("Mouse X") * SensitivityHorizontal;
        var rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        transform.position = new Vector3(transform.position.x, CameraHeight, transform.position.z);
    }
}
