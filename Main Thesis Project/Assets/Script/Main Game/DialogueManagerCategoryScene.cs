using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManagerCategoryScene : MonoBehaviour
{
    public static DialogueManagerCategoryScene dmc;
    private Queue<string> sentences3;
    public TMP_Text dialogueText4;
    string containtext = "We recommend the Riddle Mode, press the Riddle button";
    public Dialogue dialogue;
    public GameObject Pointer_ClickRiddlebt;
    public Animator Pointer_ClickRiddle_animator, GuideMEssagePanel;
    private bool  newplayer = true, sentences3_bool = false;
    public GameObject sprite1;
    private GameObject TutorialData;
    private Button btMemoryGame;
    void Update()
    {
        TutorialData = GameObject.Find("PlayerSaveSystem");

        if (TutorialData.GetComponent<PlayerSaveSystem>().Tutiroal_BoolCategoryScene == true)
        {
            if (dialogueText4.text.Contains(containtext))
            {
                sprite1.gameObject.SetActive(true);
            }
            if (sprite1.gameObject.activeInHierarchy && sentences3_bool == false)
            {
                sentences3_bool = true;
                call2coroutine();

            }
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        TutorialData = GameObject.Find("PlayerSaveSystem");
        btMemoryGame = GameObject.Find("btMemory_game").GetComponent<Button>();

        if (TutorialData.GetComponent<PlayerSaveSystem>().Tutiroal_BoolCategoryScene == true)
        {
            sentences3 = new Queue<string>();
            GuideMEssagePanel.Play("GuideMessaeg_Categorie_Open");
            StartDialogue4(dialogue);
            sprite1.gameObject.SetActive(false);
            Pointer_ClickRiddlebt.gameObject.SetActive(false);
            btMemoryGame.interactable = false;
        }

        else
        {
            GameObject gameObject = GameObject.Find("GuideMessgaeTutorialCategoryScene");
            Destroy(gameObject);
            Destroy(Pointer_ClickRiddlebt);
        }
        
    
    }

    public void StartDialogue4(Dialogue dialogue3)
    {
        Debug.Log("StartingDiloague3");
        sentences3.Clear();

        foreach (string sentence in dialogue.sentences3)
        {
            sentences3.Enqueue(sentence);
        }

        DisplayNexSentence();
    }


    public void DisplayNexSentence()
    {
        if (sentences3.Count == 0)
        {
            call2coroutine();
            return;
        }

        string sentence = sentences3.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText4.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText4.text += letter;
            yield return null;

        }
    }


    IEnumerator ShowPointerClickRiddleBt()
    {
        yield return new WaitForSeconds(1.4f);
        Pointer_ClickRiddlebt.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Pointer_ClickRiddle_animator.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        Pointer_ClickRiddle_animator.Play("Pointer_guidde_ClickButtonPlay_idle");
        newplayer = false;

    }
    IEnumerator ClosePanel()
    {
        yield return new WaitForSeconds(1.7f);
        GuideMEssagePanel.Play("GuideMessaeg_Categorie_Close");
    }

    void call2coroutine()
    {
        StartCoroutine("ClosePanel");
        StartCoroutine("ShowPointerClickRiddleBt");
    }
}
