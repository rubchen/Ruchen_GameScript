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
        //プレイヤーを追尾
        navMeshAgent.destination = player.transform.position;
        //死んだときの処理
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
            //止まって攻撃
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
            //範囲外に出たらまた追跡
            GetComponent<NavMeshAgent>().isStopped = false;
            zombieAnim.SetBool("Run", true);
            zombieAnim.SetBool("Attack", false);
        }
    }

    //2秒後に削除
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
