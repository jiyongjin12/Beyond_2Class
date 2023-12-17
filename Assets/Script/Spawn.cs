using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<Transform> pos;
    [SerializeField] private List<Enemy_Base> enemy;
    [SerializeField] private float maxDelay;
    float curDelay;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)) SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        int ranPos = Random.Range(0, pos.Count);
        int ranEnemy = Random.Range(0, enemy.Count);

        Instantiate(enemy[ranEnemy], pos[ranPos].position, Quaternion.identity);
    }
}
