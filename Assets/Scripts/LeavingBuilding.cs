using UnityEngine;
using System.Collections;

public class LeavingBuilding : MonoBehaviour
{
    public static bool leftBuilding;

    // Use this for initialization
    void Start()
    {
        leftBuilding = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Character")
        {
            Debug.Log("Left the building!");
            leftBuilding = true;
        }
    }
}
