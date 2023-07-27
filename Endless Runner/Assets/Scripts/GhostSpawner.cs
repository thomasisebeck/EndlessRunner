using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject ghost;

    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float spawnOffsetRight;

    [SerializeField]
    private float spawnOffsetTop;

    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0)
        {
            Vector3 spawnPosition = player.transform.position + Vector3.right * spawnOffsetRight;
            spawnPosition.y = 0;
            spawnPosition += Vector3.up * spawnOffsetTop; 
            spawnTime = spawnRate;
            Instantiate(ghost, spawnPosition, Quaternion.identity);
        }
    }
}
