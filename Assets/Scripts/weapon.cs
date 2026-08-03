using Unity.Cinemachine;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] LayerMask ignorelayer;
    EnemyHealth hitdamage;

    CinemachineImpulseSource impulseSource;

     void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    public void Shoot(WeaponSO weaponSO)

    {
     RaycastHit hit;
     impulseSource.GenerateImpulse();

     particle.Play();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, ignorelayer, QueryTriggerInteraction.Ignore))
        {
         Instantiate(weaponSO.hitfx, hit.point, Quaternion.identity);
         EnemyHealth enemyhealt = hit.collider.gameObject.GetComponent<EnemyHealth>();
         enemyhealt?.takedamage(weaponSO.Damage);
        }
    }
}
