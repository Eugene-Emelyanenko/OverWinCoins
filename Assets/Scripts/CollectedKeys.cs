using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectedKeys : MonoBehaviour
{
    public static int Level5Keys { get; private set; }
    public static int Level10Keys { get; private set; }
    public static int Level15Keys { get; private set; }
    public static int Level20Keys { get; private set; }
    
    [SerializeField] private TextMeshProUGUI keysText;

    private int collectedKeys;
    private int needKeys;

    private void Awake()
    {
        Level5Keys = 3;
        Level10Keys = 6;
        Level15Keys = 9;
        Level20Keys = 12;
        
        collectedKeys = PlayerPrefs.GetInt("Keys", 0);
        Debug.Log("Collected keys: " + collectedKeys);
        
        if(collectedKeys >= Level5Keys)
            PlayerPrefs.SetInt("Level_5", 1);
        if(collectedKeys >= Level10Keys)
            PlayerPrefs.SetInt("Level_10", 1);
        if(collectedKeys >= Level15Keys)
            PlayerPrefs.SetInt("Level_15", 1);
        if(collectedKeys >= Level20Keys)
            PlayerPrefs.SetInt("Level_20", 1);
    }

    void Start()
    {
        needKeys = Level5Keys;
        if (PlayerPrefs.GetInt("Level_5") == 1)
            needKeys = Level10Keys;
        if (PlayerPrefs.GetInt("Level_10") == 1)
            needKeys = Level15Keys;
        if (PlayerPrefs.GetInt("Level_15") == 1)
            needKeys = Level20Keys;
        
        keysText.text = $"{collectedKeys}/{needKeys}";
    }
}
