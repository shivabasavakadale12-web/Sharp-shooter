using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;

     void Awake()
    {
        weaponSO = FindFirstObjectByType<WeaponSO>();
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(weaponSO.name);
        }
        
    }
}
