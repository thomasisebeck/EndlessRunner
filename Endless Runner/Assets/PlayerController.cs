using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
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

    [SerializeField]
    private Animator animator;


    private bool reachedApexOfJump; 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        reachedApexOfJump = false;
    }


    void jump()
    {
        animator.SetBool("hasFallen", false);
        animator.SetBool("isRising", true);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + jumpBoost);
        rb.AddForce(Vector3.up * jumpForce * upwardsMultiplier, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void FixedUpdate()
    {
        if (!isGrounded && rb.velocity.y <= 0.0f && !reachedApexOfJump)
        {
            reachedApexOfJump = true;
            Debug.Log("reached top!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            reachedApexOfJump = false; // Reset the flag when the player touches the ground.
            Debug.Log("grounded");
            animator.SetBool("isRising", false);
        }
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

        if (gameObject.transform.position.y <= -0.2)
        {
            animator.SetBool("hasFallen", true);
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    }
}

/*

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
    private float snapDownThreshold;
    [SerializeField]
    private float jumpSnapUp;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void jump()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + jumpSnapUp);
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


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}

*/