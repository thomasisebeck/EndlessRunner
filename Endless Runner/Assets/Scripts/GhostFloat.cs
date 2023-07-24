using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFloat : MonoBehaviour
{

    [SerializeField]
    private float floatHeight;       // The maximum height the object will float above its initial position.
    [SerializeField]
    private float floatSpeed;        // The speed at which the object will float up and down.

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new height using a sine wave for a smooth floating effect.
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Set the new position of the GameObject.
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
