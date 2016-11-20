using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static float timer;
    Text text;
    LeavingBuilding leavingBuilding0;
    LeavingBuilding leavingBuilding1;
    LeavingBuilding leavingBuilding2;
    ClickOnHazard clickOnHazard;
    Scene scene;

	void Start () {
        text = GetComponent<Text>();        
        
        scene = SceneManager.GetActiveScene();
        if(scene != null) {
            if(scene.name == "Fighter") {
                timer = 90.0f;
            }
            else if(scene.name == "Hazards") {
                timer = 30.0f;
            }
            else if(scene.name == "Safety") {
                timer = 60.0f;
            }
            else if(scene.name == "Runner") {
                timer = 90.0f;
            }
        }
        GameObject leaveObject;
    
        leaveObject = GameObject.Find("LeavingBuildingCollider (0)");
        if(leaveObject) {
            leavingBuilding0 = leaveObject.GetComponent<LeavingBuilding>();
        }

        leaveObject = GameObject.Find("LeavingBuildingCollider (1)");
        if(leaveObject) {
            leavingBuilding1 = leaveObject.GetComponent<LeavingBuilding>();
        }

        leaveObject = GameObject.Find("LeavingBuildingCollider (2)");
        if(leaveObject) {
            leavingBuilding2 = leaveObject.GetComponent<LeavingBuilding>();
        }

        clickOnHazard = GameObject.Find("Floor_5").GetComponent<ClickOnHazard>();
	}
	
	void Update () {
        if(timer > 0.0f) {
            timer -= Time.deltaTime;
            int display_time = (int)timer;
            text.text = "Time: " + display_time;
        } else {
            // Timer is done. Do something!
        }

        bool left_building = false;
        if((leavingBuilding0 != null) || (leavingBuilding1 != null) || (leavingBuilding2 != null)) {
            if((leavingBuilding0.leftBuilding == true) || (leavingBuilding1.leftBuilding == true) || (leavingBuilding2.leftBuilding == true)) {
                text.text = text.text + "\n" + "Left Building!";
                left_building = true;
            }       
        }

        // Handle exit scene.
        if(scene != null) {
            if(scene.name == "Fighter") {
                if((timer <= 0.0f) || (left_building == true)) {
                    // Exit.
                }   
            } else if(scene.name == "Hazards") {
                bool should_exit = false;
                bool success = false;

                if(timer <= 0.0f) {
                    should_exit = true;
                }

                int number_of_hazards = 0;
                if(clickOnHazard != null) {
                    if(clickOnHazard.computer == true)          { ++number_of_hazards; }
                    if(clickOnHazard.phone == true)             { ++number_of_hazards; }
                    if(clickOnHazard.monitor == true)           { ++number_of_hazards; }
                    if(clickOnHazard.microwave == true)         { ++number_of_hazards; }
                    if(clickOnHazard.vending_machine == true)   { ++number_of_hazards; }
                    if(clickOnHazard.printer == false)          { ++number_of_hazards; }
                    if(clickOnHazard.propane_canister == false) { ++number_of_hazards; }

                }
    
                if(number_of_hazards >= 1)
                {
                    success = true;
                }
                    
                if(should_exit == true) {
                    if(success == false) {
                        // Failed.
                    }
                    Application.LoadLevel("Safety");
                }
            } else if(scene.name == "Safety") {
                if(clickOnHazard != null) {
                    bool success = false;
                    bool should_exit = false;

                    int number_of_safety = 0;
   
                    if(timer <= 0.0f) {
                        should_exit = true;
                    }
         
                    if(clickOnHazard.fire_door == true)                       { ++number_of_safety; }
                    if(clickOnHazard.exit_light == true)                      { ++number_of_safety; }
                    if(clickOnHazard.co2_extinguisher == true)                { ++number_of_safety; }
                    if(clickOnHazard.door_access == true)                     { ++number_of_safety; }
                    if(clickOnHazard.emergency_exit_sign == true)             { ++number_of_safety; }
                    if(clickOnHazard.ringer == true)                          { ++number_of_safety; }
                    if(clickOnHazard.fire_call_sign == true)                  { ++number_of_safety; }
                    if(clickOnHazard.fire_extinguisher_sign == true)          { ++number_of_safety; }
                    if(clickOnHazard.fire_hose_sign == true)                  { ++number_of_safety; }
                    if(clickOnHazard.fire_procedures_sign == true)            { ++number_of_safety; }
                    if(clickOnHazard.foam_extinguisher == true)               { ++number_of_safety; }
                    if(clickOnHazard.powder_extinguisher == true)             { ++number_of_safety; }
                    if(clickOnHazard.water_extinguisher == true)              { ++number_of_safety; }
                    if(clickOnHazard.emergency_door_release_trigger == false) { ++number_of_safety; }
                    if(clickOnHazard.fire_alarm_cable == false)               { ++number_of_safety; }
                    
                    if(number_of_safety >= 1)
                    {
                        success = true;
                    }

                    if(should_exit == true) {
                        if(success == false) {
                            // Failed.
                        }

                        Application.LoadLevel("Runner");
                    }
                }
            } else if(scene.name == "Runner") {
                if(timer <= 0.0f) {
                    // Failed.
                    Application.LoadLevel("Fighter");
                } else if(left_building == true) {
                    // Failed.
                    Application.LoadLevel("Fighter");
                }   
            }
        }
	}
}
