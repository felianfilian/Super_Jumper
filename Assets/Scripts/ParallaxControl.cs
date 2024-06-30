using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControl: MonoBehaviour
{
    public Transform sky;
    public Transform treeline;

    [Range(0f, 1f)]
    public float parallaxSpeed = 0.5f;

    private Transform transCamera;

    void Start()
    {
        transCamera = Camera.main.transform;  
    }

    // Update is called once per frame
    void LateUpdate()
    {
        sky.position = new Vector3(transCamera.position.x, transCamera.position.y, sky.position.z);
        treeline.position = new Vector3(transCamera.position.x * parallaxSpeed, transCamera.position.y * parallaxSpeed, sky.position.z);
    }
}
