using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public Button[] levelButtons; // Массив кнопок уровней
    private int[] levelsUnlocked; // Массив для хранения информации об открытых уровнях

    private void Start()
    {
        // Инициализируем массив для хранения информации об открытых уровнях
        levelsUnlocked = new int[levelButtons.Length];
        
        PlayerPrefs.SetInt("Level_1", 1);

        // Загружаем информацию об открытых уровнях из сохранений или устанавливаем значения по умолчанию
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // Здесь можно использовать PlayerPrefs или другой механизм сохранения
            // В данном примере предполагается, что уровни открыты по умолчанию
            levelsUnlocked[i] = PlayerPrefs.GetInt("Level_" + (i + 1), 0);

            if (levelsUnlocked[i] == 1)
            {
                levelButtons[i].interactable = true;
                levelButtons[i].transform.Find("Text").gameObject.SetActive(true);
                levelButtons[i].transform.Find("Lock").gameObject.SetActive(false);
            }
            else
            {
                levelButtons[i].interactable = false;
                levelButtons[i].transform.Find("Text").gameObject.SetActive(false);
                levelButtons[i].transform.Find("Lock").gameObject.SetActive(true);
            }
        }
    }
}
