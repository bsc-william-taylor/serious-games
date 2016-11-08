using UnityEngine;
using System.Collections;

public class LeavingBuilding : MonoBehaviour {

    public bool leftBuilding;

	// Use this for initialization
	void Start () {
	    leftBuilding = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "Character") {
            Debug.Log("Left the building!");
            leftBuilding = true;
        }
    }   
}
