using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundEffect : MonoBehaviour
{
    
    public AudioSource SourceSoundEffect_Play;
    public AudioSource SourceSoundEffect_Setting;
    public AudioSource SourceSoundEffect_Trophy;
    public AudioSource SourceSoundEffect_CloseBt;
    public AudioSource SourceSoundEffect_Menu;
    public AudioSource SourceSoundEffect_Menu_2;
    public AudioSource SourceSoundEffect_ToggleButton;

    public AudioClip ClipsoundEffect_Play;
    public AudioClip ClipsoundEffect_Setting;
    public AudioClip ClipsoundEffect_Trophy;
    public AudioClip ClipsoundEffect_CloseBt;
    public AudioClip ClipsoundEffect_Menu;
    public AudioClip ClipsoundEffect_Menu_2;
    public AudioClip ClipsoundEffect_Toggle;


    private List<AudioClip> List_audioClip = new List<AudioClip>();
    private List<AudioSource> List_audioSource = new List<AudioSource>();

    private GameObject playerSaveSystem;

    private void Start()
    {
        playerSaveSystem = GameObject.Find("PlayerSaveSystem");

        List_audioClip.Add(ClipsoundEffect_CloseBt);
        List_audioClip.Add(ClipsoundEffect_Menu);
        List_audioClip.Add(ClipsoundEffect_Menu_2);
        List_audioClip.Add(ClipsoundEffect_Play);
        List_audioClip.Add(ClipsoundEffect_Setting);
        List_audioClip.Add(ClipsoundEffect_Trophy);
        List_audioClip.Add(ClipsoundEffect_Toggle);

        List_audioSource.Add(SourceSoundEffect_CloseBt);
        List_audioSource.Add(SourceSoundEffect_Menu);
        List_audioSource.Add(SourceSoundEffect_Menu_2);
        List_audioSource.Add(SourceSoundEffect_Play);
        List_audioSource.Add(SourceSoundEffect_Setting);
        List_audioSource.Add(SourceSoundEffect_Trophy);
        List_audioSource.Add(SourceSoundEffect_ToggleButton);

        foreach ( AudioSource audioSource in List_audioSource)
        {
            audioSource.GetComponent<AudioSource>().gameObject.SetActive(false);
        }

        if (playerSaveSystem.GetComponent<PlayerSaveSystem>().MusicBackground_bool == true)
        {
            foreach (AudioSource item in List_audioSource)
            {
                item.GetComponent<AudioSource>().gameObject.SetActive(true);
            }
        }

        if (playerSaveSystem.GetComponent<PlayerSaveSystem>().MusicBackground_bool == false)
        {
            foreach (AudioSource item in List_audioSource)
            {
                item.GetComponent<AudioSource>().gameObject.SetActive(false);
            }
        }
    }

    public void SettingButton()
    {
        SourceSoundEffect_Setting.clip = ClipsoundEffect_Setting;
        SourceSoundEffect_Setting.Play();
    }

    public void TrophyButton()
    {
        SourceSoundEffect_Trophy.clip = ClipsoundEffect_Trophy;
        SourceSoundEffect_Trophy.Play();
    }

    public void CloseButton()
    {
        SourceSoundEffect_CloseBt.clip = ClipsoundEffect_CloseBt;
        SourceSoundEffect_CloseBt.Play();
    }

    public void ToggleButton()
    {
        SourceSoundEffect_ToggleButton.clip = ClipsoundEffect_Toggle;
        SourceSoundEffect_ToggleButton.Play();
    }

    public void PlayButton()
    {
        SourceSoundEffect_Play.clip = ClipsoundEffect_Play;
        SourceSoundEffect_Play.Play();
    }

    public void MenuButton()
    {
        SourceSoundEffect_Menu.clip = ClipsoundEffect_Menu;
        SourceSoundEffect_Menu.Play();
    }

    public void MenuButton2()
    {
        SourceSoundEffect_Menu_2.clip = ClipsoundEffect_Menu_2;
        SourceSoundEffect_Menu_2.Play();
    }


}


