using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    [SerializeField] private int dir;

    public void InputDir(int curDir)
    {
        dir = curDir;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var temp = other.GetComponent<Enemy_Base>();

        if (temp.curDir == dir)
            if (temp.isBenefit) Debug.Log("S_Good");
            else Debug.Log("S_Bad");
        else return;

        temp.DieDestory();
    }
}
