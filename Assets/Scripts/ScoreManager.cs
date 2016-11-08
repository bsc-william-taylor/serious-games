using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static float timer;
    Text text;
    ClickOnHazard clickOnHazard;
    LeavingBuilding leavingBuilding0;
    LeavingBuilding leavingBuilding1;
    LeavingBuilding leavingBuilding2;


	void Start () {
        text = GetComponent<Text>();        
        timer = 120.0f;
        clickOnHazard = GameObject.Find("Floor_5").GetComponent<ClickOnHazard>();
        GameObject leaveObject;
    
        leaveObject = GameObject.Find("LeavingBuildingCollider (0)");
        if(leaveObject) leavingBuilding0 = leaveObject.GetComponent<LeavingBuilding>();

        leaveObject = GameObject.Find("LeavingBuildingCollider (1)");
        if(leaveObject) leavingBuilding1 = leaveObject.GetComponent<LeavingBuilding>();

        leaveObject = GameObject.Find("LeavingBuildingCollider (2)");
        if(leaveObject) leavingBuilding2 = leaveObject.GetComponent<LeavingBuilding>();
	}
	
	void Update () {
        if(timer > 0.0f) {
            timer -= Time.deltaTime;
            int display_time = (int)timer;
            text.text = "Time: " + display_time;
        } else {
            // Timer is done. Do something!
        }

        if (clickOnHazard != null) {
            text.text = text.text + "\n" + clickOnHazard.str;
        }

        if((leavingBuilding0 != null) || (leavingBuilding1 != null) || (leavingBuilding2 != null)) {
            if((leavingBuilding0.leftBuilding == true) || (leavingBuilding1.leftBuilding == true) || (leavingBuilding2.leftBuilding == true)) {
                text.text = text.text + "\n" + "Left Building!";
            }       
        }
	}
}
