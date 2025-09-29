using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(PixelPerfectCamera))]
public class CameraZoom : MonoBehaviour
{
    private float target;
    private float current = 1f;
    private float nomalizer = 50f;
    private float velocity;
    private float smoothTime = .1f;

    private PixelPerfectCamera pixelPerfectCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        target = 1f;
        if (Input.GetKey(KeyCode.Space))
        {
            target = 4f;
        }
        current = Mathf.SmoothDamp(
            current,
            target,
            ref velocity,
            smoothTime
        );
        // pixelPerfectCamera.refResolutionX = (int)Math.Floor(640 / current);
        // pixelPerfectCamera.refResolutionY = (int)Math.Floor(360 / current);
        pixelPerfectCamera.assetsPPU = (int) Math.Floor(current * nomalizer);
    }
}
