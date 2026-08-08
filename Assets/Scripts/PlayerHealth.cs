using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currenthealth;

    public int health = 8;

    [SerializeField] GameObject gameover;
    [SerializeField] CinemachineCamera deathcamera;
    [SerializeField] Transform weaponcamera;
    [SerializeField] Image[] shieldBars;

    FirstPersonController FirstPersonController;
    void Awake()
    {
        Time.timeScale = 1f;
        FirstPersonController = FindFirstObjectByType<FirstPersonController>();
        gameover.SetActive(false);
        currenthealth = health;
    }

    public void takedamage(int amount)
    {
        currenthealth -= amount;
        adjustshieldui();
        if (currenthealth <= 0)
        {
            gameover.SetActive(true);
            deathcamera.Priority = 100;
            weaponcamera.parent = null;
            StarterAssetsInputs inputs = FindFirstObjectByType<StarterAssetsInputs>();
            inputs.SetCursorState(false);
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
