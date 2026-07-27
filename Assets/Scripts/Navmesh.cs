using StarterAssets;
using UnityEngine;
using UnityEngine.AI;


public class Navmesh : MonoBehaviour
{
    FirstPersonController player;
    
    NavMeshAgent agent;

    private void Awake()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        agent = GetComponent<NavMeshAgent>();   
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}

