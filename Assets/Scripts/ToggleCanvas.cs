using UnityEngine;
using UnityEngine.UI;

public static class CanvasState {
    public static bool isCanvasVisible = true;
}

public class ToggleCanvas : MonoBehaviour {

    public Canvas canvas;

    void Update () {
        if (CanvasState.isCanvasVisible) {
            canvas.enabled = true;
        } else {
            canvas.enabled = false;
        }
    }
}