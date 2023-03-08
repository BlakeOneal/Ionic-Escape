using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Start(){
        Debug.Log("SceneChanger script started");
    }

    public void ChangeScene(string sceneName){
        Debug.Log("Changing to scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class LoadSceneOnClick : MonoBehaviour {

//     public void LoadByIndex(int sceneIndex)
//     {
//         SceneManager.LoadScene(sceneIndex);
//     }
// }
