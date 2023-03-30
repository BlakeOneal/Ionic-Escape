using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimerReloader : MonoBehaviour
{
    public float reloadTimeInSeconds = 5f;
    private float timeLeftInSeconds;
    private PlayerStats playerStats;
    public TextMeshProUGUI timerText;

    void Start()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        timeLeftInSeconds = reloadTimeInSeconds;
        Invoke("ReloadScene", reloadTimeInSeconds);
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        playerStats.IncreaseDeathCount();
    }

    void Update()
    {
        // timerText.text = "Timer: " + deathCount.ToString();
        timeLeftInSeconds -= Time.deltaTime;
        if (timeLeftInSeconds <= 0f)
        {
            timeLeftInSeconds = 0f;
        }

        int minutes = Mathf.FloorToInt(timeLeftInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeLeftInSeconds % 60f);
        string timeLeftString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Timer: " + timeLeftString;
    }
}
