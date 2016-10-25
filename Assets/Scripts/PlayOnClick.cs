using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayOnClick : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
