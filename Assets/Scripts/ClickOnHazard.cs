using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickOnHazard : MonoBehaviour
{
    public string str = "";
    Scene scene;

    public bool computer;
    public bool phone;
    public bool monitor;
    public bool microwave;
    public bool vending_machine;

    public bool printer;


    public bool fire_door;
    public bool exit_light;
    public bool co2_extinguisher;
    public bool door_access;
    public bool emergency_exit_sign;
    public bool ringer;
    public bool fire_call_sign;
    public bool fire_extinguisher_sign;
    public bool fire_hose_sign;
    public bool fire_procedures_sign;
    public bool foam_extinguisher;
    public bool powder_extinguisher;
    public bool water_extinguisher;

    public bool emergency_door_release_trigger;
    public bool fire_alarm_cable;
    public bool propane_canister;

    // Use this for initialization
    void Start ()
    {
        scene = SceneManager.GetActiveScene();

        computer = false;
        phone = false;
        monitor = false;
        microwave = false;
        vending_machine = false;
        printer = false;


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
        emergency_door_release_trigger = false;
        fire_alarm_cable = false;
        propane_canister = false;
    }

    // Update is called once per frame
    void Update ()
    {
        bool left_mouse_down = Input.GetMouseButtonDown(0);
        bool right_mouse_down = Input.GetMouseButtonDown(1);
        if((left_mouse_down) || (right_mouse_down)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                if(scene != null) {
                    if((scene.name == "Hazards") || (scene.name == "Safety")) {
                        if (hit.collider.name == "computer") {
                            if((left_mouse_down) && (computer == false)) {
                                computer = true;
                            } else if (right_mouse_down) {
                                computer = false;
                            }
                        } else if(hit.collider.name == "printer") {
                          if((left_mouse_down) && (printer == false)) {
                                printer = true;
                            } else if (right_mouse_down) {
                                printer = false;
                            }
                        } else if (hit.collider.name == "phone") {
                            if((left_mouse_down) && (phone == false)) {
                                phone = true;
                            } else if (right_mouse_down) {
                                phone = false;
                            }
                        } else if (hit.collider.name == "monitor") {
                            if((left_mouse_down) && (monitor == false)) {
                                monitor = true;
                            } else if (right_mouse_down) {
                                monitor = false;
                            }
                        } else if (hit.collider.name == "microwave") {
                            if((left_mouse_down) && (microwave == false)) {
                                microwave = true;
                            } else if (right_mouse_down) {
                                microwave = false;
                            }
                        } else if ((hit.collider.name == "drinksvendingmachine") || (hit.collider.name == "snacksvendingmachine")) {
                            if((left_mouse_down) && (vending_machine == false)) {
                                vending_machine = true;
                            } else if (right_mouse_down) {
                                vending_machine = false;
                            }
                        } else if (hit.collider.name == "fire_door") {
                            if((left_mouse_down) && (fire_door == false)) {
                                fire_door = true;
                            } else if (right_mouse_down) {
                                fire_door = false;
                            }
                        } else if ((hit.collider.name == "Exit Light") || (hit.collider.name == "Exit Light 1") || (hit.collider.name == "Exit Light 2") || (hit.collider.name == "Exit Light 3")) {
                            if((left_mouse_down) && (emergency_exit_sign == false)) {
                                emergency_exit_sign = true;
                            } else if (right_mouse_down) {
                                emergency_exit_sign = false;
                            }
                        } else if (hit.collider.name == "co2_extinguisher") {
                            if((left_mouse_down) && (co2_extinguisher == false)) {
                                co2_extinguisher = true;
                            } else if (right_mouse_down) {
                                co2_extinguisher = false;
                            }
                        } else if (hit.collider.name == "door access") {
                            if((left_mouse_down) && (door_access == false)) {
                                door_access = true;
                            } else if (right_mouse_down) {
                                door_access = false;
                            }
                        } else if (hit.collider.name == "emergency_exit_sign") {
                            if((left_mouse_down) && (emergency_exit_sign == false)) {
                                emergency_exit_sign = true;
                            } else if (right_mouse_down) {
                                emergency_exit_sign = false;
                            }
                        } else if (hit.collider.name == "fire_alarm") {
                            if((left_mouse_down) && (ringer == false)) {
                                ringer = true;
                            } else if (right_mouse_down) {
                                ringer = false;
                            }
                        } else if (hit.collider.name == "fire_alarm_call_point_sign") {
                            if((left_mouse_down) && (fire_call_sign == false)) {
                                fire_call_sign = true;
                            } else if (right_mouse_down) {
                                fire_call_sign = false;
                            }
                        } else if (hit.collider.name == "fire_extinguisher_sign") {
                            if((left_mouse_down) && (fire_extinguisher_sign == false)) {
                                fire_extinguisher_sign = true;
                            } else if (right_mouse_down) {
                                fire_extinguisher_sign = false;
                            }
                        } else if (hit.collider.name == "fire_hose_sign") {
                            if((left_mouse_down) && (fire_hose_sign == false)) {
                                fire_hose_sign = true;
                            } else if (right_mouse_down) {
                                fire_hose_sign = false;
                            }
                        } else if (hit.collider.name == "fire_procedures_sign") {
                            if((left_mouse_down) && (fire_procedures_sign == false)) {
                                fire_procedures_sign = true;
                            } else if (right_mouse_down) {
                                fire_procedures_sign = false;
                            }
                        } else if (hit.collider.name == "foam_extinguisher") {
                            if((left_mouse_down) && (foam_extinguisher == false)) {
                                foam_extinguisher = true;
                            } else if (right_mouse_down) {
                                foam_extinguisher = false;
                            }
                        } else if (hit.collider.name == "powder_extinguisher") {
                            if((left_mouse_down) && (powder_extinguisher == false)) {
                                powder_extinguisher = true;
                            } else if (right_mouse_down) {
                                powder_extinguisher = false;
                            }
                        } else if (hit.collider.name == "water_extinguisher") {
                            if((left_mouse_down) && (water_extinguisher == false)) {
                                water_extinguisher = true;
                            } else if (right_mouse_down) {
                                water_extinguisher = false;
                            }
                        } else if(hit.collider.name == "emergency_door_release_trigger") {
                            if((left_mouse_down) && (emergency_door_release_trigger == false)) {
                                emergency_door_release_trigger = true;
                            } else if (right_mouse_down) {
                                emergency_door_release_trigger = false;
                            }
                        } else if(hit.collider.name == "fire_alarm_cable") {
                            if((left_mouse_down) && (fire_alarm_cable == false)) {
                                fire_alarm_cable = true;
                            } else if (right_mouse_down) {
                                fire_alarm_cable = false;
                            }
                        } else if(hit.collider.name == "fuel_can") {
                            if((left_mouse_down) && (propane_canister == false)) {
                                propane_canister = true;
                            } else if (right_mouse_down) {
                                propane_canister = false;
                            }
                        }
                    }
                }
            }
        }/* else if (Input.GetMouseButtonDown (1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if(scene != null) {
                    if((scene.name == "Hazards") || (scene.name == "Safety")) {
                        if ((hit.collider.name == "Mesh3") || (hit.collider.name == "Mesh12")) {
                            computer = false;
                        } else if ((hit.collider.name == "Mesh1") || (hit.collider.name == "Mesh2")) {
                            phone = false;
                        } else if ((hit.collider.name == "Mesh5") || (hit.collider.name == "Mesh11") || (hit.collider.name == "Mesh7") || (hit.collider.name == "Mesh9")) {
                            monitor = false;
                        } else if (hit.collider.name == "Microwave_Mesh") {
                            microwave = false;
                        } else if ((hit.collider.name == "Vending_Machine_Mesh") || (hit.collider.name == "Vending_Machine_Mesh")) {
                            vending_machine = false;
                        } else if (hit.collider.name == "fire_door") {
                            fire_door = false;
                        } else if ((hit.collider.name == "Exit Light") || (hit.collider.name == "Exit Light 1") || (hit.collider.name == "Exit Light 2") || (hit.collider.name == "Exit Light 3")) {
                            emergency_exit_sign = false;
                        } else if (hit.collider.name == "co2 extinguisher") {
                            co2_extinguisher = false;
                        } else if (hit.collider.name == "door access") {
                            door_access = false;
                        } else if (hit.collider.name == "emergency_exit_sign") {
                            emergency_exit_sign = false;
                        } else if (hit.collider.name == "ringer") {
                            ringer = false;
                        } else if (hit.collider.name == "fire_call_sign") {
                            fire_call_sign = false;
                        } else if (hit.collider.name == "fire_extinguisher_sign") {
                            fire_extinguisher_sign = false;
                        } else if (hit.collider.name == "fire_hose_sign") {
                            fire_hose_sign = false;
                        } else if (hit.collider.name == "fire_procedures_sign") {
                            fire_procedures_sign = false;
                        } else if (hit.collider.name == "foam_extinguisher") {
                            foam_extinguisher = false;
                        } else if (hit.collider.name == "powder_extinguisher") {
                            powder_extinguisher = false;
                        } else if (hit.collider.name == "water_extinguisher") {
                            water_extinguisher = false;
                        }
                    }
                }
            }
        }*/
    }
}
