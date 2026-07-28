using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int currenthealth;

    public int health = 5;

     void Awake()
    {
        currenthealth = health;
    }

    public void takedamage(int amount)
    { 
        currenthealth -= amount;

        if (currenthealth <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
   
}
