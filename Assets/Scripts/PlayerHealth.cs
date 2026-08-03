using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currenthealth;

    public int health = 8;

    [SerializeField] CinemachineCamera deathcamera;
    [SerializeField] Transform weaponcamera;
    [SerializeField] Image[] shieldBars;

    void Awake()
    {
        currenthealth = health;
    }

    public void takedamage(int amount)
    {
        currenthealth -= amount;
        adjustshieldui();
        if (currenthealth <= 0)
        {
            deathcamera.Priority = 100;
            weaponcamera.parent = null;
            Destroy(this.gameObject);
        }
    }

    void adjustshieldui()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currenthealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }

        }
    }
}
