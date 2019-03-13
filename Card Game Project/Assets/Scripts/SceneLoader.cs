using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void loadScene(string sceneName)
    {
        Debug.Log("Loading new scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

}
