using System.Collections;
using UnityEngine;

public class spawngate : MonoBehaviour
{
    [SerializeField] GameObject Robots;

    PlayerHealth player;

    game_manager manager;
   
    void Start()
    {
        manager = FindFirstObjectByType(typeof(game_manager)) as game_manager;
        player = FindFirstObjectByType(typeof(PlayerHealth)) as PlayerHealth;       
       StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while(player)
        {
         Instantiate(Robots, this.transform.position, Quaternion.identity);
         manager.adjustenemy(1);
         yield return new WaitForSeconds(8f);
        }    
    }
}
