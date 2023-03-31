using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Quit : MonoBehaviour
{
    public void quitGame() {
        if (EditorApplication.isPlaying){
            EditorApplication.isPlaying = false;
        }
        else {
            Application.Quit();
        }
    }
}
