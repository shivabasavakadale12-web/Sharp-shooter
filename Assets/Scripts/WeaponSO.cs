using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "scriptableobjects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponprefab;
    public int Damage = 1;
    public float firerate = .5f;
    public GameObject hitfx;
    public bool IsAutomatic = false;
    public bool CanZoom = false;
}
