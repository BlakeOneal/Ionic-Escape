using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public string sceneName;
    private bool isOn;
    private Canvas canvas;

    public void ToggleMessage(bool toggleState)
    {
        isOn = toggleState;

        if (isOn)
        {
            CanvasState.isCanvasVisible = true;
        }
        else
        {
            CanvasState.isCanvasVisible = false;
        }
    }
}