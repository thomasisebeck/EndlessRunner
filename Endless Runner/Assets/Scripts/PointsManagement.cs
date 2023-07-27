using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class PointsManagement : MonoBehaviour
{
    private int points;

    [SerializeField]
    private TextMeshProUGUI pointsText;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    public void increment()
    {
        points++;
        pointsText.text = points.ToString() + " Points";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
