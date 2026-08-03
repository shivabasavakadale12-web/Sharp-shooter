using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;

    int damage = 3;

    void Start()
     {
        explode(); 
     }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in colliders)
        {
            PlayerHealth playerhealth = collider.GetComponent<PlayerHealth>();

            if (!playerhealth) continue;

            playerhealth.takedamage(damage);

            break;
        }
    }
}
