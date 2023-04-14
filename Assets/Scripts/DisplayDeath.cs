using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayDeath : MonoBehaviour
{
    public TextMeshProUGUI deathText;
    private PlayerStats playerStats;
    private int deaths = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        deaths = playerStats.DeathCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (deaths == 1) deathText.text = "you died " + deaths.ToString() + " time";
        else deathText.text = "you died " + deaths.ToString() + " times";
    }
}
