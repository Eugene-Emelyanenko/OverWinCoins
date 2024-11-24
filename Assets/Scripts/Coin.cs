using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Проверяем, является ли объект мячом
        {
            SoundManager.Instance.PlayCollectCoinSound();
            FindObjectOfType<GameManager>().collectedCoins++;
            Destroy(gameObject);
        }
    }
}
