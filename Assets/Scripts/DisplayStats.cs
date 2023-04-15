using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public TextMeshProUGUI deathText;
    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        deathText.text = "Deaths: " + playerStats.DeathCount.ToString();
    }
}
