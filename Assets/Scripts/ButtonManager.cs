using UnityEngine;
using UnityEngine.UI;

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

    public void OnCertification()
    {
        GUI.GetComponent<GuiManager>().OnCertification();
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

    public void OnLoginGuest()
    {
        GUI.GetComponent<GuiManager>().OnLoginGuest();
    }

    public void OnLoginStudent()
    {
        var usernameObject = GameObject.Find("UsernameInput");
        var usernameInput = usernameObject.GetComponent<InputField>();

        var passwordObject = GameObject.Find("PasswordInput");
        var passwordInput = passwordObject.GetComponent<InputField>();

        GUI.GetComponent<GuiManager>().OnLoginStudent(usernameInput.text, passwordInput.text);
    }

    public void OnQuit()
    {
        GUI.GetComponent<GuiManager>().OnQuit();
    }
}
