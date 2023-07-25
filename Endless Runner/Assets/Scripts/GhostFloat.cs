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

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        timer = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new height using a sine wave for a smooth floating effect.
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Set the new position of the GameObject.
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        timer += Time.deltaTime;

        if (timer > timeUntilDeath)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController.die();
    }
}
