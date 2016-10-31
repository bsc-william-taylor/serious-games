using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using SimpleJSON;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    private List<GameObject> scores = new List<GameObject>();

    public GameObject Leaderboard;
    public GameObject Login;

    void Start()
    { 
        if (Leaderboard != null && Login != null)
        {
            var fontSize = 30;
            var y = 175;

            for (var i = 0; i < 10; i++, y -= 55)
            {
                NewTextElement(i, "HelloWorld " + i, y, fontSize);
            }

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
        foreach (var go in scores)
        {
            go.SetActive(false);
        }
    }

    public void OnLeaderboard()
    {
        Leaderboard.SetActive(true);
        foreach (var go in scores)
        {
            // TODO: Set text to name
            go.SetActive(true);
        }
    }

    private void NewTextElement(int uniqueID, string contents, int y, int fontSize)
    {
        var textObject = new GameObject("score" + uniqueID);
        textObject.SetActive(false);

       
        var text = textObject.AddComponent<Text>();
        text.text = contents;
        text.alignment = TextAnchor.MiddleCenter;
        text.fontSize = fontSize;
        text.color = Color.black;
        text.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
        text.verticalOverflow = VerticalWrapMode.Overflow;
        text.transform.SetParent(Leaderboard.transform);
        text.supportRichText = true;

        var rect = textObject.GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 3.0f);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 3.0f);
        rect.localPosition = new Vector3(0, y, 0);
        rect.sizeDelta = new Vector2(500, 100);
        scores.Add(textObject);
    }

    public void OnLogin()
    {
        Login.SetActive(true);
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
