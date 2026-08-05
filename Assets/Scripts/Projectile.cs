using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 30f;

    Rigidbody rb;

     void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

     void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.takedamage(1);

        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }

}
