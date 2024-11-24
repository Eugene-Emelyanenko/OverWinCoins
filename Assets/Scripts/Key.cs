using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyCode;

    private void Awake()
    {
        if(PlayerPrefs.GetInt(keyCode, 0) == 1)
            DestroyImmediate(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Проверяем, является ли объект мячом
        {
            SoundManager.Instance.PlayCollectKeySound();
            Destroy(gameObject);
        }
    }
}
