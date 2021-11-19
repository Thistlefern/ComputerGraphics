using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievments : MonoBehaviour
{
    static int test;
    public PumpkinNice pumpkin;
    bool hints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(test);

        if(pumpkin.talking && !hints)
        {
            hints = true;
            test++;
            if (!pumpkin.talking)
            {
                hints = false;
            }
        }
    }
}
