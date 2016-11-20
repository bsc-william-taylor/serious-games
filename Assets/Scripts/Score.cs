using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    Text text;
    ClickOnHazard clickOnHazard;


    void Start () {
        text = GetComponent<Text>();        
        clickOnHazard = GameObject.Find("Floor_5").GetComponent<ClickOnHazard>();
    }
    
    void Update () {
        if (clickOnHazard != null) {
            text.text = "";
            foreach (var identifiedItem in clickOnHazard.identified)
            {
                text.text += "\n" + clickOnHazard.descriptions[identifiedItem];
            }   
/*
            if (clickOnHazard.computer == true)                       { text.text += "Computer\n";                       }
            if (clickOnHazard.phone == true)                          { text.text += "Phone\n";                          }
            if (clickOnHazard.monitor == true)                        { text.text += "Monitor\n";                        }
            if (clickOnHazard.microwave == true)                      { text.text += "Microwave\n";                      }
            if (clickOnHazard.vending_machine == true)                { text.text += "Vending Machine\n";                }
            if (clickOnHazard.fire_door == true)                      { text.text += "Fire Door\n";                      }
            if (clickOnHazard.exit_light == true)                     { text.text += "Exit Light\n";                     }
            if (clickOnHazard.co2_extinguisher == true)               { text.text += "Co2 Extinguisher\n";               }
            if (clickOnHazard.door_access == true)                    { text.text += "Door Access\n";                    }
            if (clickOnHazard.emergency_exit_sign == true)            { text.text += "Emergency Exit Sign\n";            }
            if (clickOnHazard.ringer == true)                         { text.text += "Fire Ringer\n";                    }
            if (clickOnHazard.fire_call_sign == true)                 { text.text += "Fire Call Sign\n";                 }
            if (clickOnHazard.fire_extinguisher_sign == true)         { text.text += "Fire Extinguisher Sign\n";         }
            if (clickOnHazard.fire_hose_sign == true)                 { text.text += "Fire Hose Sign\n";                 }
            if (clickOnHazard.fire_procedures_sign == true)           { text.text += "Fire Procedures Sign\n";           }
            if (clickOnHazard.foam_extinguisher == true)              { text.text += "Foam Extinguisher\n";              }
            if (clickOnHazard.powder_extinguisher == true)            { text.text += "Powder Extinguisher\n";            }
            if (clickOnHazard.water_extinguisher == true)             { text.text += "Water Extinguisher\n";             }
            if (clickOnHazard.printer == true)                        { text.text += "Printer\n";                        }
            if (clickOnHazard.emergency_door_release_trigger == true) { text.text += "Emergency Door Release Trigger\n"; }
            if (clickOnHazard.fire_alarm_cable == true)               { text.text += "Fire Alarm Cable\n";               }
            if (clickOnHazard.propane_canister == true)               { text.text += "Propane Canister\n";               }
*/
        }
    }
}

/*
    Safety 16
    Hazard 10
*/