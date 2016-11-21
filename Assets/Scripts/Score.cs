using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
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
        }
    }
}

/*
    Safety 16
    Hazard 10
*/