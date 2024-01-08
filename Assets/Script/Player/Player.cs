using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float curHp;
    [SerializeField] private float dieTime;
    [SerializeField] private Image hpBar;

    [Header("0 ~ 1")]
    [SerializeField] private float damage;
    [SerializeField] private float hill;

    private void Start()
    {
        curHp = 1;
    }

    private void Update()
    {
        curHp -= Time.deltaTime * (1 / dieTime);
        hpBar.fillAmount = curHp;
        if(curHp <= 0) Debug.Log("Die");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var temp = other.GetComponent<Enemy_Base>();

        if (temp.isBenefit) {
            curHp += (hill / dieTime);
            if(curHp > 1) curHp = 1;
        }
        else curHp -= (damage / dieTime);

        temp.DieDestory();
    }
}
