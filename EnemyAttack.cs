using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool enemyAttack;
    void Start()
    {
        enemyAttack = false;
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //死んでなければ攻撃する
        if (other.CompareTag("Player") && !enemyAttack &&
            EnemyMove.instance.die == false)
        {
            StartCoroutine("EnemyAttacks");
        }
    }
    IEnumerator EnemyAttacks()
    {
        //プレイヤーにダメージをいれる
        PlayerMove.playerMoveIns.damage = true;
        PlayerMove.playerMoveIns.damageHp = true;
        //攻撃したので3秒間ダメージが入らないようにする
        enemyAttack = true;
        yield return new WaitForSeconds(3.0f);
        //ダメージが入るようにする
        enemyAttack = false;
    }
}
