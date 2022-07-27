using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureEffectRenderer : MonoBehaviour
{
    [SerializeField] Material effectMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial);
        Debug.Log("erfsdfsdfa");
    }


}
