using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCube : MonoBehaviour
{
    private Mesh customMesh;
    void Start()
    {
        // First, let's create a new mesh
        var mesh = new Mesh();

        #region vertices
        // locations of vertices
        // note: this can skew the image on the mesh
        var verts = new Vector3[24];
        verts[0] = new Vector3(-0.5f, -0.5f, -0.5f);    // 0 = 11 = 21
        verts[1] = new Vector3(-0.5f, 0.5f, -0.5f);     // 1 = 10 = 16
        verts[2] = new Vector3(0.5f, 0.5f, -0.5f);      // 2 = 13 = 19
        verts[3] = new Vector3(0.5f, -0.5f, -0.5f);     // 3 = 12 = 22
        verts[4] = new Vector3(-0.5f, 0.5f, 0.5f);      // 4 = 9 = 17
        verts[5] = new Vector3(-0.5f, -0.5f, 0.5f);     // 5 = 8 = 20
        verts[6] = new Vector3(0.5f, -0.5f, 0.5f);      // 6 = 15 = 23
        verts[7] = new Vector3(0.5f, 0.5f, 0.5f);       // 7 = 14 = 18
        verts[8] = new Vector3(-0.5f, -0.5f, 0.5f);
        verts[9] = new Vector3(-0.5f, 0.5f, 0.5f);
        verts[10] = new Vector3(-0.5f, 0.5f, -0.5f);
        verts[11] = new Vector3(-0.5f, -0.5f, -0.5f);
        verts[12] = new Vector3(0.5f, -0.5f, -0.5f);
        verts[13] = new Vector3(0.5f, 0.5f, -0.5f);
        verts[14] = new Vector3(0.5f, 0.5f, 0.5f);
        verts[15] = new Vector3(0.5f, -0.5f, 0.5f);
        verts[16] = new Vector3(-0.5f, 0.5f, -0.5f);
        verts[17] = new Vector3(-0.5f, 0.5f, 0.5f);
        verts[18] = new Vector3(0.5f, 0.5f, 0.5f);
        verts[19] = new Vector3(0.5f, 0.5f, -0.5f);
        verts[20] = new Vector3(-0.5f, -0.5f, 0.5f);
        verts[21] = new Vector3(-0.5f, -0.5f, -0.5f);
        verts[22] = new Vector3(0.5f, -0.5f, -0.5f);
        verts[23] = new Vector3(0.5f, -0.5f, 0.5f);
        mesh.vertices = verts;
        #endregion
        #region indices
        // determines which vertices make up an individual triangle
        // this should always be a multiple of three
        // each triangle should be specified in ***CLOCK-WISE*** order
        var indices = new int[36];
        indices[0] = 0;
        indices[1] = 1;
        indices[2] = 2;
        indices[3] = 2;
        indices[4] = 3;
        indices[5] = 0;
        indices[6] = 4;
        indices[7] = 5;
        indices[8] = 6;
        indices[9] = 6;
        indices[10] = 7;
        indices[11] = 4;
        indices[12] = 8;
        indices[13] = 9;
        indices[14] = 10;
        indices[15] = 10;
        indices[16] = 11;
        indices[17] = 8;
        indices[18] = 12;
        indices[19] = 13;
        indices[20] = 14;
        indices[21] = 14;
        indices[22] = 15;
        indices[23] = 12;
        indices[24] = 16;
        indices[25] = 17;
        indices[26] = 18;
        indices[27] = 18;
        indices[28] = 19;
        indices[29] = 16;
        indices[30] = 20;
        indices[31] = 21;
        indices[32] = 22;
        indices[33] = 22;
        indices[34] = 23;
        indices[35] = 20;

        mesh.triangles = indices;
        #endregion
        #region normals
        // describes how light bounces off the surface (at the vertex level)
        // note that this data is interpolated across the surface of the triangle
        var norms = new Vector3[24];
        norms[0] = -Vector3.forward;
        norms[1] = -Vector3.forward;
        norms[2] = -Vector3.forward;
        norms[3] = -Vector3.forward;
        norms[4] = -Vector3.forward;
        norms[5] = -Vector3.forward;
        norms[6] = -Vector3.forward;
        norms[7] = -Vector3.forward;
        norms[8] = -Vector3.forward;
        norms[9] = -Vector3.forward;
        norms[10] = -Vector3.forward;
        norms[11] = -Vector3.forward;
        norms[12] = -Vector3.forward;
        norms[13] = -Vector3.forward;
        norms[14] = -Vector3.forward;
        norms[15] = -Vector3.forward;
        norms[16] = -Vector3.forward;
        norms[17] = -Vector3.forward;
        norms[18] = -Vector3.forward;
        norms[19] = -Vector3.forward;
        norms[20] = -Vector3.forward;
        norms[21] = -Vector3.forward;
        norms[22] = -Vector3.forward;
        norms[23] = -Vector3.forward;
        mesh.normals = norms;
        #endregion
        #region UVs/STs
        // defines how textures are mapped onto the surface
        // what vertice of the IMAGE will print on the vertices of the MESH?
        // ex: (0,0), (0,1), (1,0) prints the image as normal size, while (0,0), (0,2), (2,0) prints the image twice, tiled
        var UVs = new Vector2[24];
        UVs[0] = new Vector2(0, 0);
        UVs[1] = new Vector2(0, 1);
        UVs[2] = new Vector2(1, 1);
        UVs[3] = new Vector2(1, 0);
        UVs[4] = new Vector2(0, 0);
        UVs[5] = new Vector2(0, 1);
        UVs[6] = new Vector2(1, 1);
        UVs[7] = new Vector2(1, 0);
        UVs[8] = new Vector2(0, 0);
        UVs[9] = new Vector2(0, 1);
        UVs[10] = new Vector2(1, 1);
        UVs[11] = new Vector2(1, 0);
        UVs[12] = new Vector2(0, 0);
        UVs[13] = new Vector2(0, 1);
        UVs[14] = new Vector2(1, 1);
        UVs[15] = new Vector2(1, 0);
        UVs[16] = new Vector2(0, 0);
        UVs[17] = new Vector2(0, 1);
        UVs[18] = new Vector2(1, 1);
        UVs[19] = new Vector2(1, 0);
        UVs[20] = new Vector2(0, 0);
        UVs[21] = new Vector2(0, 1);
        UVs[22] = new Vector2(1, 1);
        UVs[23] = new Vector2(1, 0);
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
