using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogueManagerMemoryGame : MonoBehaviour
{
    private Animator contentMessage;
    private AudioSource SourceSoun_timeClock;
    private Button btSkip, btcontinueSentence, btbubblemessage;
    private GameObject PlayerSaveSystem, Canvas_GameRiddleLevel1_gameObject, Tutorial_for_newcommer_gameObject;
    private GameObject btProgress, btNext, GameResultPanel_gameObject, image_correct_gameObject, image_wrong_gameObject, Ready_panel_gameObject;
    private GameObject[] btns;
    private Queue<string> sentences;
    private TMP_Text DialogueText;
    private TMP_Text DialogueTitle;
    private bool bool_Dialogue_line1 = false, bool_Dialogue_line2 = false, bool_Dialogue_line3 = false;
    public DialogueMemory dialogue;
    private string containtext1 = "Welcome to Memory Game, same as the function of buttons of Riddle Game but how you answer is now different..";
    private string containtext2 = "here where button is flip back, the letter only can be seen if you press any of them and wil be shown";
    private string containtext3 = "each tap will spell in Answer Field, the whole word is your answer";
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        Canvas_GameRiddleLevel1_gameObject = GameObject.Find("Canvas");

        PlayerSaveSystem = GameObject.Find("PlayerSaveSystem");

        Tutorial_for_newcommer_gameObject = GameObject.Find("Tutorial for newcommer");

        DialogueText = GameObject.Find("Text_Dialogue1").GetComponent<TMP_Text>();
        DialogueTitle = GameObject.Find("Text_Title_Message1").GetComponent<TMP_Text>();
        GameResultPanel_gameObject = GameObject.Find("GameResultPanel");
        btNext = GameObject.Find("btNextQuestion");
        btProgress = GameObject.Find("btProgress");
        btSkip = GameObject.Find("btSkip1").GetComponent<Button>();
        btbubblemessage = GameObject.Find("btnextBubblemessage1").GetComponent<Button>();
        btcontinueSentence = GameObject.Find("btContinueSentence1").GetComponent<Button>();
        contentMessage = GameObject.Find("ContentMessage1").GetComponent<Animator>();
        SourceSoun_timeClock = GameObject.Find("Sound_TimerClock").GetComponent<AudioSource>();
        btns = GameObject.FindGameObjectsWithTag("PuzzleButton");
        image_correct_gameObject = GameObject.Find("Image_Correct");
        image_wrong_gameObject = GameObject.Find("Image_Wrong");
        Ready_panel_gameObject = GameObject.Find("MessagePop");
        if (PlayerSaveSystem.GetComponent<PlayerSaveSystem>().Tutiroal_BoolMemorYGame == true)
        {
            contentMessage.Play("Content_Message_Tutorial_Riddle_Show");
            StartCoroutine("StartDialogueCoroutine");
            if (Canvas_GameRiddleLevel1_gameObject != null)
            {
                Canvas_GameRiddleLevel1_gameObject.GetComponent<MemoryGameContol1>().enabled = false;
                (Canvas_GameRiddleLevel1_gameObject.GetComponent<MemoryGameContol1>() as MonoBehaviour).enabled = false;
            }
            if (btSkip && btbubblemessage && btcontinueSentence && DialogueText && DialogueTitle != null)
            {
                btSkip.gameObject.SetActive(false);
                btSkip.onClick.AddListener(()=> contentMessage.Play("Content_Message_Tutorial_Riddle_TurnBack"));
                btSkip.onClick.AddListener(()=> StartCoroutine("WaitingandMovingToMemoryGameLevel1"));
                btSkip.onClick.AddListener(()=> btSkip.gameObject.SetActive(false));
                btSkip.onClick.AddListener(()=> btbubblemessage.gameObject.SetActive(false));
                btSkip.onClick.AddListener(()=> btcontinueSentence.gameObject.SetActive(false));
                btSkip.onClick.AddListener(()=> DialogueText.gameObject.SetActive(false));
                btSkip.onClick.AddListener(()=> DialogueTitle.gameObject.SetActive(false));
                btbubblemessage.gameObject.SetActive(false);
                btbubblemessage.onClick.AddListener(()=> btbububblemessage_addlistiner());
                btcontinueSentence.gameObject.SetActive(false);
                btcontinueSentence.onClick.AddListener(() => DisplayNexSentence());
                DialogueTitle.gameObject.SetActive(false);
                DialogueText.gameObject.SetActive(false);
            }
            if (GameResultPanel_gameObject != null)
            {
                GameResultPanel_gameObject.gameObject.SetActive(false);
            }
            if (SourceSoun_timeClock != null)
            {
                SourceSoun_timeClock.Stop();
            }

            if (btns != null)
            {
                foreach (GameObject item in btns)
                {
                    Destroy(item);
                }
            }
            if (image_correct_gameObject && image_wrong_gameObject != null)
            {
                image_correct_gameObject.gameObject.SetActive(false);
                image_wrong_gameObject.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log(" can't disable the imaages ");
            }

            if (Ready_panel_gameObject != null)
            {
                Ready_panel_gameObject.gameObject.SetActive(false);
            }
            if (btProgress && btNext != null)
            {
                btProgress.gameObject.SetActive(false);
                btNext.gameObject.SetActive(false);
            }
        }
        else
        {
            if (Tutorial_for_newcommer_gameObject != null)
            {
                Destroy(Tutorial_for_newcommer_gameObject);
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueText.text.Contains(containtext1) && bool_Dialogue_line1 == false)
        {
            bool_Dialogue_line1 = true;
            btcontinueSentence.gameObject.SetActive(true);
        }
        if (DialogueText.text.Contains(containtext2) && bool_Dialogue_line2 == false)
        {
            bool_Dialogue_line2 = true;
            btcontinueSentence.gameObject.SetActive(true);
        }
        if (DialogueText.text.Contains(containtext3) && bool_Dialogue_line3 == false)
        {
            bool_Dialogue_line3 = true;
            btbubblemessage.gameObject.SetActive(true);
        }

    }

    void btbububblemessage_addlistiner()
    {
        DialogueText.gameObject.SetActive(false);
        DialogueTitle.gameObject.SetActive(false);
        btbubblemessage.gameObject.SetActive(false);
        btcontinueSentence.gameObject.SetActive(false);
        btSkip.gameObject.SetActive(false);
        contentMessage.Play("Content_Message_Tutorial_Riddle_TurnBack");
        StartCoroutine("WaitingandMovingToMemoryGameLevel1");
    }

    public void StartDialogue(DialogueMemory dialogue)
    {
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences0)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNexSentence();
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

    IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;

        }
    }
    IEnumerator StartDialogueCoroutine()
    {
        yield return new WaitForSeconds(1f);
        StartDialogue(dialogue);
        DialogueText.gameObject.SetActive(true);
        DialogueTitle.gameObject.SetActive(true);
        btSkip.gameObject.SetActive(true);
    }
    IEnumerator WaitingandMovingToMemoryGameLevel1()
    {
        PlayerSaveSystem.GetComponent<PlayerSaveSystem>().Tutiroal_BoolMemorYGame = false;
        PlayerSaveSystem.GetComponent<PlayerSaveSystem>().SaveGame();

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MemoryGame1");
        
    }
}
