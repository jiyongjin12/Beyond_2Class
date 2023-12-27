using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Base : MonoBehaviour
{
    [SerializeField] protected float moveTime;
    [SerializeField] private float tirggerTiming;
    public int curDir;
    private bool isTirgger;
    protected Coroutine startMove;

    protected virtual void Start()
    {
        startMove = StartCoroutine(Move(transform.position, 0, moveTime));
    }

    protected IEnumerator Move(Vector3 startPos, float startTime, float sec)
    {
        float elapsedTime = startTime;
        Vector3 origPos = startPos;
        Vector3 targetPos = Vector3.zero;

        while (elapsedTime < sec)
        {
            transform.position = Vector3.LerpUnclamped(origPos, targetPos, Easing(elapsedTime / sec));
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= tirggerTiming && !isTirgger) Tirgger(transform.position, elapsedTime);
            yield return null;
        }
    }

    protected virtual float Easing(float value)
    {
        return value;
    }

    protected virtual void Tirgger(Vector3 origPos, float curTime)
    {
        isTirgger = true;
    }

    public void DieDestory()
    {
        Destroy(gameObject);
    }
}
