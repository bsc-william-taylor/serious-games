using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour 
{
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnLeaderboard()
    {
        EditorUtility.DisplayDialog("Title", "Message ", "Okay");
    }

    public void OnLoginGuest()
    {
        StartCoroutine(WebService.Post("/login-guest", new JSONClass(), action =>
        {
            EditorUtility.DisplayDialog("Login Status", "Guest Logged In ", "Okay");
        }));
    }

    public void OnLoginStudent()
    {
        var loginData = new JSONClass();
        loginData["username"] = "william-taylor";
        loginData["password"] = "password";


        StartCoroutine(WebService.Post("/login-student", loginData, action =>
        {
            EditorUtility.DisplayDialog("Login Status", "Student Logged In ", "Okay");
        }));
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
