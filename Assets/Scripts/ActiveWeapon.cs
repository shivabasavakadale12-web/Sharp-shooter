using StarterAssets;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ActiveWeapon : MonoBehaviour
{

    [SerializeField] WeaponSO weaponSO;
    StarterAssetsInputs inputs;

    Animator animator;
    weapon weapon;

    float timepass = 0f;
    const string reload = "shoot";


    void Awake()
    {
        animator = GetComponent<Animator>();
        inputs = GetComponentInParent<StarterAssetsInputs>();
    }

     void Start()
    {
        weapon = GetComponentInChildren<weapon>();
    }

    void Update()
    {
        timepass += Time.deltaTime;
        Heandleshoot();
        handleZoom();


    }
    
    public void switchWeapon(WeaponSO weaponSO)
    {
        Destroy(weapon.gameObject);
        weapon newWeapon = Instantiate(weaponSO.weaponprefab, transform).GetComponent<weapon>();
        weapon = newWeapon;
    }

    private void Heandleshoot()
    {
        if (!inputs.shoot) return;

        if (timepass >= weaponSO.firerate)
        {
         animator.Play(reload, 0, 0f);
         weapon.Shoot(weaponSO);
         timepass = 0f;
        }

        if(!weaponSO.IsAutomatic)
        {
         inputs.shoot = false;
        }  
    }

    void handleZoom()
    {
        if (!weaponSO.CanZoom) return;

        if (inputs.zoom)
        {
            Debug.Log("zoomed in");
        }

        else
        {
            Debug.Log("zoomed out ");
        }
    }
}
