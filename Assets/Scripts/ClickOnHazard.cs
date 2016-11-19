using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ClickOnHazard : MonoBehaviour
{
    public HashSet<string> identified = new HashSet<string>();
    private string hitObject = "";
    Scene scene;

    public Dictionary<string, string> descriptions = new Dictionary<string, string>();
    Dictionary<string, string> hDescriptions = new Dictionary<string, string>();
    Dictionary<string, string> sDescriptions = new Dictionary<string, string>();

    HashSet<string> safetyItems = new HashSet<string>();
    HashSet<string> hazardItems = new HashSet<string>();

    HashSet<string> collectedHazardItems = new HashSet<string>();
    HashSet<string> collectedSafetyItems = new HashSet<string>();

    // Use this for initialization
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        Debug.Log("active scene: " + scene.ToString());

        hDescriptions.Add("computer", "Computers");
        hDescriptions.Add("phone", "Telephones");
        hDescriptions.Add("monitor", "Monitors");
        hDescriptions.Add("microwave", "Microwave ovens");
        hDescriptions.Add("snacksvendingmachine", "Snacks vending machines");
        hDescriptions.Add("drinksvendingmachine", "Drinks vending machines");
        hDescriptions.Add("coffee_machine", "Coffee machines");
        hDescriptions.Add("printer", "Printers");
        hDescriptions.Add("front_heater", "Radiators");
        hDescriptions.Add("fuel_can", "Fuel canisters");

        hazardItems = new HashSet<string>(hDescriptions.Keys);

        sDescriptions.Add("fire_door", "Fire doors");
        sDescriptions.Add("emergency_exit_sign", "Emergency exit lights");
        sDescriptions.Add("co2_extinguisher", "CO2 Fire Extinguishers");
        sDescriptions.Add("foam_extinguisher", "Foam Fire Extinguishers");
        sDescriptions.Add("powder_extinguisher", "Powder Fire Extinguishers");
        sDescriptions.Add("water_extinguisher", "Water Fire Extinguishers");
        sDescriptions.Add("sprinkler", "Sprinklers");
        sDescriptions.Add("fire_alarm", "Fire alarms");
        sDescriptions.Add("fire_alarm_call_point_sign", "Fire alarm call point signs");
        sDescriptions.Add("fire_extinguisher_sign", "Fire extinguisher point signs");
        sDescriptions.Add("fire_hose_sign", "Fire hose reel signs");
        sDescriptions.Add("hydrant", "Hydrant");
        sDescriptions.Add("fire_procedures_sign", "Fire action signs");
        sDescriptions.Add("emergency_door_release_trigger", "Emergency door release triggers");
        sDescriptions.Add("fire_alarm_trigger", "Fire alarm triggers");
        sDescriptions.Add("aid_box", "First aid cabinets");

        safetyItems = new HashSet<string>(sDescriptions.Keys);

        foreach (var entry in hDescriptions)
        {
            descriptions.Add(entry.Key, entry.Value);
        }

        foreach (var entry in sDescriptions)
        {
            descriptions.Add(entry.Key, entry.Value);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hitObject = hit.collider.name.ToLower();
                System.Console.WriteLine(hitObject);
                Debug.Log(hitObject);
                if (scene != null)
                {
                    if (scene.name == "Hazards")
                    {
                        if (hazardItems.Contains(hitObject))
                        {
                            if (collectedHazardItems.Contains(hitObject))
                            {
                                collectedHazardItems.Remove(hitObject);
                            }
                            else
                            {
                                collectedHazardItems.Add(hitObject);
                            }
                            identified = collectedHazardItems;
                        }
                    }
                    else if (scene.name == "Safety")
                    {
                        if (safetyItems.Contains(hitObject))
                        {
                            if (collectedSafetyItems.Contains(hitObject))
                            {
                                collectedSafetyItems.Remove(hitObject);
                            }
                            else
                            {
                                collectedSafetyItems.Add(hitObject);
                            }
                            identified = collectedSafetyItems;
                        }
                    }
                }
                else
                {
                    identified.Add("scene is null");
                }
            }
        }
    }
}