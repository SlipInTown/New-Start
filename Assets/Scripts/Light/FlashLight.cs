using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    internal Color color;
    [SerializeField] private GameObject flashLight;
    
    private bool LightState = false;
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
