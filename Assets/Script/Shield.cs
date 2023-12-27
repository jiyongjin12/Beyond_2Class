using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float plusPos;
    [SerializeField] private float moveTime;
    [SerializeField] private CheckBox checkBox;
    private Vector3 curPos;
    bool isMove;

    private void Start()
    {
        Block(0);
        checkBox.GetComponent<BoxCollider2D>().size = new Vector2(plusPos * 2, plusPos * 2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) Block(0);
        if (Input.GetKeyDown(KeyCode.DownArrow)) Block(1);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Block(2);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Block(3);
    }

    /// <summary>
    /// moveShield
    /// </summary>
    /// <param name="dir">0 == up, 1 == down, 2 == left, 3 == right, 4 <= return</param>
    public void Block(int dir)
    {
        if (isMove) return;
        Vector3 targetPos = Vector3.zero;

        switch (dir)
        {
            case 0: targetPos = new Vector3(0, plusPos); break;
            case 1: targetPos = new Vector3(0, -plusPos); break;
            case 2: targetPos = new Vector3(-plusPos, 0); break;
            case 3: targetPos = new Vector3(plusPos, 0); break;
        }
        if (targetPos == Vector3.zero || curPos == targetPos) return;

        curPos = targetPos;
        StartCoroutine(Move(targetPos, PlusPos(transform.position, targetPos), moveTime));
        checkBox.InputDir(dir);
    }

    private List<Vector3> PlusPos(Vector3 origPos, Vector3 targetPos)
    {
        List<Vector3> pos = new();
        Vector3 testPos = origPos + targetPos;

        if (testPos.x == 0 || testPos.y == 0)
        {
            int ran = Random.Range(0, 2);

            if (ran == 0) ran = -1;

            pos.Add(new Vector3((origPos.x == 0) ? origPos.x + ran * plusPos : origPos.x,
            (origPos.y == 0) ? origPos.y + ran * plusPos : origPos.y));
            pos.Add(new Vector3((targetPos.x == 0) ? targetPos.x + ran * plusPos : targetPos.x,
            (targetPos.y == 0) ? targetPos.y + ran * plusPos : targetPos.y));
        }
        else
        {
            pos.Add(testPos);
        }

        return pos;
    }

    protected IEnumerator Move(Vector3 _targetPos, List<Vector3> pos, float sec)
    {
        isMove = true;
        float z = 0;
        float elapsedTime = 0;
        Vector2 direction = Vector2.zero;
        Vector3 origPos = transform.position;
        Vector3 targetPos = _targetPos;
        Quaternion rot = Quaternion.identity;

        while (elapsedTime < sec)
        {
            transform.position = Bezier(origPos, targetPos, pos, elapsedTime / sec);
            direction = player.transform.position - transform.position;
            z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, z - 90f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        direction = player.transform.position - transform.position;
        z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z - 90f);
        isMove = false;
    }

    Vector3 Bezier(Vector3 startPos, Vector3 endPos, List<Vector3> plusPos, float value)
    {
        List<Vector3> posList = new List<Vector3> { startPos };
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
}
