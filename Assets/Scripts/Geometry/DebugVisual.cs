using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugVisual : MonoBehaviour
{
    public MeshFilter meshFilter;

    private void OnDrawGizmos()
    {
        for(int i = 0; i < meshFilter.mesh.vertexCount; i++)
        {
            Gizmos.DrawWireSphere(meshFilter.mesh.vertices[i], 0.5f);
        }
    }
}
