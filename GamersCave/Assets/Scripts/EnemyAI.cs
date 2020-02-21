using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform playerTarget;
    [SerializeField] float enemyPOV = 5f;

    NavMeshAgent meshAgent;
    float playerDistance = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(playerTarget.position, transform.position);

        engagePlayer();
    }

    private void engagePlayer()
    {
        if (isProvoked = true)
        {
            enemyChase();
        }
    }

    private void enemyChase()
    {
        if (playerDistance <= meshAgent.stoppingDistance)
        {
            enemyAttack();
        }
        else if (playerDistance <= enemyPOV)
        {
            meshAgent.SetDestination(playerTarget.position);
        }
    }

    private void enemyAttack()
    {
        Debug.Log(name + " has attacked the " + playerTarget.name);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyPOV);
    }
}
