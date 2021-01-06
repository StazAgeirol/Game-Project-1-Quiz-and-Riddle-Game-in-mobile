using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMemoryGame : MonoBehaviour
{
    public static GameManagerMemoryGame gm_mg;

    public Button[] levelsButton;
    public Image[] LocksImg;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReachedMG", 1);
        for (int i = 0; i < levelsButton.Length; i++)
        {
            if (i + 1 > levelReached)
                levelsButton[i].interactable = false;
            LocksImg[i].gameObject.SetActive(false);
        }

        levelReached = PlayerPrefs.GetInt("levelReachedMG", 1);
        for (int i = 0; i < LocksImg.Length; i++)
        {
            if (i + 1 > levelReached)
                LocksImg[i].gameObject.SetActive(true);
        }
    }
}
