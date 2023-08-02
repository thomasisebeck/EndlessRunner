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

    private float timer;

    [SerializeField]
    private float timeUntilDeath;

    [SerializeField]
    private bool isLowGhost;

    private GameObject player;

    //to check for offscreen
    private Renderer objectRenderer;
    private Camera mainCamera;
    private bool givePoints;

    private PointsManagement pointsManager;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        timer = 0;

        objectRenderer = GetComponent<Renderer>();
        mainCamera = Camera.main;

        givePoints = true;

        player = GameObject.FindGameObjectWithTag("Player");

        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new height using a sine wave for a smooth floating effect.
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Set the new position of the GameObject.
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        timer += Time.deltaTime;

        //check to give player points
        Transform playerPosition = player.transform;

        if (gameObject.transform.position.x < playerPosition.transform.position.x && givePoints)
        {
            givePoints = false;

            if (pointsManager != null)
            {
                pointsManager.increment();
            }
            else
            {
                Debug.Log("Points manager is null!!!");
            }
            
        }
        

        if (timer > timeUntilDeath && IsOffscreen())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOffscreen()
    {
        // Get the object's position in viewport space
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        // Check if any of the coordinates are outside the viewport (range 0 to 1)
        return (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1 || viewportPos.z < 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController.GetComponent<PlayerController>().getIsRolling() == false) //not rolling
                playerController.die();

            if (isLowGhost)
                playerController.die();
        }
    }
}
