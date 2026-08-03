using StarterAssets;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] CinemachineVirtualCamera playerfollowcamera;
    [SerializeField] GameObject scopeimage;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] WeaponSO StartingweaponSO;
    WeaponSO currentWeaponSO;
    StarterAssetsInputs inputs;

    FirstPersonController firstPersonController;
    Animator animator;
    weapon weapon;

     float defaultfov;
    float defaultrotationspeed;
    float timepass = 0f;
    int currentammo;
    const string recoil = "shoot";


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
        switchWeapon(StartingweaponSO); 
        

    }

    void Update()
    {
        timepass += Time.deltaTime;
        Heandleshoot();
        handleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        currentammo += amount;

        if (currentammo > currentWeaponSO.maxammo)
        {
            currentammo = currentWeaponSO.maxammo;
        }

        ammoText.text = currentammo.ToString("00");
    }

    public void switchWeapon(WeaponSO weaponSO)
    {
        if (weapon)
        {
         Destroy(weapon.gameObject);
        }
        weapon newWeapon = Instantiate(weaponSO.weaponprefab, transform).GetComponent<weapon>();
        weapon = newWeapon;
        currentWeaponSO = weaponSO;
        AdjustAmmo(currentWeaponSO.maxammo);
    }

    private void Heandleshoot()
    {
        if (!inputs.shoot) return;

        if (timepass >= currentWeaponSO.firerate && currentammo > 0)
        {
         animator.Play(recoil, 0, 0f);
         weapon.Shoot(currentWeaponSO);
         timepass = 0f;
         AdjustAmmo(-1);
        }

        if(!currentWeaponSO.IsAutomatic)
        {
         inputs.shoot = false;
        }  
    }

    void handleZoom()
    {
        if (!currentWeaponSO.CanZoom) return;

        if (inputs.zoom)
        {
            playerfollowcamera.m_Lens.FieldOfView = currentWeaponSO.ZoomIn;
            camera.fieldOfView = currentWeaponSO.ZoomIn;
            scopeimage.SetActive(true);
            firstPersonController.changerotationspeed(currentWeaponSO.rotationspeed);
        }

        else
        {
            playerfollowcamera.m_Lens.FieldOfView = defaultfov;
            camera.fieldOfView = defaultfov;
            scopeimage.SetActive(false);
            firstPersonController.changerotationspeed(defaultrotationspeed);

        }
    }
}
