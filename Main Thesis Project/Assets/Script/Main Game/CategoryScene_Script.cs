using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CategoryScene_Script : MonoBehaviour
{
    public ParticleSystem particleSystem_BackgroundEffect_Category;
    private GameObject settingManager;
    private bool particle_bool = true;
    public AudioClip ClipAudioRiddle;
    public AudioClip ClipAudioMemory;
    public AudioSource SourceAudioRiddle;
    public AudioSource SourceAudioMemory;
    private List<AudioSource> List_audioSource = new List<AudioSource>();

    private void Start()
    {
        settingManager = GameObject.Find("PlayerSaveSystem");
        List_audioSource.Add(SourceAudioMemory);
        List_audioSource.Add(SourceAudioRiddle);

        foreach (AudioSource item in List_audioSource)
        {
            item.GetComponent<AudioSource>().gameObject.SetActive(false);
        }

        if (settingManager.GetComponent<PlayerSaveSystem>().PArticle_bool == true)
        {
            particle_bool = false;
        }
        if (settingManager.GetComponent<PlayerSaveSystem>().MusicBackground_bool == true)
        {
            foreach (AudioSource item in List_audioSource)
            {
                item.GetComponent<AudioSource>().gameObject.SetActive(true);
            }
        }
        if (settingManager.GetComponent<PlayerSaveSystem>().MusicBackground_bool == false)
        {
            foreach (AudioSource item in List_audioSource)
            {
                item.GetComponent<AudioSource>().gameObject.SetActive(false);
            }
        }

    }

    void Update()
    {
        settingManager = GameObject.Find("PlayerSaveSystem");

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            settingManager.GetComponent<PlayerSaveSystem>().Tutiroal_BoolCategoryScene = false;
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
            settingManager.GetComponent<PlayerSaveSystem>().Tutiroal_BoolCategoryScene = false;
        }
        

        if (settingManager.GetComponent<PlayerSaveSystem>().PArticle_bool == true && particle_bool == false)
        {
            particle_bool = true;
            particleSystem_BackgroundEffect_Category.Play(true);
        }
        if (settingManager.GetComponent<PlayerSaveSystem>().PArticle_bool == false && particle_bool == true)
        {
            particle_bool = false;
            particleSystem_BackgroundEffect_Category.Stop(true);
        }
       
        
    }
    public void LoadRidddleScene(int Riddle)
    {
        SceneManager.LoadScene(Riddle);
        GameObject Audiosource = GameObject.Find("AudioSource");
        Audiosource.GetComponent<AudioSource>().Stop();
        settingManager.GetComponent<PlayerSaveSystem>().Tutiroal_BoolCategoryScene = false;
        settingManager.GetComponent<PlayerSaveSystem>().SaveGame();
        SourceAudioRiddle.clip = ClipAudioRiddle;
        SourceAudioRiddle.Play();
    }

    public void LoadMemoryGameScene(int Memorygame)
    {
        GameObject Audiosource = GameObject.Find("AudioSource");
        Audiosource.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(Memorygame);
        settingManager.GetComponent<PlayerSaveSystem>().Tutiroal_BoolCategoryScene = false;
        settingManager.GetComponent<PlayerSaveSystem>().SaveGame();
        SourceAudioMemory.clip = ClipAudioMemory;
        SourceAudioMemory.Play();
    }

    
    
}
