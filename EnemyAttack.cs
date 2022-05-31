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
        //����łȂ���΍U������
        if (other.CompareTag("Player") && !enemyAttack &&
            EnemyMove.instance.die == false)
        {
            StartCoroutine("EnemyAttacks");
        }
    }
    IEnumerator EnemyAttacks()
    {
        //�v���C���[�Ƀ_���[�W�������
        PlayerMove.playerMoveIns.damage = true;
        PlayerMove.playerMoveIns.damageHp = true;
        //�U�������̂�3�b�ԃ_���[�W������Ȃ��悤�ɂ���
        enemyAttack = true;
        yield return new WaitForSeconds(3.0f);
        //�_���[�W������悤�ɂ���
        enemyAttack = false;
    }
}
