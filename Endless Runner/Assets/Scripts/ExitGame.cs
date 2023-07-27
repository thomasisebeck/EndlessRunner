using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Call this method when the Exit button is clicked (add it as an onClick event in the Inspector)
    public void ExitOnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exit Play mode in Unity Editor
#else
        Application.Quit(); // Exit application in standalone build
#endif
    }
}
