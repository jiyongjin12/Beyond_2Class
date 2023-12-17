using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirggerEnemy_Base : Enemy_Base
{
    public List<Vector3> pos;
    [SerializeField] private float plusPos;

    protected override void Start()
    {
        base.Start();
        pos.Add(PlusPos());
    }

    protected override void Tirgger(Vector3 startPos, float curTime)
    {
        base.Tirgger(startPos, curTime);
        StopCoroutine(startMove);
        StartCoroutine(BezierMove(startPos, -transform.position, 0.5f, curTime));
    }

    private IEnumerator BezierMove(Vector3 startPos, Vector3 target, float sec, float curTime)
    {
        float elapsedTime = 0;
        Vector3 origPos = transform.position;
        Vector3 targetPos = target;

        while (elapsedTime < sec)
        {
            transform.position = Bezier(origPos, targetPos, pos, Easing(elapsedTime / sec));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        StartCoroutine(Move(-startPos, 0, moveTime));
    }

    Vector3 Bezier(Vector3 startPos, Vector3 endPos, List<Vector3> plusPos, float value)
    {
        List<Vector3> posList = new List<Vector3>();

        posList.Add(startPos);
        foreach (var n in plusPos)
        {
            posList.Add(n);
        }
        posList.Add(endPos);

        while (posList.Count > 1)
        {
            List<Vector3> curPos = new List<Vector3>();
            for (int i = 0; i < posList.Count - 1; i++)
            {
                curPos.Add(Vector3.LerpUnclamped(posList[i], posList[i + 1], value));
            }
            posList = curPos;
        }

        return posList[0];
    }

    Vector3 PlusPos()
    {
        int ran = Random.Range(0, 2);

        if(ran == 0) ran = -1;

        if(transform.position.x == 0) return new Vector3(ran * plusPos, 0);
        else return new Vector3(0, ran * plusPos);
    }
}
