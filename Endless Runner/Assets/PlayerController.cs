using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float groundDistance;

    private bool isGrounded = true;

    Rigidbody2D rb;

    public Transform groundCheck;

    public LayerMask groundMask;

    [SerializeField]
    private float upwardsMultiplier;
    [SerializeField]
    private float gravityScale;
    [SerializeField]
    private float snapDownThreshold;
    [SerializeField]
    private float snapDownForce;
    [SerializeField]
    private float jumpBoost;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void jump()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + jumpBoost);
        rb.AddForce(Vector3.up * jumpForce * upwardsMultiplier, ForceMode2D.Impulse);
        isGrounded = false;
    }

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < -0.8)
        {
            jump();
        }

        if (gameObject.transform.position.y < 0.5)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -1f, gameObject.transform.position.z);
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}

