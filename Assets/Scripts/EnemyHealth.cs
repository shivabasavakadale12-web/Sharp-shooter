using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject Robot_destroy;
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
            destroyprocess();
        }
    }

    public void destroyprocess()
    {
            Instantiate(Robot_destroy, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

    }
   
}
