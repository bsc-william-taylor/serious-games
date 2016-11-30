using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject DoneText;
    public GameObject HintText;
    public GameObject TimeText;
    private bool didPlayerRun;

    private ClickOnHazard clickOnHazard;
    private static float timer;
    private Scene activeScene;
    private Text timerText;

    void Start()
    {
        clickOnHazard = GameObject.Find("Floor_5").GetComponent<ClickOnHazard>();
        activeScene = SceneManager.GetActiveScene();
        timerText = TimeText.GetComponent<Text>();
        didPlayerRun = false;

        switch (activeScene.name)
        {
            case "Fighter": timer = 90.0f; break;
            case "Hazards": timer = 30.0f; break;
            case "Safety": timer = 60.0f; break;
            case "Runner": timer = 90.0f; break;
        }

        StartCoroutine(Wait(5, () => HintText.SetActive(false)));
        DoneText.SetActive(false);
    }

    IEnumerator Wait(int seconds, Action action)
    {
        yield return new WaitForSeconds(5.0f);
        action();
    }

    void NextScene(string scene, string endtext)
    {
        StartCoroutine(Wait(3, () => Application.LoadLevel(scene)));

        DoneText.GetComponent<Text>().text = endtext;
        DoneText.SetActive(true);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timer = Math.Max(0.0f, timer);
        timerText.text = "Time Left: " + (int)timer;

        if (activeScene.name == "Hazards" && timer <= 0.0f)
        {
            if (clickOnHazard.collectedHazardItems.Count >= 7)
            {
                NextScene("Runner", "Scenario Passed");
            }
            else
            {
                NextScene("Failed", "Scenario Failed");
            }
        }
        else if (activeScene.name == "Safety" && timer <= 0.0f && clickOnHazard != null)
        {
            if (clickOnHazard.collectedSafetyItems.Count >= 10)
            {
                NextScene("Hazards", "Scenario Passed");
            }
            else
            {
                NextScene("Failed", "Scenario Failed");
            }
        }
        else if (activeScene.name == "Runner")
        {
            if((Input.GetKeyDown(KeyCode.RightShift)) || (Input.GetKeyDown(KeyCode.LeftShift))) // TODO(Jonny): Shift not found?
            {
                didPlayerRun = true;
            }

            bool end = ((LeavingBuilding.leftBuilding) || (timer < 0.0f));

            if(end)
            {
                if((LeavingBuilding.leftBuilding) && (didPlayerRun == false))
                {
                    NextScene("Fighter", "Scenario Passed");
                }
                else
                {
                    NextScene("Failed", "Scenario Failed");
                }
            }
        }
    }
}
