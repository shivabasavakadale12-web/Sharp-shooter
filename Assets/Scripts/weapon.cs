using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem particle; 
    EnemyHealth hitdamage;

    public void Shoot(WeaponSO weaponSO)
    {
     RaycastHit hit;
     particle.Play();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
         Instantiate(weaponSO.hitfx, hit.point, Quaternion.identity);
         EnemyHealth enemyhealt = hit.collider.gameObject.GetComponent<EnemyHealth>();
         enemyhealt?.takedamage(weaponSO.Damage);
        }
    }
}
