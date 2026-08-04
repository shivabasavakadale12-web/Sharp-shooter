using System.Collections;
using UnityEngine;

public class spawngate : MonoBehaviour
{
    [SerializeField] GameObject Robots;

    PlayerHealth player;
   
    void Start()
    {
        player = FindFirstObjectByType(typeof(PlayerHealth)) as PlayerHealth;       
       StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while(player)
        {
         Instantiate(Robots, this.transform.position, Quaternion.identity);
         yield return new WaitForSeconds(5f);
        }
      
    }
}
