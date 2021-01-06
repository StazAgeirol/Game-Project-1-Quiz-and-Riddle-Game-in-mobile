using UnityEngine;
using UnityEngine.SceneManagement;

public class Riddle_LoadScene_Script : MonoBehaviour
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
        }if (playersaveSystem.GetComponent<PlayerSaveSystem>().PArticle_bool == false)
        {
            Effect_background.Stop();
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().MusicBackground_bool == true)
        {
            SourceSound_Loadleve.GetComponent<AudioSource>().enabled = true;

        }if (playersaveSystem.GetComponent<PlayerSaveSystem>().MusicBackground_bool == false)
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


    public void LoadScene01 (int level1)
    {
        SceneManager.LoadScene(level1);
        SourceSound_Loadleve.Play();
    }
    public void LoadScene02(int level2)
    {
        SceneManager.LoadScene(level2);
        SourceSound_Loadleve.Play();
    }
    public void LoadScene03(int level3)
    {
        SceneManager.LoadScene(level3);
        SourceSound_Loadleve.Play();
    }
    public void LoadScene04(int level4)
    {
        SceneManager.LoadScene(level4);
        SourceSound_Loadleve.Play();
    }
    public void LoadScene05(int level5)
    {
        SceneManager.LoadScene(level5);
        SourceSound_Loadleve.Play();
    }
    public void LoadScene06(int level6)
    {
        SceneManager.LoadScene(level6);
        SourceSound_Loadleve.Play();
    }
    public void LoadScene07(int level7)
    {
        SceneManager.LoadScene(level7);
        SourceSound_Loadleve.Play();
    }
    public void LoadScene08(int level8)
    {
        SceneManager.LoadScene(level8);
        SourceSound_Loadleve.Play();
    }
    public void LoadScene09(int level9)
    {
        SceneManager.LoadScene(level9);
        SourceSound_Loadleve.Play();
    }
}
