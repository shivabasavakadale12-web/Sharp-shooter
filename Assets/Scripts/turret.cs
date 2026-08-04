using System.Collections;
using UnityEngine;

public class turret : MonoBehaviour
{
    [SerializeField] Transform turrethead;
    [SerializeField] Transform spawnbullets;
    [SerializeField] GameObject target;
    [SerializeField] GameObject turretbullets;

    PlayerHealth player;

     void Start()
    {
        player = FindFirstObjectByType(typeof(PlayerHealth)) as PlayerHealth;
        StartCoroutine(fireroutine());
    }
     void Update()
    {
        turrethead.LookAt(target.transform.position);
    }

    IEnumerator fireroutine()
    {
        while(player)
        {
         yield return new WaitForSeconds(3f);
         Instantiate(turretbullets, spawnbullets.position, turrethead.rotation);
        }
    }
}
