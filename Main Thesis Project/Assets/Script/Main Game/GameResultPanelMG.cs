using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultPanelMG : MonoBehaviour
{
    public Animator GameProgresspanel_1;
    public Animator GameProgresspanel_2;
    public Animator GameProgresspanel_3;
    public Animator GameProgresspanel_4;
    public Animator GameProgresspanel_5;
    public Animator GameProgresspanel_6;
    public Animator GameProgresspanel_7;
    public Animator GameProgresspanel_8;
    public Animator GameProgresspanel_9;
    public Text TextScore_1;
    public Text TextScore_2;
    public Text TextScore_3;
    public Text TextScore_4;
    public Text TextScore_5;
    public Text TextScore_6;
    public Text TextScore_7;
    public Text TextScore_8;
    public Text TextScore_9;
    public Text TextTime_1;
    public Text TextTime_2;
    public Text TextTime_3;
    public Text TextTime_4;
    public Text TextTime_5;
    public Text TextTime_6;
    public Text TextTime_7;
    public Text TextTime_8;
    public Text TextTime_9;
    public Button ShowUp_1;
    public Button ShowUp_2;
    public Button ShowUp_3;
    public Button ShowUp_4;
    public Button ShowUp_5;
    public Button ShowUp_6;
    public Button ShowUp_7;
    public Button ShowUp_8;
    public Button ShowUp_9;
    public Button Closeprogress_1;
    public Button Closeprogress_2;
    public Button Closeprogress_3;
    public Button Closeprogress_4;
    public Button Closeprogress_5;
    public Button Closeprogress_6;
    public Button Closeprogress_7;
    public Button Closeprogress_8;
    public Button Closeprogress_9;

    public AudioSource Sound_Show;
    public AudioSource Sound_Close;
    public AudioClip ClipSound_Show;
    public AudioClip ClipSound_Close;

    private List<Text> list_textscore = new List<Text>();
    private List<Text> list_texttime = new List<Text>();
    private List<Button> list_button = new List<Button>();

    private GameObject playersaveSystem;


    void Start()
    {
        playersaveSystem = GameObject.Find("PlayerSaveSystem");

        list_textscore.Add(TextScore_1);
        list_textscore.Add(TextScore_2);
        list_textscore.Add(TextScore_3);
        list_textscore.Add(TextScore_4);
        list_textscore.Add(TextScore_5);
        list_textscore.Add(TextScore_6);
        list_textscore.Add(TextScore_7);
        list_textscore.Add(TextScore_8);
        list_textscore.Add(TextScore_9);
        foreach (Text item in list_textscore)
        {
            item.text = "0";
        }

        list_texttime.Add(TextTime_1);
        list_texttime.Add(TextTime_2);
        list_texttime.Add(TextTime_3);
        list_texttime.Add(TextTime_4);
        list_texttime.Add(TextTime_5);
        list_texttime.Add(TextTime_6);
        list_texttime.Add(TextTime_7);
        list_texttime.Add(TextTime_8);
        list_texttime.Add(TextTime_9);

        foreach (Text item in list_texttime)
        {
            item.text = "h:m:s";
        }

        list_button.Add(ShowUp_1);
        list_button.Add(ShowUp_2);
        list_button.Add(ShowUp_3);
        list_button.Add(ShowUp_4);
        list_button.Add(ShowUp_4);
        list_button.Add(ShowUp_5);
        list_button.Add(ShowUp_6);
        list_button.Add(ShowUp_7);
        list_button.Add(ShowUp_8);
        list_button.Add(ShowUp_9);
        ShowUp_1.onClick.AddListener(() => ShowUp_Progress_1());
        ShowUp_2.onClick.AddListener(() => ShowUp_Progress_2());
        ShowUp_3.onClick.AddListener(() => ShowUp_Progress_3());
        ShowUp_4.onClick.AddListener(() => ShowUp_Progress_4());
        ShowUp_5.onClick.AddListener(() => ShowUp_Progress_5());
        ShowUp_6.onClick.AddListener(() => ShowUp_Progress_6());
        ShowUp_7.onClick.AddListener(() => ShowUp_Progress_7());
        ShowUp_8.onClick.AddListener(() => ShowUp_Progress_8());
        ShowUp_9.onClick.AddListener(() => ShowUp_Progress_9());
        Closeprogress_1.onClick.AddListener(() => CLoseProgress_1());
        Closeprogress_2.onClick.AddListener(() => CLoseProgress_2());
        Closeprogress_3.onClick.AddListener(() => CLoseProgress_3());
        Closeprogress_4.onClick.AddListener(() => CLoseProgress_4());
        Closeprogress_5.onClick.AddListener(() => CLoseProgress_5());
        Closeprogress_6.onClick.AddListener(() => CLoseProgress_6());
        Closeprogress_7.onClick.AddListener(() => CLoseProgress_7());
        Closeprogress_8.onClick.AddListener(() => CLoseProgress_8());
        Closeprogress_9.onClick.AddListener(() => CLoseProgress_9());


        Sound_Close.clip = ClipSound_Close;
        Sound_Show.clip = ClipSound_Show;
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().MusicBackground_bool == true)
        {
            Sound_Show.GetComponent<AudioSource>().gameObject.SetActive(true);
            Sound_Close.GetComponent<AudioSource>().gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().MusicBackground_bool == false)
        {
            Sound_Show.GetComponent<AudioSource>().gameObject.SetActive(false);
            Sound_Close.GetComponent<AudioSource>().gameObject.SetActive(false);
        }
        TextScore_1.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameScore_1;
        TextScore_2.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameScore_2;
        TextScore_3.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameScore_3;
        TextScore_4.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameScore_4;
        TextScore_5.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameScore_5;
        TextScore_6.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameScore_6;
        TextScore_7.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameScore_7;
        TextScore_8.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameScore_8;
        TextScore_9.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameScore_9;

        TextTime_1.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameTime_1;
        TextTime_2.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameTime_2;
        TextTime_3.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameTime_3;
        TextTime_4.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameTime_4;
        TextTime_5.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameTime_5;
        TextTime_6.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameTime_6;
        TextTime_7.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameTime_7;
        TextTime_8.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameTime_8;
        TextTime_9.text = playersaveSystem.GetComponent<PlayerSaveSystem>().MemorygameTime_9;

    }
    void Update()
    {
        playersaveSystem = GameObject.Find("PlayerSaveSystem");
    }

    public void ShowUp_Progress_1()
    {
        GameProgresspanel_1.SetBool("upanddown", true);
        Sound_Show.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void ShowUp_Progress_2()
    {
        GameProgresspanel_2.SetBool("upanddown", true);
        Sound_Show.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void ShowUp_Progress_3()
    {
        GameProgresspanel_3.SetBool("upanddown", true);
        Sound_Show.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void ShowUp_Progress_4()
    {
        GameProgresspanel_4.SetBool("upanddown", true);
        Sound_Show.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void ShowUp_Progress_5()
    {
        GameProgresspanel_5.SetBool("upanddown", true);
        Sound_Show.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void ShowUp_Progress_6()
    {
        GameProgresspanel_6.SetBool("upanddown", true);
        Sound_Show.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void ShowUp_Progress_7()
    {
        GameProgresspanel_7.SetBool("upanddown", true);
        Sound_Show.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void ShowUp_Progress_8()
    {
        GameProgresspanel_8.SetBool("upanddown", true);
        Sound_Show.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void ShowUp_Progress_9()
    {
        GameProgresspanel_9.SetBool("upanddown", true);
        Sound_Show.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void CLoseProgress_1()
    {
        GameProgresspanel_1.SetBool("upanddown", false);
        Sound_Close.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void CLoseProgress_2()
    {
        GameProgresspanel_2.SetBool("upanddown", false);
        Sound_Close.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void CLoseProgress_3()
    {
        GameProgresspanel_3.SetBool("upanddown", false);
        Sound_Close.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void CLoseProgress_4()
    {
        GameProgresspanel_4.SetBool("upanddown", false);
        Sound_Close.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void CLoseProgress_5()
    {
        GameProgresspanel_5.SetBool("upanddown", false);
        Sound_Close.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void CLoseProgress_6()
    {
        GameProgresspanel_6.SetBool("upanddown", false);
        Sound_Close.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void CLoseProgress_7()
    {
        GameProgresspanel_7.SetBool("upanddown", false);
        Sound_Close.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void CLoseProgress_8()
    {
        GameProgresspanel_8.SetBool("upanddown", false);
        Sound_Close.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void CLoseProgress_9()
    {
        GameProgresspanel_9.SetBool("upanddown", false);
        Sound_Close.Play();
        foreach (Button item in list_button)
        {
            item.gameObject.SetActive(true);
        }
    }

}
