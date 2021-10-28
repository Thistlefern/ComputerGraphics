using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WillOWisp : MonoBehaviour
{
    public Text text;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
    }
}
