using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PauseOn()
    {
        BallController.canInput = false;
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        BallController.canInput = true;
        Time.timeScale = 1;
    }
}
