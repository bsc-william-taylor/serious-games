﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ClickOnHazard : MonoBehaviour
{
    public HashSet<string> identified = new HashSet<string>();
    public HashSet<string> collectedItems = new HashSet<string>();
    public HashSet<string> collectedHazardItems = new HashSet<string>();
    public HashSet<string> collectedSafetyItems = new HashSet<string>();
    public Dictionary<string, string> descriptions = new Dictionary<string, string>();
    
    private Dictionary<string, string> hDescriptions = new Dictionary<string, string>();
    private Dictionary<string, string> sDescriptions = new Dictionary<string, string>();
    private HashSet<string> safetyItems = new HashSet<string>();
    private HashSet<string> hazardItems = new HashSet<string>();
    private string hitObject = "";
    public string lookingAt = "";
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();

        hDescriptions.Add("computer", "Computers");
        hDescriptions.Add("phone", "Telephones");
        hDescriptions.Add("monitor", "Monitors");
        hDescriptions.Add("microwave", "Microwave ovens");
        hDescriptions.Add("snacksvendingmachine", "Snacks vending machines");
        hDescriptions.Add("drinksvendingmachine", "Drinks vending machines");
        hDescriptions.Add("coffee_machine", "Coffee machines");
        hDescriptions.Add("printer", "Printers");
        hDescriptions.Add("front_heater", "Radiators");
        hDescriptions.Add("fuel_can", "Fuel Canisters");

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
        sDescriptions.Add("aid_box", "First Aid Cabinets");

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

    void Update()
    {
        lookingAt = "";

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hitObject = hit.collider.name.ToLower();

                if (hazardItems.Contains(hitObject) && scene.name == "Hazards")
                {
                    if (collectedHazardItems.Contains(hitObject))
                    {
                        collectedItems.Remove(hitObject);
                        collectedHazardItems.Remove(hitObject);
                    }
                    else
                    {
                        collectedItems.Add(hitObject);
                        collectedHazardItems.Add(hitObject);
                    }

                    identified = collectedItems;
                }
                else if (safetyItems.Contains(hitObject) && scene.name == "Safety")
                {
                    if (collectedSafetyItems.Contains(hitObject))
                    {
                        collectedItems.Remove(hitObject);
                        collectedSafetyItems.Remove(hitObject);
                    }
                    else
                    {
                        collectedItems.Add(hitObject);
                        collectedSafetyItems.Add(hitObject);
                    }

                    identified = collectedItems;
                }
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                string item = hit.collider.name.ToLower();
                if ((hazardItems.Contains(item)) && (scene.name == "Hazards"))
                {
                    lookingAt = descriptions[item];
                }
                else if ((safetyItems.Contains(item)) && (scene.name == "Safety"))
                {
                    lookingAt = descriptions[item];
                }
            }
        }
    }
}