using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerRiddle : MonoBehaviour
{
    public static GameManagerRiddle gm;

    public Button[] levelsButton;
    public Image[] LocksImg;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelsButton.Length; i++)
        {
            if (i + 1 > levelReached)
            levelsButton[i].interactable = false;
            LocksImg[i].gameObject.SetActive(false);
        }

        levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < LocksImg.Length; i++)
        {
            if (i + 1 > levelReached)
                LocksImg[i].gameObject.SetActive(true);
        }   
    }


}

