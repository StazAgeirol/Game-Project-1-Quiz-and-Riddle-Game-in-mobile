using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoryGame_LoadScene_Script : MonoBehaviour
{
    private GameObject audioSource;
    public AudioSource SourceSound_Loadleve;
    public AudioClip ClipSound_loadleve;
    public ParticleSystem Effect_background;
    private GameObject playersaveSystem;

    private void Start()
    {
        SourceSound_Loadleve.clip = ClipSound_loadleve;
        playersaveSystem = GameObject.Find("PlayerSaveSystem");

        if (playersaveSystem.GetComponent<PlayerSaveSystem>().PArticle_bool == true)
        {
            Effect_background.Play();
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().PArticle_bool == false)
        {
            Effect_background.Stop();
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().MusicBackground_bool == true)
        {
            SourceSound_Loadleve.GetComponent<AudioSource>().enabled = true;

        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().MusicBackground_bool == false)
        {
            SourceSound_Loadleve.GetComponent<AudioSource>().enabled = false;
        }
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Categories");
            audioSource = GameObject.Find("AudioSource");
            audioSource.GetComponent<AudioSource>().Play();
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Categories");
            audioSource = GameObject.Find("AudioSource");
            audioSource.GetComponent<AudioSource>().Play();
        }
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("MemoryGame1");
        SourceSound_Loadleve.Play();
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("MemoryGame2");
        SourceSound_Loadleve.Play();
    }
    public void LoadScene3()
    {
        SceneManager.LoadScene("MemoryGame3");
        SourceSound_Loadleve.Play();
    }
    public void LoadScene4()
    {
        SceneManager.LoadScene("MemoryGame4");
        SourceSound_Loadleve.Play();
    }
    public void LoadScene5()
    {
        SceneManager.LoadScene("MemoryGame5");
        SourceSound_Loadleve.Play();
    }
    public void LoadScene6()
    {
        SceneManager.LoadScene("MemoryGame6");
        SourceSound_Loadleve.Play();
    }
    public void LoadScene7()
    {
        SceneManager.LoadScene("MemoryGame7");
        SourceSound_Loadleve.Play();
    }
    public void LoadScene8()
    {
        SceneManager.LoadScene("MemoryGame8");
        SourceSound_Loadleve.Play();
    }
    public void LoadScene9()
    {
        SceneManager.LoadScene("MemoryGame9");
        SourceSound_Loadleve.Play();
    }
}
