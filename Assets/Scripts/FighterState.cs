using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FighterState : MonoBehaviour
{
    public enum EquipableFireExtinguishers 
    {
        None, CO2, Foam, Powder, Water
    }

    public GameObject EquippedText;
    public GameObject TimeText;
    public GameObject DoneText;
    public GameObject Smoke;

    private EquipableFireExtinguishers equippedExtinguisher = EquipableFireExtinguishers.None;
    private float timerCountdown = 0.0f;
    private int firesPutOut = 0;

    public bool ExstinguisherActive()
    {
        return Smoke.activeSelf;
    }

    public EquipableFireExtinguishers GetEquippedEtinguisher()
    {
        return equippedExtinguisher;
    }

    public void SetFireExtinguisher(EquipableFireExtinguishers extinguishers)
    {
        equippedExtinguisher = extinguishers;

        var text = EquippedText.GetComponent<Text>();
        text.text = "Equipped Exstinguister: " + extinguishers;
    }

    void Start()
    {
        timerCountdown = 120.0f;
        DoneText.SetActive(false);
        Smoke.SetActive(false);
    }

    public void FirePutOut()
    {
        ++firesPutOut;
    }

    void Update()
    {
        timerCountdown -= Time.deltaTime;

        var text = TimeText.GetComponent<Text>();
        text.text = "Time Left: " + (int)timerCountdown;

        if (Input.GetMouseButtonDown(1) && equippedExtinguisher != EquipableFireExtinguishers.None)
        {
            Smoke.SetActive(!Smoke.activeSelf);
        }

        Smoke.transform.Rotate(Vector3.down, Input.GetAxis("Mouse Y"));
        Smoke.transform.Rotate(Vector3.left, Input.GetAxis("Mouse X") / 50.0f);

        if (firesPutOut == 6 || LeavingBuilding.leftBuilding)
        {
            DoneText.SetActive(true);
            var doneText = DoneText.GetComponent<Text>();
            doneText.text = "Done!!!";
        }
    }
}
