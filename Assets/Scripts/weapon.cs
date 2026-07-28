using StarterAssets;
using UnityEngine;

public class weapon : MonoBehaviour
{
    StarterAssetsInputs inputs;
    RaycastHit hit;


     void Awake()
    {
        inputs = GetComponentInParent<StarterAssetsInputs>();
    }
    
    void Update()
    {
        if(inputs.shoot)
        {
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity);
            if (hit.collider == null) return;
            Debug.Log(hit.collider.name);
            inputs.shoot = false;
        }
    }
}
