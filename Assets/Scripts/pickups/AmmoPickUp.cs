using UnityEngine;

public class AmmoPickUp : Pickup
{
    [SerializeField] int AmmoSize = 100;
    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(AmmoSize);
    }
}
