using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject Robot_destroy;
    [SerializeField] bool registeronStart = false;
    public int currenthealth;

    public int health = 5;

    game_manager manager;

     void Awake()
    {
        manager = FindFirstObjectByType<game_manager>();
        currenthealth = health;
    }

    void Start()
    {
        if (registeronStart)
        {
            manager.adjustenemy(1);
        }
    }

    public void takedamage(int amount)
    { 
        currenthealth -= amount;

        if (currenthealth <= 0) 
        {
            manager.adjustenemy(-1);
            destroyprocess();
        }
    }

    public void destroyprocess()
    {
            Instantiate(Robot_destroy, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

    }
   
}
