//***NOTE***
//SCRIPT WAS NEVER TESTED BECAUSE AUDIO WAS NOT IMPLEMENTED
//UNCOMMENT ALL CODE TO TEST

// using UnityEngine;
// using UnityEngine.UI;

// public class VolumeControl : MonoBehaviour
// {
//     public Slider volumeSlider;

//     private void Awake()
//     {
//         float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
//         AudioListener.volume = savedVolume;
//         volumeSlider.value = savedVolume;
//     }

//     public void OnVolumeChanged()
//     {
//         float newVolume = volumeSlider.value;
//         AudioListener.volume = newVolume;

//         PlayerPrefs.SetFloat("MasterVolume", newVolume);
//         PlayerPrefs.Save();
//     }
// }