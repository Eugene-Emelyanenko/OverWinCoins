using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Проверяем, является ли объект мячом
        {
            BallController ballController = other.GetComponent<BallController>();
            if (ballController != null)
            {
                SoundManager.Instance.PlayFailSound();
                ballController.ResetBall();
                FindObjectOfType<GameManager>().Lose();
            }
        }
    }
}
