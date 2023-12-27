using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Base : MonoBehaviour
{
    [HideInInspector] public float moveTime;
    public bool isBenefit;
    public int curDir;

    protected Coroutine startMove;

    protected virtual void Start()
    {
        startMove = StartCoroutine(Move(transform.position, 0, moveTime));
    }

    protected virtual IEnumerator Move(Vector3 startPos, float startTime, float sec)
    {
        float elapsedTime = startTime;
        Vector3 origPos = startPos;
        Vector3 targetPos = Vector3.zero;

        while (elapsedTime < sec)
        {
            transform.position = Vector3.LerpUnclamped(origPos, targetPos, EasingValue(elapsedTime / sec));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        DieDestory();
    }

    protected virtual float EasingValue(float value)
    {
        return value;
    }

    public void DieDestory()
    {
        Destroy(gameObject);
    }
}
