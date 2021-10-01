using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer.material.SetColor("_Color", Color.green);
    }
}
