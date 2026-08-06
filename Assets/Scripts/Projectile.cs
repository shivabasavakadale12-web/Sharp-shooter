using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 30f;

    Rigidbody rb;
    public int damage;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void init(int damage)
    {
        this.damage = damage;
    }
     void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (other.CompareTag("Player"))
        {   
         playerHealth?.takedamage(damage);
        }
            Destroy(gameObject);

    }

}
