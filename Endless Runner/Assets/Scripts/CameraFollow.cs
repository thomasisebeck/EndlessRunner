using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    [SerializeField]
    private float followSpeed;

    [SerializeField]
    private float YBias;

    private Vector3 offset;

    [SerializeField]
    private float YAdjustment;

    [SerializeField]
    private float YFollowSpeedMultiplier;

    [SerializeField]
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        if (!playerController.isDead)
        {
            // Calculate the desired camera position based on the player's position and the offset
            Vector3 targetPosition = playerTransform.position + offset;

            targetPosition.y += YAdjustment;

            // Smoothly move the camera towards the target position using Lerp
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, targetPosition.y * YBias * YFollowSpeedMultiplier, targetPosition.z), followSpeed * Time.deltaTime);
        }
    }


}
