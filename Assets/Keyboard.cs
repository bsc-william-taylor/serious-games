using UnityEngine;

public class Keyboard : MonoBehaviour 
{
	public void Update () 
    {
	    if (Input.GetKeyDown("escape"))
	    {
            Application.Quit();
        }
    }
}
