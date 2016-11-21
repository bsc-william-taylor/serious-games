using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    private static float timer;
    Text text;
    LeavingBuilding leavingBuilding0;
    LeavingBuilding leavingBuilding1;
    LeavingBuilding leavingBuilding2;
    ClickOnHazard clickOnHazard;
    Scene scene;

    void Start()
    {
        text = GetComponent<Text>();

        scene = SceneManager.GetActiveScene();
        if (scene != null)
        {
            if (scene.name == "Fighter") { timer = 90.0f; }
            else if (scene.name == "Hazards") { timer = 30.0f; }
            else if (scene.name == "Safety") { timer = 60.0f; }
            else if (scene.name == "Runner") { timer = 90.0f; }
        }
        GameObject leaveObject;

        leaveObject = GameObject.Find("LeavingBuildingCollider (0)");
        if (leaveObject)
        {
            leavingBuilding0 = leaveObject.GetComponent<LeavingBuilding>();
        }

        leaveObject = GameObject.Find("LeavingBuildingCollider (1)");
        if (leaveObject)
        {
            leavingBuilding1 = leaveObject.GetComponent<LeavingBuilding>();
        }

        leaveObject = GameObject.Find("LeavingBuildingCollider (2)");
        if (leaveObject)
        {
            leavingBuilding2 = leaveObject.GetComponent<LeavingBuilding>();
        }

        clickOnHazard = GameObject.Find("Floor_5").GetComponent<ClickOnHazard>();
    }

    void Update()
    {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            var display_time = (int)timer;
            text.text = "Time: " + display_time;
        }

        bool left_building = false;
        if ((leavingBuilding0 != null) || (leavingBuilding1 != null) || (leavingBuilding2 != null))
        {
            if (LeavingBuilding.leftBuilding)
            {
                text.text = text.text + "\n" + "Left Building!";
                left_building = true;
            }
        }

        // Handle exit scene.
        if (scene != null)
        {
            if (scene.name == "Hazards")
            {
                if (timer <= 0.0f)
                {
                    if (clickOnHazard.collectedHazardItems.Count >= 7)
                    {
                        Application.LoadLevel("Safety");
                    }
                    else
                    {
                        Application.LoadLevel("Failed");
                    }
                }
            }
            else if (scene.name == "Safety")
            {
                if (clickOnHazard != null)
                {
                    if (timer <= 0.0f)
                    {
                        if (clickOnHazard.collectedSafetyItems.Count >= 10)
                        {
                            Application.LoadLevel("Runner");
                        }
                        else
                        {
                            Application.LoadLevel("Failed");
                        }
                    }
                }
            }
            else if (scene.name == "Runner")
            {
                if (left_building)
                {
                    Application.LoadLevel("Fighter");
                }
                else if (timer <= 0.0f)
                {
                    Application.LoadLevel("Failed");
                }
            }
        }
    }
}
