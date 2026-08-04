using UnityEngine;

public class Projectile : MonoBehaviour
{
   
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 movement = transform.forward * 10f * Time.deltaTime;
    }
}
