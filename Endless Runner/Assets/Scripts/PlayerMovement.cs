using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    public float moveSpeed;

    private Animator animator;

    const float LOWER = 5f;

    public PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.isDead)
            return;

        // Calculate the new position based on the current position and the speed
        float newPosition = transform.position.x + (moveSpeed * Time.deltaTime);

        // Create a new position vector with only the x-axis changed
        Vector3 newPositionVector = new Vector3(newPosition, transform.position.y, transform.position.z);

        // Apply the new position to the GameObject
        transform.position = newPositionVector;

        if (Input.GetKey(KeyCode.S)) //Roll
        {
            animator.SetBool("isRolling", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - LOWER, gameObject.transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isRolling", false);
        }
    }
}
