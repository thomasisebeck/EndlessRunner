using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    [SerializeField]
    private float parallaxSpeed = 0.5f; // Adjust this value to control the parallax speed

    private Transform mainCameraTransform;
    private Vector3 lastCameraPosition;

    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        lastCameraPosition = mainCameraTransform.position;
    }

    void Update()
    {
        // Calculate the parallax movement based on camera movement
        Vector3 deltaMovement = mainCameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxSpeed;

        // Update lastCameraPosition for the next frame
        lastCameraPosition = mainCameraTransform.position;
    }

}
