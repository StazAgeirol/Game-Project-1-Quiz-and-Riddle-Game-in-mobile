using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public AudioMixer audiomixer;
    public ParticleSystem particle_Background, Particle_PLaybt, Particle_Icon, Particle_settingbt;
    public Animator CloseApp; 
    public Animator  AchieveBt_Animator, SettingBt_Animator, SettingPanel_Animator, AchievementPanel_Animator, Credits_panel_animator, FAQ_panel_animator;
    private bool Newplayer = true, ParticleSystem_bool = true;
    public bool alwaysTrue = true;
    public Button DropDownbt1, DropDownbt2, SettingButton, AchievementButton;// PlayGamebt;
    public static GameManager1 gm1;
    private List<ParticleSystem> particleSystems = new List<ParticleSystem>();
    public GameObject EffectOn, EffectOff, MusicToggleOn, MusicToggleOff, SlideVolume;
    private GameObject settingmanagerPrefab;
    private GameObject musicAudio;
    
    void Start()
    {
        MusicToggleOn.gameObject.SetActive(false);
        MusicToggleOff.gameObject.SetActive(false);
        EffectOn.gameObject.SetActive(false);
        EffectOff.gameObject.SetActive(false);
       
        particleSystems.Add(particle_Background);
        particleSystems.Add(Particle_Icon);
        particleSystems.Add(Particle_PLaybt);
        particleSystems.Add(Particle_settingbt);
       
        foreach (ParticleSystem item in particleSystems)
        {
            item.Stop(true);
        }
        DropDownbt1.gameObject.SetActive(true);
        DropDownbt2.gameObject.SetActive(false);
        settingmanagerPrefab = GameObject.Find("PlayerSaveSystem");
        musicAudio = GameObject.Find("AudioSource");
        SlideVolume.GetComponent<Slider>().value = settingmanagerPrefab.GetComponent<PlayerSaveSystem>().volume;


        if (settingmanagerPrefab.GetComponent<PlayerSaveSystem>().PArticle_bool == false)
        {
            foreach (ParticleSystem item in particleSystems)
            {
                item.Stop(true);
            }
        }

        if (settingmanagerPrefab.GetComponent<PlayerSaveSystem>().PArticle_bool == true)
        {
            foreach (ParticleSystem item in particleSystems)
            {
                item.Play(true);
            }
        }
        if (settingmanagerPrefab.GetComponent<PlayerSaveSystem>().MusicBackground_bool == true)
        {
            musicAudio.GetComponent<AudioSource>().Play();
        }
        if (settingmanagerPrefab.GetComponent<PlayerSaveSystem>().MusicBackground_bool == false)
        {
            musicAudio.GetComponent<AudioSource>().Stop();
        }
        
        if (settingmanagerPrefab.GetComponent<PlayerSaveSystem>().PArticle_bool == true)
        {
            EffectOn.gameObject.SetActive(true);
            EffectOff.gameObject.SetActive(false);
        }

         if (settingmanagerPrefab.GetComponent<PlayerSaveSystem>().PArticle_bool == false)
        {
            EffectOff.gameObject.SetActive(true);
            EffectOn.gameObject.SetActive(false);
        }

        if (settingmanagerPrefab.GetComponent<PlayerSaveSystem>().MusicBackground_bool == false)
        {
            MusicToggleOff.gameObject.SetActive(true);
            MusicToggleOn.gameObject.SetActive(false);
        }
        if (settingmanagerPrefab.GetComponent<PlayerSaveSystem>().MusicBackground_bool == true)
        {
            MusicToggleOff.gameObject.SetActive(false);
            MusicToggleOn.gameObject.SetActive(true);
        }
       
       

    }
    void Update()
    {
        settingmanagerPrefab = GameObject.Find("PlayerSaveSystem");
        musicAudio = GameObject.Find("AudioSource");

        if (Input.GetKey(KeyCode.Escape))
        {
            CloseApp.SetBool("CloseApplication", true);

        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            CloseApp.SetBool("CloseApplication", true);

        }

    }
    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
        settingmanagerPrefab.GetComponent<PlayerSaveSystem>().volume = volume;
    }

    public void EffectONClickbt()
    {
        ParticleSystem_bool = false;
        settingmanagerPrefab.GetComponent<PlayerSaveSystem>().PArticle_bool = true;
        foreach (ParticleSystem item in particleSystems)
        {
            item.Play(true);
        }
    }
    public void EffectOffClickbt()
    {
        ParticleSystem_bool = true;
        settingmanagerPrefab.GetComponent<PlayerSaveSystem>().PArticle_bool = false;
        foreach (ParticleSystem item in particleSystems)
        {
            item.Stop(true);
        }
    }

    public void MusicOnClickbt()
    {
        settingmanagerPrefab.GetComponent<PlayerSaveSystem>().MusicBackground_bool = false;
        musicAudio.GetComponent<AudioSource>().Stop();
    }
    public void MusicOffClickbt()
    {
        settingmanagerPrefab.GetComponent<PlayerSaveSystem>().MusicBackground_bool = true;
        musicAudio.GetComponent<AudioSource>().Play();
    }

    public void CancelCloseApp()
    {
        CloseApp.SetBool("CloseApplication", false);
    }

    public void PlayGame(int Catergory)
    {
        SceneManager.LoadScene(Catergory);
       
        settingmanagerPrefab.GetComponent<PlayerSaveSystem>().SaveGame();
        if (settingmanagerPrefab.GetComponent<PlayerSaveSystem>().Tutiroal_BoolMainScene == true)
        {
            settingmanagerPrefab.GetComponent<PlayerSaveSystem>().Tutiroal_BoolMainScene = false;
        }
        
    }

    public void OpenSetting()
    {
        SettingPanel_Animator.Play("SettingPanel_Open");
       
    }

    public void CloseSetting()
    {
        SettingPanel_Animator.Play("SettingPanel_Close");
        settingmanagerPrefab.GetComponent<PlayerSaveSystem>().SaveGame();
    }
    public void OpenAchievement()
    {
        AchievementPanel_Animator.Play("Achievement_panel_Open");
       
    }

    public void CloseAchievement()
    {
        AchievementPanel_Animator.Play("Achievement_panel_Close");
    }

    public void DropDownMenu()
    {
        AchieveBt_Animator.SetBool("DropDownPress", true);
        SettingBt_Animator.SetBool("DropDownPress", true);
        DropDownbt1.gameObject.SetActive(false);
        DropDownbt2.gameObject.SetActive(true);
        GameObject gameObject = GameObject.Find("pointer_ClickMenubt");
        Destroy(gameObject);
    }
    public void DropDownMenu2()
    {
        AchieveBt_Animator.SetBool("DropDownPress", false);
        SettingBt_Animator.SetBool("DropDownPress", false);
        DropDownbt1.gameObject.SetActive(true);
        DropDownbt2.gameObject.SetActive(false);
    }


    public void CloseApplication()
    {
        Application.Quit();
        Debug.Log("Application is now Close");
    }

    public void PlayCreditsAnimatorShow()
    {
        Credits_panel_animator.SetBool("UpandDown", true);
    }
    public void PlayCreditsAnimatorClose()
    {
        Credits_panel_animator.SetBool("UpandDown", false);
    }

    public void PlayFAQAnimatorShow()
    {
        FAQ_panel_animator.SetBool("UpandDown", true);
    }
    public void PlayFAQAnimatorClose()
    {
        FAQ_panel_animator.SetBool("UpandDown", false);
    }
    
}
