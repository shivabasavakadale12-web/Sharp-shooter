using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "scriptableobjects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public int Damage = 1;
    public float firerate = .5f;
    public GameObject hitfx;
    public bool IsAutomatic = false;
}
