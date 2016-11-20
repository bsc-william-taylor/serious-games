using System;
using UnityEngine;
using FireExtinguishers = FighterState.EquipableFireExtinguishers;

public class Extinguishable : MonoBehaviour
{
    public FireExtinguishers OutType1 = FireExtinguishers.None;
    public FireExtinguishers OutType2 = FireExtinguishers.None;
    public FireExtinguishers OutType3 = FireExtinguishers.None;
    public FireExtinguishers OutType4 = FireExtinguishers.None;
    public FighterState State;
    public GameObject Light;

    private Light pointLight;

    void Start()
    {
        pointLight = Light.GetComponent<Light>();
    }

    void Update()
    {
        if (State.ExstinguisherActive())
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance <= 10.0f && hit.collider.name == name)
                {
                    TestExtinguisher(OutType1);
                    TestExtinguisher(OutType2);
                    TestExtinguisher(OutType3);
                    TestExtinguisher(OutType4);
                }
            }
        }
    }

    void TestExtinguisher(FireExtinguishers type)
    {
        if (type == State.GetEquippedEtinguisher() && type != FireExtinguishers.None && gameObject.activeSelf)
        {
            var component = GetComponent<ParticleSystem>();

            if (component != null)
            {
                component.startLifetime -= Time.deltaTime;
                pointLight.intensity -= Time.deltaTime;

                if (component.startLifetime <= 0.0f)
                {
                    Light.SetActive(false);
                    gameObject.SetActive(false);
                    State.FirePutOut();
                }
            }
        }
    }
}
