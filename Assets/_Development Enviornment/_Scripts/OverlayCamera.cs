using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OverlayCamera : MonoBehaviour
{
    public Camera camera;
    public Camera myOverlayCamera;

    private void Awake()
    {
        myOverlayCamera = ScreenManager.Instance.UiCamera;
    }

    // Start is called before the first frame update
    void Start()
    {
        var cameraData = camera.GetUniversalAdditionalCameraData();
        cameraData.cameraStack.Add(myOverlayCamera);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
