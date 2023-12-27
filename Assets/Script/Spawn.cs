using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<Transform> pos;
    [SerializeField] private List<Enemy_Base> badEnemy;
    [SerializeField] private List<Enemy_Base> goodEnemy;
    [SerializeField] private float maxDelay;
    [SerializeField] private int minBenefit;
    [SerializeField] private int maxBenefit;
    private float curDelay;
    private int curBenefit;

    private void Start()
    {
        curBenefit = Random.Range(minBenefit, maxBenefit + 1);
    }

    private void Update()
    {
        curDelay += Time.deltaTime;
        if (curDelay >= maxDelay)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, badEnemy.Count);
        int ranPos = Random.Range(0, pos.Count);

        var temp = Instantiate(badEnemy[ranEnemy], pos[ranPos].position, Quaternion.identity).GetComponent<Enemy_Base>();
        temp.moveTime = maxDelay;
        temp.curDir = ranPos;

        if (curBenefit == 0)
        {
            while (true)
            {
                int ranEnemy2 = Random.Range(0, badEnemy.Count);
                int ranPos2 = Random.Range(0, pos.Count);

                if (ranPos != ranPos2)
                {
                    var temp2 = Instantiate(goodEnemy[ranEnemy2], pos[ranPos2].position, Quaternion.identity).GetComponent<Enemy_Base>();
                    temp2.moveTime = maxDelay;
                    temp2.curDir = ranPos2;
                    break;
                }
            }
        }
        curDelay = 0;
        curBenefit--;
        if (curBenefit < 0) curBenefit = Random.Range(minBenefit, maxBenefit);
    }
}
