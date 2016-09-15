using UnityEngine;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
    public const int EnemiesToSpawn = 10;

    private readonly List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private GameObject enemyPrefab;


    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        DestroyObject(enemy);
    }

    void Start()
    {
    }

    void Update()
    {
        if (enemies.Count != EnemiesToSpawn)
        {
            var angle = Random.Range(0, 360);
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(0, 1, 0);
            enemy.transform.Rotate(0, angle, 0);

            enemies.Add(enemy);
        }
    }
}
