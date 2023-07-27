using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject ghostFloat;

    [SerializeField]
    private GameObject ghostGround;

    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float spawnOffsetRight;

    [SerializeField]
    private float spawnOffsetTopFloat;

    [SerializeField]
    private float spawnOffsetTopGround;

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
            spawnTime = spawnRate;

            int result = Random.Range(0, 2
                );

            if (result == 0)
            {
                spawnPosition += Vector3.up * spawnOffsetTopFloat;
                Instantiate(ghostFloat, spawnPosition, Quaternion.identity);
            }
            else
            {
                spawnPosition += Vector3.up * spawnOffsetTopGround;
                Instantiate(ghostGround, spawnPosition, Quaternion.identity);
            }
        }
    }
}
