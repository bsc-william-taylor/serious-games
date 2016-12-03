using UnityEngine;
using UnityEngine.SceneManagement;

public class Keyboard : MonoBehaviour
{
    private Scene scene;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void Update()
    {
        if (Input.GetKeyDown("escape") && scene.name == "Menu")
        {
            WebService.EndGameplay(this, "/fail-gameplay");

            Application.Quit();
        }
    }

    public void OnApplicationQuit()
    {
        WebService.EndGameplay(this, "/fail-gameplay");
    }
}
