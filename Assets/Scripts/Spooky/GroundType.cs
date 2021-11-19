using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundType : MonoBehaviour
{
    public bool test;
    public new string name;

    private void Update()
    {
        test = Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit hit);
        name = hit.collider.name;
    }
}