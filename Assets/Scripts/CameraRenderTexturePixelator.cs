using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRenderTexturePixelator : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private int screenDownscaleFactor = 3;

    [SerializeField] Camera renderCamera;
    [SerializeField] private RawImage outputDisplayImage; 
    
    private RenderTexture renderTexture;
    private int screenWidth;
    private int screenHeight;


    private void OnValidate()
    {
        Init();
    }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (ScreenWasResized())
        {
            Init();
        }
    }

    private bool ScreenWasResized()
    {
        return Screen.width != screenWidth || Screen.height != screenHeight;
    }



    private void Init()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        int outputDisplayWidth = screenWidth / screenDownscaleFactor;
        int outputDisplayHeight = screenHeight / screenDownscaleFactor;

        renderTexture = new RenderTexture(outputDisplayWidth, outputDisplayHeight, 24)
        {
            filterMode = FilterMode.Point,
            antiAliasing = 1,
        };

        renderCamera.targetTexture = renderTexture;

        outputDisplayImage.texture = renderTexture;
    }

}
