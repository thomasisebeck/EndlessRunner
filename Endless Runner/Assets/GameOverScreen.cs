using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI points;
    public void setUp(int score)
    {
        gameObject.SetActive(true);
        points.text = score.ToString() + " Points";
    }
}
