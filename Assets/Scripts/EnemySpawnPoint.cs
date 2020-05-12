using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyAsset;

    // Start is called before the first frame update
    void Start()
    {
        Enemy newEnemy = Instantiate(enemyAsset);
        newEnemy.transform.position = transform.position;

        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < transform.childCount; i++) {
            points.Add(transform.GetChild(i).position);
        }

        newEnemy.setRoute(points);

        Game.getInstance().addEnemy(newEnemy);
    }
}
