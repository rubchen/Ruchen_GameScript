using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent navMeshAgent;
    private Animator zombieAnim;
    public bool die;
    public static EnemyMove instance;
    [SerializeField] Collider[] zombieCollider;

    public void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        zombieAnim = GetComponent<Animator>();
        zombieAnim.SetBool("Run", true);
        die = false;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //�v���C���[��ǔ�
        navMeshAgent.destination = player.transform.position;
        //���񂾂Ƃ��̏���
        if (die)
        {
            zombieAnim.SetBool("Die", true);
            for (int i = 0; i < zombieCollider.Length; i++)
            {
                Destroy(zombieCollider[i]);
            }
            StartCoroutine("DestroyEnemy");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&!die)
        {
            //�~�܂��čU��
            GetComponent<NavMeshAgent>().isStopped = true;
            zombieAnim.SetBool("Run", false);
            zombieAnim.SetBool("Attack", true);
        }
        if (other.CompareTag("RightHand")&&!die)
        {
            die = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !die)
        {
            //�͈͊O�ɏo����܂��ǐ�
            GetComponent<NavMeshAgent>().isStopped = false;
            zombieAnim.SetBool("Run", true);
            zombieAnim.SetBool("Attack", false);
        }
    }

    //2�b��ɍ폜
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
