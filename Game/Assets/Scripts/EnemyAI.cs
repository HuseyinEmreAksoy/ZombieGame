using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    EnemyHealth healh;

    bool flag = false;
    float disTarget = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        healh = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healh.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        else
        {
            disTarget = Vector3.Distance(target.position, transform.position);
            if (flag)
            {
                EngageTarget();
            }
            else if (disTarget <= chaseRange)
            {
                flag = true;

            }
        }
        
    }
    public void OnDamageTaken()
    {
        flag = true;
    }
    void EngageTarget()
    {
        FaceTarget();
        if(disTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (disTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
            

    }
    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion LookR = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookR, Time.deltaTime * turnSpeed);
    }
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack",true);    }

}
