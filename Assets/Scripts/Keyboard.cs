using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            WebService.EndGameplay(this, "/fail-gameplay");

            Application.Quit();
        }
    }
}
