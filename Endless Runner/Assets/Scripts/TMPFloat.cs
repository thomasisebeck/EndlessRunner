using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMPFloat : MonoBehaviour
{
    [SerializeField]
    private float floatingHeight = 0.5f; // Height of the floating motion
    [SerializeField]
    private float floatingSpeed = 1.0f; // Speed of the floating motion

    private Vector3 originalPosition;
    private float time = 0.0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Increment the time variable
        time += Time.deltaTime * floatingSpeed;

        // Calculate the vertical offset using a sine wave
        float yOffset = Mathf.Sin(time) * floatingHeight;

        // Set the new position with the vertical offset
        transform.position = originalPosition + new Vector3(0.0f, yOffset, 0.0f);
    }
}
