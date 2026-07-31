using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerfollowcamera;
    [SerializeField] GameObject scopeimage;
    [SerializeField] WeaponSO weaponSO;
    StarterAssetsInputs inputs;

    FirstPersonController firstPersonController;
    Animator animator;
    weapon weapon;

     float defaultfov;
    float defaultrotationspeed;
    float timepass = 0f;
    const string reload = "shoot";


    void Awake()
    {
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        inputs = GetComponentInParent<StarterAssetsInputs>();
        defaultfov = playerfollowcamera.m_Lens.FieldOfView;
        defaultrotationspeed = firstPersonController.RotationSpeed;
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
            playerfollowcamera.m_Lens.FieldOfView = weaponSO.ZoomIn;
            scopeimage.SetActive(true);
            firstPersonController.changerotationspeed(weaponSO.rotationspeed);
        }

        else
        {
            playerfollowcamera.m_Lens.FieldOfView = defaultfov;
            scopeimage.SetActive(false);
            firstPersonController.changerotationspeed(defaultrotationspeed);

        }
    }
}
