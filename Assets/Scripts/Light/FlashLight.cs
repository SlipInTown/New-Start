using UnityEngine;

public sealed class FlashLight : MonoBehaviour
{
    internal Color color;
    [SerializeField] private GameObject flashLight;
    
    private bool LightState = false;
    private void Start()
    {
        if (flashLight = null)
            throw new System.Exception("GameObject фонарика не настроен");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {   

            if (!LightState)
            {
                flashLight.SetActive(true);
                LightState = true;
            }
            else
            {
                flashLight.SetActive(false);
                LightState = false;
            }
        }
    }
}
