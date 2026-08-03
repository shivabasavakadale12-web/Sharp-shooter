using StarterAssets;
using UnityEngine;
using UnityEngine.AI;


public class Navmesh : MonoBehaviour
{
    FirstPersonController player;
    
    NavMeshAgent agent;

    const string player_string = "Player";

    private void Awake()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        agent = GetComponent<NavMeshAgent>();   
    }

    private void Update()
    {
        if(!player) return;
        agent.SetDestination(player.transform.position);
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player_string))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.destroyprocess();
        }
    }
}

