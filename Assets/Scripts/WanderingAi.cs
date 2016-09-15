using UnityEngine;
using System.Collections;

public class WanderingAi : MonoBehaviour
{
    public const float ObstacleRange = 5.0f;
    public const float Speed = 3.0f;

    public bool Alive { get; set; }

    void Start()
    {
        Alive = true;
    }

    void Update()
    {
        if (!Alive)
        {
            return;
        }

        transform.Translate(0, 0, Speed * Time.deltaTime);
        var ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < ObstacleRange)
            {
                var angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
