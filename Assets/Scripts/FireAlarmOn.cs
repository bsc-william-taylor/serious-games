using UnityEngine;

public class FireAlarmOn : MonoBehaviour
{
    public AudioSource AudioFile;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == name)
                {
                    AudioFile.loop = true;
                    AudioFile.Play();
                }
            }
        }
    }
}
