using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollBar;
    [SerializeField] private Image[] pageIndicators;

    [SerializeField] private Color currentPageColor;
    [SerializeField] private Color otherPageColor;
    
    private float scroll_pos = 0;
    private float[] pos;
    private float distance = 0f;

    private void Start()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);
    }

    private void Update()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollBar.value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2f) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollBar.value = Mathf.Lerp(scrollBar.value, pos[i], 0.1f);
                }
            }
        }
        
        UpdatePageIndicator();
    }
    
    private void UpdatePageIndicator()
    {
        int currentPage = Mathf.RoundToInt(scrollBar.value * (pos.Length - 1));
        
        for (int i = 0; i < pageIndicators.Length; i++)
            pageIndicators[i].color = i == currentPage ? pageIndicators[i].color = currentPageColor : otherPageColor;
    }
}
