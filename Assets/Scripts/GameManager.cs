using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private GameObject ballPrefab;
    
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Image[] coins;

    [SerializeField] private GameObject losePanel;

    public int collectedCoins = 0;
    private string keyCode = string.Empty;
    void Start()
    {
        Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
        
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        Key key = FindObjectOfType<Key>();
        if (key != null)
        {
            Debug.Log("Key founded. Key code: " + key.keyCode);
            keyCode = key.keyCode;
        }
    }

    public void Win()
    {
        winPanel.SetActive(true);

        BallController.canInput = false;

        for (int i = 0; i < collectedCoins; i++)
        {
            coins[i].color = Color.white;
        }

        if (keyCode != string.Empty)
        {
            if (!FindObjectOfType<Key>())
            {
                PlayerPrefs.SetInt(keyCode, 1);
                int keys = PlayerPrefs.GetInt("Keys", 0);
                keys++;
                PlayerPrefs.SetInt("Keys", keys);
                PlayerPrefs.Save();
            
                Debug.Log("Key collected. Collected keys: " + keys);
            }
        }
        
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        int requiredKeys = 0;
        string levelName = "Level_" + index;

        switch (index)
        {
            case 5:
                requiredKeys = CollectedKeys.Level5Keys;
                break;
            case 10:
                requiredKeys = CollectedKeys.Level10Keys;
                break;
            case 15:
                requiredKeys = CollectedKeys.Level15Keys;
                break;
            case 20:
                requiredKeys = CollectedKeys.Level20Keys;
                break;
            default:
                PlayerPrefs.SetInt(levelName, 1);
                Debug.Log($"Unlock {levelName}");
                return;
        }

        int collectedKeys = PlayerPrefs.GetInt("Keys");

        if (collectedKeys >= requiredKeys)
        {
            PlayerPrefs.SetInt(levelName, 1);
            Debug.Log($"Unlock {levelName}");
        }
        else
        {
            Debug.Log($"Cannot unlock {levelName}");
            Debug.Log($"Collected keys: {collectedKeys}. Needed keys: {requiredKeys}");
        }
        
        if(collectedKeys >= CollectedKeys.Level5Keys)
            PlayerPrefs.SetInt("Level_5", 1);
        if(collectedKeys >= CollectedKeys.Level10Keys)
            PlayerPrefs.SetInt("Level_10", 1);
        if(collectedKeys >= CollectedKeys.Level15Keys)
            PlayerPrefs.SetInt("Level_15", 1);
        if(collectedKeys >= CollectedKeys.Level20Keys)
            PlayerPrefs.SetInt("Level_20", 1);
    }

    public void Lose()
    {
        BallController.canInput = false;
        
        losePanel.SetActive(true);
    }
}
