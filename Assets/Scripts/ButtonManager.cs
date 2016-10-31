using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject GUI;

    public void OnPlay()
    {
        GUI.GetComponent<GuiManager>().OnPlay();
    }

    public void OnLeaderboard()
    {
        GUI.GetComponent<GuiManager>().OnLeaderboard();
    }

    public void OnCloseLeaderboard()
    {
        GUI.GetComponent<GuiManager>().OnCloseLeaderboard();
    }

    public void OnCloseLogin()
    {
        GUI.GetComponent<GuiManager>().OnCloseLogin();
    }

    public void OnLogin()
    {
        GUI.GetComponent<GuiManager>().OnLogin();
    }

    public void OnQuit()
    {
        GUI.GetComponent<GuiManager>().OnQuit();
    }
}
