using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {

    // public Transform respawnPoint; //uncomment this and related items to use respawn point
    private PlayerStats playerStats;

    public void Awake(){
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            //reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // other.gameObject.transform.position = respawnPoint.position;

            //update death count
            playerStats.IncreaseDeathCount();
            // Debug.Log("Death count: " + playerStats.DeathCount);
        }
    }
}