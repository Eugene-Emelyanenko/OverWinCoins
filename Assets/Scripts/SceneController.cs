using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if(PlayerPrefs.GetInt("Level_" + index) == 1)
            SceneManager.LoadScene(index);
        else
            Debug.Log("Cannot load Level_" + index + ". Collected keys: " + PlayerPrefs.GetInt("Keys"));
    }
}
