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

    public void OnLoginGuest()
    {
        GUI.GetComponent<GuiManager>().OnLoginGuest();
    }

    public void OnLoginStudent()
    {
        GUI.GetComponent<GuiManager>().OnLoginStudent();
    }

    public void OnQuit()
    {
        GUI.GetComponent<GuiManager>().OnQuit();
    }
}
