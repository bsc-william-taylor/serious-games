using UnityEngine;
using System.Collections;

public class FpsMouse : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityVert = 6.0f;
    public float sensitivityHor = 6.0f;

    private float _rotationX = 0;

    void Start()
    {
        Debug.Log("Begining first person camera script");
    }

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, -45.0f, 45.0f);

            var rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, -45.0f, 45.0f);

            var delta = Input.GetAxis("Mouse X") * sensitivityHor;
            var rotationY = transform.localEulerAngles.y + delta;

            //transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
