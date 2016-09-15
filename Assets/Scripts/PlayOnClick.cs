using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayOnClick : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void OnMouseDown()
    {
        SceneManager.LoadScene(1);

        Debug.Log("I was hit");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
