using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour
{
    public void OnMouseDown()
    {
        Application.Quit();
    }
}
