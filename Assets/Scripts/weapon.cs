using StarterAssets;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] Animator animator;

    StarterAssetsInputs inputs;
    RaycastHit hit;
    EnemyHealth hitdamage;

    const string reload = "shoot";

    
     void Awake()
    {
        inputs = GetComponentInParent<StarterAssetsInputs>();
    }
    
    void Update()
    {
        if(!inputs.shoot) return;
        particle.Play();
        animator.Play(reload, 0, 0f);
        inputs.shoot = false;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyhealt = hit.collider.gameObject.GetComponent<EnemyHealth>();
            enemyhealt?.takedamage(1);
        }

    }
}
