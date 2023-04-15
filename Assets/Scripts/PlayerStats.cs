using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    private static int deathCount = 0;
    // public TextMeshProUGUI deathText;

    public int DeathCount
    {
        get { return deathCount; }
        set { deathCount = value; }
    }

    public void IncreaseDeathCount(){
        deathCount++;
    }

    void Update()
    {
        // deathText.text = "Deaths: " + deathCount.ToString();
    }
}
