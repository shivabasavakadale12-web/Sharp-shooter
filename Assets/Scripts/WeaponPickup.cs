using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
     void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered by " + other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
           ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
           activeWeapon.switchWeapon(weaponSO);
           Destroy(this.gameObject);
        }
        
    }
}
