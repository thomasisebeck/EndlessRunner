using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    [SerializeField]
    private TextMeshProUGUI waveNumberText;

    private float spawnTime;
    private int enemiesSpawnedInWave;

    [SerializeField]
    private float showWaveMessageFor;
    private float waveMessageTimeLeft;

    [SerializeField]
    private int[] waves;

    private int waveNumber;

    [SerializeField]
    private float waitForTime;

    private float waitFor; 

    

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = spawnRate;
        
        waveMessageTimeLeft = showWaveMessageFor;
        waveNumberText.text = "Wave 1";
        enemiesSpawnedInWave = 0;
        waitFor = 0; 
    }

    // Update is called once per frame
    void Update()
    {

        if (waitFor > 0)
        {
            waitFor -= Time.deltaTime;
        }
        else if (waveMessageTimeLeft > 0)
        {
            waveMessageTimeLeft -= Time.deltaTime;
            waveNumberText.gameObject.SetActive(true);
        }

        if (waveMessageTimeLeft < 0)
        {
            waveNumberText.gameObject.SetActive(false);
        }

        if (waveMessageTimeLeft < 2)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime < 0)
            {
                Vector3 spawnPosition = player.transform.position + Vector3.right * spawnOffsetRight;
                spawnPosition.y = 0;
                spawnTime = spawnRate;

                int result = Random.Range(0, 2);

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

                enemiesSpawnedInWave++;
                if (enemiesSpawnedInWave == waves[waveNumber])
                {
                    waitFor = waitForTime;
                }
            }

            if (enemiesSpawnedInWave >= waves[waveNumber])
            {
                enemiesSpawnedInWave = 0;
                waveNumber++;
                waveMessageTimeLeft = showWaveMessageFor;

                waitFor = waitForTime;

                if (waveNumber < waves.Length)
                {
                    waveNumberText.text = "Wave " + (waveNumber + 1); waveNumberText.text = "Wave " + (waveNumber + 1);
                }
                else
                {
                    Debug.Log("Activate infinite mode!");
                }
                
            }
        }
    }
}
