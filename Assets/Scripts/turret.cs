using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class turret : MonoBehaviour
{
    [SerializeField] Transform turrethead;
  
    [SerializeField] Transform spawnbullets;
    [SerializeField] GameObject target;
    [SerializeField] GameObject turretbullets;
    [SerializeField] int damage = 1;

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
          Projectile newprojectile = Instantiate(turretbullets, spawnbullets.position, turrethead.rotation).GetComponent<Projectile>();
          newprojectile.init(damage);
        }
    }
}
