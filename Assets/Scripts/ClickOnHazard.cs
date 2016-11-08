using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickOnHazard : MonoBehaviour {
    public string str = "";
	Scene scene;

    bool computer;
    bool phone;
    bool monitor;
    bool microwave;
    bool vending_machine;


    bool fire_door;
    bool exit_light;
    bool co2_extinguisher;
    bool door_access;
    bool emergency_exit_sign;
    bool ringer;
    bool fire_call_sign;
    bool fire_extinguisher_sign;
    bool fire_hose_sign;
    bool fire_procedures_sign;
    bool foam_extinguisher;
    bool powder_extinguisher;
    bool water_extinguisher;

    // Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene();

        computer = false;
        phone = false;
        monitor = false;
        microwave = false;
        vending_machine = false;

        fire_door = false;
        exit_light = false;
        co2_extinguisher = false;
        door_access = false;
        emergency_exit_sign = false;
        ringer = false;
        fire_call_sign = false;
        fire_extinguisher_sign = false;
        fire_hose_sign = false;
        fire_procedures_sign = false;
        foam_extinguisher = false;
        powder_extinguisher = false;
        water_extinguisher = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if(scene != null) {
                    if(scene.name == "Hazards") {
                        if ((hit.collider.name == "Mesh3") || (hit.collider.name == "Mesh12")) {
                            if(computer == false) str += "\nComputer";
                            computer = true;
                        }
                        else if ((hit.collider.name == "Mesh1") || (hit.collider.name == "Mesh2")) {
                            if(phone == false) str += "\nPhone";
                            phone = true;
                        }
                        /*else if ((hit.collider.name == "Mesh13") || (hit.collider.name == "Mesh17")) {
                            str = "Keyboard";
                        }*/
                        else if ((hit.collider.name == "Mesh5") || (hit.collider.name == "Mesh11") || (hit.collider.name == "Mesh7") || (hit.collider.name == "Mesh9")) {
                            if(monitor == false) str += "\nMonitor";
                            monitor = true;
                        }
                        /*else if ((hit.collider.name == "Mesh14") || (hit.collider.name == "Mesh16")) {
                            str = "Mouse";
                        }*/
                        /*else if (hit.collider.name == "Mesh15") {
                            str = "Table";
                        }*/
                        else if (hit.collider.name == "Microwave_Mesh") {
                            if(microwave == false) str += "\nMicrowave";
                            microwave = true;
                        }
                        else if ((hit.collider.name == "Vending_Machine_Mesh") || (hit.collider.name == "Vending_Machine_Mesh")) {
                            if(vending_machine == false) str += "\nVending Machine";
                            vending_machine = true;
                        }
                    } else if(scene.name == "Safety") {
                        if (hit.collider.name == "fire_door") {
                            if(fire_door == false) str += "\nFire door";
                            fire_door = true;
                        }
                        else if ((hit.collider.name == "Exit Light") || (hit.collider.name == "Exit Light 1") || (hit.collider.name == "Exit Light 2") || (hit.collider.name == "Exit Light 3")) {
                            if(emergency_exit_sign == false) str += "\nEmergency exit sign";
                            emergency_exit_sign = true;
                        }
                        else if (hit.collider.name == "co2 extinguisher") {
                            if(co2_extinguisher == false) str += "\nCO2 Extinguisher";
                            co2_extinguisher = true;
                        }
                        else if (hit.collider.name == "door access") {
                            if(door_access == false) str += "\nDoor access";
                            door_access = true;
                        }
                        else if (hit.collider.name == "emergency_exit_sign") {
                            if(emergency_exit_sign == false) str += "\nEmergency exit sign";
                            emergency_exit_sign = true;
                        }
                        else if (hit.collider.name == "ringer") {
                            if(ringer == false) str += "\nFire alarm ringer";
                            ringer = true;
                        }
                        else if (hit.collider.name == "fire_call_sign") {
                            if(fire_call_sign == false) str += "\nFire call sign";
                            fire_call_sign = true;
                        }
                        else if (hit.collider.name == "fire_extinguisher_sign") {
                            if(fire_extinguisher_sign == false) str += "\nFire extinguisher sign";
                            fire_extinguisher_sign = true;
                        }
                        else if (hit.collider.name == "fire_hose_sign") {
                            if(fire_hose_sign == false) str += "\nFire hose sign";
                            fire_hose_sign = true;
                        }
                        else if (hit.collider.name == "fire_procedures_sign") {
                            if(fire_procedures_sign == false) str += "\nFire procedures sign";
                            fire_procedures_sign = true;
                        }
                        else if (hit.collider.name == "foam_extinguisher") {
                            if(foam_extinguisher == false) str += "\nFoam extinguisher";
                            foam_extinguisher = true;
                        }
                        else if (hit.collider.name == "powder_extinguisher") {
                            if(powder_extinguisher == false) str += "\nPowder extinguisher";
                            powder_extinguisher = true;
                        }
                        else if (hit.collider.name == "water_extinguisher") {
                            if(water_extinguisher == false) str += "\nWater extinguisher";
                            water_extinguisher = true;
                        }
                    }
                }
                

                /*if(str.Length > 0) {
                    Debug.Log(str);
                    Debug.Log("--------------");
                }*/
            }
        } 
	}
}
