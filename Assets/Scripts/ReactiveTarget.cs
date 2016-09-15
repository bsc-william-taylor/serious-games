using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour
{
    private SceneController controller;

    public void ReactToHit()
    {
        var behaviour = GetComponent<WanderingAi>();

        if (behaviour != null)
        {
            behaviour.Alive = false;
        }

        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);

        if (controller != null)
        {
            controller.RemoveEnemy(gameObject);
        }
    }

    void Start()
    {
        controller = GameObject.Find("SceneController").GetComponent<SceneController>();
    }

    void Update()
    {
    }
}
