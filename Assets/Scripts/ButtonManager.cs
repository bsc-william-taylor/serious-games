using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private static bool ShowModel = false;

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnLeaderboard()
    {
        ShowModel = true;
    }

    public void OnLoginGuest()
    {
        StartCoroutine(WebService.Post("/login-guest", new JSONClass(), (action, error) =>
        {
            if (string.IsNullOrEmpty(error) && action["loginSuccess"].AsBool)
            {
                EditorUtility.DisplayDialog("Login Status", "Guest logged in ", "Okay");
                //Debug.Log(action.ToString());
            }
            else
            {
                EditorUtility.DisplayDialog("Login Status", "Guest could not login ", "Okay");
            }
        }));
    }

    public void OnLoginStudent()
    {
        var loginData = new JSONClass();
        loginData["username"] = "william-taylor";
        loginData["password"] = "password";

        StartCoroutine(WebService.Post("/login-student", loginData, (action, error) =>
        {
            if (string.IsNullOrEmpty(error))
            {
                EditorUtility.DisplayDialog("Login Status", "Student logged in ", "Okay");
            }
            else
            {
                EditorUtility.DisplayDialog("Login Status", "Student could not login ", "Okay");
            }
        }));
    }

    void OnGUI()
    {
        if (!ShowModel)
        {
            return;
        }

        // TODO: Draw input gui for username & password
        if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 75, 150, 150), "I am a model"))
        {
            ShowModel = false;
        }
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
