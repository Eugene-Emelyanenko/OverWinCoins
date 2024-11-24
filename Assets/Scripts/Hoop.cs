using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Проверяем, является ли объект мячом
        {
            if (IsBallDroppingFromTop(other.gameObject))
            {
                BallController ballController = other.GetComponent<BallController>();
                if (ballController != null)
                {
                    SoundManager.Instance.PlayScoreSound();
                    FindObjectOfType<GameManager>().Win();
                    ballController.ResetBall();
                }
            }
        }
    }
    
    private bool IsBallDroppingFromTop(GameObject ball)
    {
        Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();

        // Проверяем, находится ли мяч над корзиной
        if (ball.transform.position.y > transform.position.y)
        {
            // Проверяем, движется ли мяч вниз
            if (ballRigidbody.velocity.y < 0)
            {
                return true; // Мяч движется сверху вниз
            }
        }

        return false; // Мяч не движется сверху вниз
    }
}
