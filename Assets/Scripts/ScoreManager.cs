using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{

    private static float timer;
    Text text;
    ClickOnHazard clickOnHazard;
    LeavingBuilding leavingBuilding0;
    LeavingBuilding leavingBuilding1;
    LeavingBuilding leavingBuilding2;


    void Start()
    {
        text = GetComponent<Text>();
        timer = 120.0f;
        clickOnHazard = GameObject.Find("Floor_5").GetComponent<ClickOnHazard>();
        GameObject leaveObject;

        leaveObject = GameObject.Find("LeavingBuildingCollider (0)");
        if (leaveObject) leavingBuilding0 = leaveObject.GetComponent<LeavingBuilding>();

        leaveObject = GameObject.Find("LeavingBuildingCollider (1)");
        if (leaveObject) leavingBuilding1 = leaveObject.GetComponent<LeavingBuilding>();

        leaveObject = GameObject.Find("LeavingBuildingCollider (2)");
        if (leaveObject) leavingBuilding2 = leaveObject.GetComponent<LeavingBuilding>();
    }

    void Update()
    {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            int display_time = (int)timer;
            text.text = "Time: " + display_time;
        }
        else
        {
            // Timer is done. Do something!
        }

        if (clickOnHazard != null)
        {
            foreach (var identifiedItem in clickOnHazard.identified)
            {
                text.text += "\n" + clickOnHazard.descriptions[identifiedItem];
            }
        } else
        {
            text.text = "CLICK ON HAZARD IS NULL";
        }
 
        if (LeavingBuilding.leftBuilding)
        {
            text.text = text.text + "\n" + "Left Building!";
        }
    }
}
