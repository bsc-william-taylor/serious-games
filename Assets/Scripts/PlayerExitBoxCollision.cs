using UnityEngine;
using System.Collections;

public class PlayerExitBoxCollision : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Debug.Log("Hit");
    }
}
