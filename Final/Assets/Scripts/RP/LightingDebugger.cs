using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingDebugger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lighting settings on scene load:");
        Debug.Log("Ambient Light: " + RenderSettings.ambientLight);
        Debug.Log("Skybox: " + RenderSettings.skybox);
        
    }


}
