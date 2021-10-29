using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightIntensity : MonoBehaviour
{
    public Light light;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            light.intensity += Time.deltaTime;
            if(light.intensity > 5)
            {
                light.intensity = 5;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            light.intensity -= Time.deltaTime;
        }
    }
}
