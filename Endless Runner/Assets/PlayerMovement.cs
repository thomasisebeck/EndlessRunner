using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position based on the current position and the speed
        float newPosition = transform.position.x + (moveSpeed * Time.deltaTime);

        // Create a new position vector with only the x-axis changed
        Vector3 newPositionVector = new Vector3(newPosition, transform.position.y, transform.position.z);

        // Apply the new position to the GameObject
        transform.position = newPositionVector;
    }
}
