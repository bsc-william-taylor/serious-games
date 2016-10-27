using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
    public GameObject Leaderboard;
    public GameObject Login;

    void Start()
    {
        if (Leaderboard != null && Login != null)
        {
            Leaderboard.SetActive(false);
            Login.SetActive(false);
        }
    }
    
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCloseLogin()
    {
        Login.SetActive(false);
    }

    public void OnCloseLeaderboard()
    {
        Leaderboard.SetActive(false);
    }

    public void OnLeaderboard()
    {
       Leaderboard.SetActive(true);
    }

    public void OnLoginGuest()
    {
        StartCoroutine(WebService.Post("/login-guest", new JSONClass(), (action, error) =>
        {
            if (string.IsNullOrEmpty(error) && action["loginSuccess"].AsBool)
            {
                //UnityEditor.EditorUtility.DisplayDialog("Login Status", "Guest logged in ", "Okay");
            }
            else
            {
                //UnityEditor.EditorUtility.DisplayDialog("Login Status", "Guest could not login ", "Okay");
            }
        }));
    }

    public void OnLoginStudent()
    {
        Login.SetActive(true);
        /*
        var loginData = new JSONClass();
        loginData["username"] = "william-taylor";
        loginData["password"] = "password";

        StartCoroutine(WebService.Post("/login-student", loginData, (action, error) =>
        {
            if (string.IsNullOrEmpty(error))
            {
                //UnityEditor.EditorUtility.DisplayDialog("Login Status", "Student logged in ", "Okay");
            }
            else
            {
                //UnityEditor.EditorUtility.DisplayDialog("Login Status", "Student could not login ", "Okay");
            }
        }));*/
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
