using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDestroyOnLoadScropt : MonoBehaviour
{
    private static DonDestroyOnLoadScropt instance;

    void Awake()
    {
        if (instance!= null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
