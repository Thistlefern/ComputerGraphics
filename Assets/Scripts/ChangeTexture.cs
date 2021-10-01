using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Texture m_MainTexture, m_Normal, m_Height, m_Metal;

    private void Start()
    {
        meshRenderer.material.SetTexture("_MainTex", m_MainTexture);
        meshRenderer.material.SetTexture("_BumpMap", m_Normal);
        meshRenderer.material.SetTexture("_ParallaxMap", m_Height);
        meshRenderer.material.SetTexture("_MetallicGlossMap", m_Metal);
    }
}
