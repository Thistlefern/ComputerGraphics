using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePenta : MonoBehaviour
{
    private Mesh customMesh;
    void Start()
    {
        // First, let's create a new mesh
        var mesh = new Mesh();

        #region vertices
        // locations of vertices
        // note: this can skew the image on the mesh
        var verts = new Vector3[5];
        verts[0] = new Vector3(-0.5f, -0.5f, 0);
        verts[1] = new Vector3(-0.5f, 0.5f, 0);
        verts[2] = new Vector3(0, 1, 0);
        verts[3] = new Vector3(0.5f, 0.5f, 0);
        verts[4] = new Vector3(0.5f, -0.5f, 0);
        mesh.vertices = verts;
        #endregion
        #region indices
        // determines which vertices make up an individual triangle
        // this should always be a multiple of three
        // each triangle should be specified in ***CLOCK-WISE*** order
        var indices = new int[9];
        indices[0] = 0;
        indices[1] = 1;
        indices[2] = 4;
        indices[3] = 3;
        indices[4] = 4;
        indices[5] = 1;
        indices[6] = 1;
        indices[7] = 2;
        indices[8] = 3;

        mesh.triangles = indices;
        #endregion
        #region normals
        // describes how light bounces off the surface (at the vertex level)
        // note that this data is interpolated across the surface of the triangle
        var norms = new Vector3[5];
        norms[0] = -Vector3.forward;
        norms[1] = -Vector3.forward;
        norms[2] = -Vector3.forward;
        norms[3] = -Vector3.forward;
        norms[4] = -Vector3.forward;
        mesh.normals = norms;
        #endregion
        #region UVs/STs
        // defines how textures are mapped onto the surface
        // what vertice of the IMAGE will print on the vertices of the MESH?
        // ex: (0,0), (0,1), (1,0) prints the image as normal size, while (0,0), (0,2), (2,0) prints the image twice, tiled
        var UVs = new Vector2[5];
        UVs[0] = new Vector2(0, 0);
        UVs[1] = new Vector2(0, 1);
        UVs[2] = new Vector2(0.5f, 1.5f);
        UVs[3] = new Vector2(1, 1);
        UVs[4] = new Vector2(1, 0);
        mesh.uv = UVs;
        #endregion

        var filter = GetComponent<MeshFilter>();
        filter.mesh = mesh;
        customMesh = mesh;
    }

    private void OnDestroy()
    {
        // Clean up our mess, if we created it
        if (customMesh != null)
        {
            Destroy(customMesh);
        }
    }
}
