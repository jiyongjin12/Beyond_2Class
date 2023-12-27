using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var temp = other.GetComponent<Enemy_Base>();

        if(temp.isBenefit) Debug.Log("P_Good");
        else Debug.Log("P_Bad");

        temp.DieDestory();
    }
}
