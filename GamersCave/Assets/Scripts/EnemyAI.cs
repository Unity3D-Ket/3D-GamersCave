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

    // Start is called before the first frame update
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyChase();
    }

    public void enemyChase()
    {
        playerDistance = Vector3.Distance(playerTarget.position, transform.position);

        if (playerDistance <= enemyPOV)
        {
            meshAgent.SetDestination(playerTarget.position);
        }
    }
}
