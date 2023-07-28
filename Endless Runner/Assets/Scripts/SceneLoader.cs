using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;
    public void loadScene()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }
}
