using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogueManagerMainScene : MonoBehaviour
{
    public static DialogueManagerMainScene dm;   
    private Queue<string> sentences;
    private Queue<string> sentences1;
    private Queue<string> sentences2;
    public TMP_Text dialogueText;
    public TMP_Text dialogueText1;
    public TMP_Text dialogueText2;
    string containtext = "if you already played this before just press the skip button";
    string containtext2 = "Then if not let's continue the basic guide for your by pressing the next slide button";
    string containtext3 = "if the music is too much just press the menu button";
    string containtext4 = " then press setting button";
    string containtext5 = "then slide the volume in the middle";
    string containtext6 = "press or slide";
    string containtext7 = "you can see it in menu button";
    string containtext8 = "then press the Trophy button";
    string containtext9 = "Let's get started, press Play Button ";
    string containtext10 = "demostrate later after the Guide Message.";
    public Dialogue dialogue;
    public GameObject Pointer_ClickMenubt, Pointer_ClickTrophybt, Pointer_Playbt, Pointer_Settingbt, Tutorial_for_newcommer, assuringPanel ;
    public Animator Pointer_ClickMenubt_animator, PointerClickTrophy_Animator, Pointer_ClickSettingbt_Animator, Pointer_ClickPlay_Animator,TutorialPanel_Animator, settingbt_animator, achievementbt_animator, AssuringPanel_Animator;
    private bool pointer_bool = false, pointer_bool2 = false, NewPLayer = true, DropDownMenu_bool = false, StartcoroutineTrophy = false, nextslide_bool = false, StartcoroutineCloseTrlPanel = false,
        TuttorialShow_bool = false, TuttorialShow_bool_bool2 = false, DontRunThisScript = false;
    public bool NextSlide_bool = false;
    public Image sprite1, sprite2, sprite3, sprite4, sprite5, sprite6, sprite7, sprite8, sprite9;
    public Button DisplayNextSentence, DisplayNextSentence1, DisplayNextSentence2,  skipbutton, nextslidebutton, nextslidebutton1, nextslidebutto2, DropDownMenu, 
    DropDownMenu2, Settingbt, Achievementbt, closeSettingbt, closeAchievementbt, playbt, AssuringYes, AssuringNo;
    private GameObject tutroialDataPrefab;
    List<Image> ImageContiner;
    void Start()
    {
       tutroialDataPrefab = GameObject.Find("PlayerSaveSystem");
       
    }

   void Update()
    {
        DisplayNextSentence.onClick.AddListener(() => ShowSprite());
        tutroialDataPrefab = GameObject.Find("PlayerSaveSystem");

        
        {



            if (tutroialDataPrefab.gameObject.GetComponent<PlayerSaveSystem>().Tutiroal_BoolMainScene == true)
            {
                TuttorialShow_bool = true;

            }
            else
            {
                TuttorialShow_bool = false;

            }
            if (TuttorialShow_bool == true && TuttorialShow_bool_bool2 == false)
            {
                TuttorialShow_bool_bool2 = true;
                Debug.Log("PLaying now");
                ImageContiner = new List<Image>();
                Pointer_ClickMenubt.gameObject.SetActive(false);
                Pointer_ClickTrophybt.gameObject.SetActive(false);
                ImageContiner.Add(sprite1);
                ImageContiner.Add(sprite2);
                ImageContiner.Add(sprite3);
                ImageContiner.Add(sprite4);
                ImageContiner.Add(sprite5);
                ImageContiner.Add(sprite6);
                ImageContiner.Add(sprite7);
                ImageContiner.Add(sprite8);
                ImageContiner.Add(sprite9);

                foreach (Image item in ImageContiner)
                {
                    item.gameObject.SetActive(false);
                }

                sentences = new Queue<string>();
                sentences1 = new Queue<string>();
                sentences2 = new Queue<string>();

                StartDialogue1(dialogue);
                DropDownMenu.interactable = false;
                DisplayNextSentence.gameObject.SetActive(false);
                DisplayNextSentence1.gameObject.SetActive(false);
                DisplayNextSentence2.gameObject.SetActive(false);
                skipbutton.gameObject.SetActive(false);
                nextslidebutton.gameObject.SetActive(false);
                nextslidebutton1.gameObject.SetActive(false);
                nextslidebutto2.gameObject.SetActive(false);
                TutorialPanel_Animator.SetBool("isBool", true);
                Settingbt.gameObject.SetActive(false);
                Achievementbt.gameObject.SetActive(false);
                Achievementbt.interactable = false;
                Settingbt.interactable = false;
                closeSettingbt.interactable = false;
                DropDownMenu.onClick.AddListener(() => DropDownMenuOnlick());
                DropDownMenu.onClick.AddListener(() => Destroy(Pointer_ClickMenubt));
                Settingbt.onClick.AddListener(() => Pointer_ClickSettingbt_Animator.SetBool("Exit", true));
                Settingbt.onClick.AddListener(() => Pointer_Settingbt.gameObject.SetActive(false));
                Settingbt.onClick.AddListener(() => Destroy(Pointer_Settingbt));
                Achievementbt.onClick.AddListener(() => Pointer_ClickTrophybt.gameObject.SetActive(false));
                Achievementbt.onClick.AddListener(() => Destroy(Pointer_ClickTrophybt));
                DisplayNextSentence.onClick.AddListener(() => sprite1.gameObject.SetActive(false));
                DisplayNextSentence.onClick.AddListener(() => sprite2.gameObject.SetActive(false));
                DisplayNextSentence.onClick.AddListener(() => skipbutton.gameObject.SetActive(true));
                closeSettingbt.onClick.AddListener(() => nextslidebutton.interactable = true);
                nextslidebutton.onClick.AddListener(() => NextPage());
                closeAchievementbt.onClick.AddListener(() => DropDownMenu2.interactable = true);
                closeAchievementbt.onClick.AddListener(() => nextslidebutton1.gameObject.SetActive(true));
                nextslidebutton1.onClick.AddListener(() => NextPage1());
                nextslidebutton1.onClick.AddListener(() => skipbutton.gameObject.SetActive(false));
                StartCoroutine("CountdownShowcontinu");
                playbt.onClick.AddListener(() => tutroialDataPrefab.GetComponent<PlayerSaveSystem>().SaveGame());


            }



            if (dialogueText.text.Contains(containtext))
            {
                skipbutton.gameObject.SetActive(true);
                sprite1.gameObject.SetActive(true);
            }
            if (dialogueText.text.Contains(containtext2))
            {
                sprite2.gameObject.SetActive(true);
            }
            if (dialogueText.text.Contains(containtext3))
            {

            }
            if (dialogueText.text.Contains(containtext4))
            {
                sprite4.gameObject.SetActive(true);
                sprite3.gameObject.SetActive(true);
            }
            if (dialogueText.text.Contains(containtext5))
            {
                sprite5.gameObject.SetActive(true);
            }
            if (dialogueText.text.Contains(containtext6))
            {
                sprite6.gameObject.SetActive(true);

            }
            if (dialogueText1.text.Contains(containtext7))
            {
                sprite7.gameObject.SetActive(true);
            }
            if (dialogueText1.text.Contains(containtext8))
            {
                sprite8.gameObject.SetActive(true);
            }
            if (dialogueText2.text.Contains(containtext9))
            {
                sprite9.gameObject.SetActive(true);
            }

            if (sprite2.gameObject.activeInHierarchy)
            {
                skipbutton.gameObject.SetActive(true);
            }
            if (sprite6.gameObject.activeInHierarchy && nextslide_bool == false)
            {
                nextslide_bool = true;
                nextslidebutton.gameObject.SetActive(true);

            }
            if (dialogueText.text.Contains(containtext3) && DropDownMenu_bool == false)
            {
                DropDownMenu_bool = true;
                DropDownMenu.interactable = true;
            }

            if (sprite3.gameObject.activeInHierarchy == true && pointer_bool == false)
            {
                pointer_bool = true;
                StartCoroutine("ShowPointer_ClickMenubt");
                Settingbt.interactable = true;


            }
            if (sprite8.gameObject.activeInHierarchy == true && pointer_bool2 == false)
            {
                pointer_bool2 = true;
                if (NewPLayer == true)
                {
                    StartCoroutine("ShowPointer_ClickTrophybt");
                }

            }

            if (sprite9.gameObject.activeInHierarchy == true && StartcoroutineCloseTrlPanel == false)
            {
                StartcoroutineCloseTrlPanel = true;
                StartCoroutine("CountdownToCloseTutorialPanel");
                StartCoroutine("ShowPointer_ClickPlaybt");
            }

            if (sprite6.gameObject.activeInHierarchy && NextSlide_bool == false)
            {
                NextSlide_bool = true;
                nextslidebutton.interactable = false;
                closeSettingbt.interactable = true;
            }


            if (dialogueText1.text.Contains(containtext8) && StartcoroutineTrophy == false)
            {
                StartcoroutineTrophy = true;
                StartCoroutine("ShowPointer_ClickTrophybt");
                Achievementbt.interactable = true;
            }
            if (dialogueText1.text.Contains(containtext10))
            {
                DisplayNextSentence1.gameObject.SetActive(true);
            }


             }
    }

    public void StartDialogue1(Dialogue dialogue)
    {

        sentences.Clear();
       
        foreach (string sentence in dialogue.sentences0)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNexSentence();
    }

    public void StartDialogue2(Dialogue dialogue1)
    {
        Debug.Log("StartingDiloague2");
        sentences1.Clear();

        foreach (string sentence in dialogue.sentences1)
        {
            sentences1.Enqueue(sentence);
        }

        DisplayNexSentence1();
    }

     public void StartDialogue3(Dialogue dialogue2)
    {
        Debug.Log("StartingDiloague3");
        sentences2.Clear();

        foreach (string sentence in dialogue.sentences2)
        {
            sentences2.Enqueue(sentence);
        }

        DisplayNexSentence2();
    }

    public void DisplayNexSentence()
    {
        if (sentences.Count == 0)
        {
          
            return;
        }
    
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayNexSentence1()
    {
        if (sentences1.Count == 0)
        {
           
            return;
        }
    
        string sentence = sentences1.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence1(sentence));
    }

    public void DisplayNexSentence2()
    {
        if (sentences2.Count == 0)
        {
           
            return;
        }
    
        string sentence = sentences2.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence2(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
            
        }


    }
    IEnumerator TypeSentence1(string sentence)
    {
        dialogueText1.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText1.text += letter;
            yield return null;
            
        }

    }

    IEnumerator TypeSentence2(string sentence)
    {
        dialogueText2.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText2.text += letter;
            yield return null;
            
        }
    }  
    
    public void CallingStartDialogue2()
    {
        StartDialogue2(dialogue);
    }
    
    public void CallingStartDialogue3()
    {
        StartDialogue3(dialogue);
    }

    public void ShowSprite()
    {

        if (sprite1.IsActive() && sprite2.IsActive())
        {
            sprite1.gameObject.SetActive(false);
            sprite2.gameObject.SetActive(false);
        }
    }
    public void NextPage()
    {
        TutorialPanel_Animator.SetBool("NextPage2", true);
        nextslidebutton.gameObject.SetActive(false);
    }
    public void NextPage1()
    {
        TutorialPanel_Animator.SetBool("NextPage3",true);
        nextslidebutton1.gameObject.SetActive(false);
    }

    public void DropDownMenuOnlick()
    {
        DropDownMenu2.interactable = false;
        StartCoroutine("ShowPointer_ClickSettingbt");
        Pointer_ClickMenubt.gameObject.SetActive(false);
        Settingbt.gameObject.SetActive(true);
        Achievementbt.gameObject.SetActive(true);
        achievementbt_animator.SetBool("DropDownPress", true);
        settingbt_animator.SetBool("DropDownPress", true);
    }
    public void SkiTutorialButton()
    {
        AssuringPanel_Animator.SetBool("AreyouSure", true);
    }
    public void Assuring()
    {
        
        tutroialDataPrefab.GetComponent<PlayerSaveSystem>().Tutiroal_BoolMainScene = false;
        tutroialDataPrefab.GetComponent<PlayerSaveSystem>().SaveGame();
        SceneManager.LoadScene("Main");
    }

    public void NotAssuring()
    {
        AssuringPanel_Animator.SetBool("AreyouSure", false);
    }
    

    IEnumerator ShowPointer_ClickSettingbt()
    {
        yield return new WaitForSeconds(1.4f);
        Pointer_Settingbt.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Pointer_ClickSettingbt_Animator.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        Pointer_ClickSettingbt_Animator.Play("Pointer_guidde_ClickButtonPlay_idle");
    }

    IEnumerator ShowPointer_ClickPlaybt()
    {
        yield return new WaitForSeconds(1.4f);
        Pointer_Playbt.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Pointer_ClickPlay_Animator.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        Pointer_ClickPlay_Animator.Play("Pointer_guidde_ClickButtonPlay_idle");
    }

    IEnumerator ShowPointer_ClickMenubt()
    {
        yield return new WaitForSeconds(1.4f);
        Pointer_ClickMenubt.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Pointer_ClickMenubt_animator.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        Pointer_ClickMenubt_animator.Play("Pointer_guidde_ClickButtonPlay_idle");
       
    }

    IEnumerator ShowPointer_ClickTrophybt()
    {
        yield return new WaitForSeconds(1.4f);
        Pointer_ClickTrophybt.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClickTrophy_Animator.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClickTrophy_Animator.Play("Pointer_guidde_ClickButtonPlay_idle");
        NewPLayer = false;
    }
    IEnumerator CountdownShowcontinu()
    {
        yield return new WaitForSeconds(3.0f);
        DisplayNextSentence.gameObject.SetActive(true);
    }
    IEnumerator CountdownToCloseTutorialPanel()
    {
        yield return new WaitForSeconds(3.4f);
        TutorialPanel_Animator.SetBool("isBool", false);
        TutorialPanel_Animator.SetBool("CloseTutorial", true);
    }
    IEnumerator LoadingSceneAgain()
    {
        yield return new WaitForSeconds(1.0f);
        tutroialDataPrefab.GetComponent<PlayerSaveSystem>().SaveGame();
        SceneManager.LoadScene(0);
    }


}
