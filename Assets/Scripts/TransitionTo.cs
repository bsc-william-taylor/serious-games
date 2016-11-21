using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionTo : MonoBehaviour
{
    public int SceneID = 0;

    public void OnClick()
    {
        SceneManager.LoadScene(SceneID);
    }
}
