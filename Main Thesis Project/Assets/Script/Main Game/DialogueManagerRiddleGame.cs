using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogueManagerRiddleGame : MonoBehaviour
{
    //Top
    private Queue<string> sentences;
    private Queue<string> sentences2;
    private Queue<string> sentences3;
    private Queue<string> sentences4;
    private Queue<string> sentences5;
    private Queue<string> sentences6;
    public GameObject Gameplaylevel1;
    private TMP_Text DialogueText1, DialogueText2, DialogueText3, DialogueText4, DialogueText5, DialogueText6;
    private TMP_Text DialogueTitle1, DialogueTitle2, DialogueTitle3, DialogueTitle4, DialogueTitle5, DialogueTitle6;
    private Text TextTimer;
    private float Float_Timer_of_game = 30f;
    private Image Image_Timbar;
    string TextTitle1 = "Guide: Welcome";
    string TextTitle2 = "Guide: Hints";
    string TextTitle3 = "Guide: Question Field";
    string TextTitle4 = "Guide: Answer Field";
    string TextTitle5 = "Guide: Timer";
    string TextTitle6 = "Guide: Rounds";
    string TextTitle7 = "Guide: Next Button";
    string TextTitle8 = "Guide: Progress Button";
    string TextTitle9 = "Guide: Game Progress";
    string TextTitle10 = "Guide: End of Guide";
    string containtext = "Welcom to Riddle Game, we start by guiding you from interactive components by learning the visual user interface in you screen, of what may can do to help you understand the functionality of the game ";
    string containtext2 = "The hint button";
    string containtext3 = "then the panel content show what letter is";
    string containtext4 = "you no longer see any hint anymore";
    string containtext5 = "The riddle will appear in the Question field";
    string containtext6 = " by answering the riddle the buttons will appear in the bottom with Letter on it and identify the word that want to give";
    string containtext7 = "Tapping the buttons in Answer Field";
    string containtext8 = " The riddle will appear in the Question field , by answering the riddle the buttons will appear in the bottom with Letter on it and identify the word that want to give";
    string containtext9 = "Tapping the buttons in Answer Field will display and spell the word foreach tap of button, it will make the whole or one word as your answer";
    string containtext10 = "This is the timer indicator";
    string containtext11 = "n the right top side of Question Field";
    string containtext12 = " This is the timer indicator,                   you only have 30 seconds for each question, when the time is hit zero the game is over";
    string containtext13 = "is getting more difficult.";
    string containtext14 = "If you get the right answer it will indicate with correct icon";
    string containtext15 = "then the next button will appear";
    string containtext16 = "pressing it will instantly go directly move to next question.";
    string containtext17 = "if you got it wrong it willl indicate with Wrong icon";
    string containtext18 = "and the Progress button";
    string containtext19 = "right bottom of  Answer Field";

    string containtext20 = "Tapping the Progress Button will appear your game progress panel, here you can see your over all time and your score";
    string containtext21 = "and also you can see  your answer by pressing the Review button";
    string containtext22 = "the three buttons in the bottom of the game progress panel where the..";
    string containtext23 = "Try Again Button if you got a wrong answer pressing it and will restart the level";
    string containtext24 = "the Next Level Button where you completed answering of all the riddle of the level then this button appear pressing it will go to the next level";
    string containtext25 = "and the last button is the Return Home Button where can go back in main menu of application";
    string containtext26 = "that's all the guide you need for the riddle game";

    public DialogueRiddle dialogue;
    //Private_Resident_GameObject
    private GameObject ContentMessage1_gameObject, ContentMessage2_gameObject, ContentMessage3_gameObject, Sprite1, Sprite2, btbubblemessage1_gameObject;
    private GameObject btbubblemessage2_gameObject , btbubblemessage3_gameObject;
    private GameObject ContentMessage4_gameObject, ContentMessage5_gameObject, ContentMessage6_gameObject;
    private GameObject Tutorial_for_newcommer,  panel_playersavesysteml, GameResultPanel, showAnswerpanel;
    private GameObject MessagePop, bthint, btnext, btProgress, btPlayagain, btnextlevel, btReturnchome, btAnswerReview, DialogueManager_Riddle;
    private GameObject PointerClick_btanswer_gameObject, PointerClick_btnextQuestio_gameObject;
    private GameObject PointerClick_btprogressbutton_gameObject, PointerClick_btAnswerreview_gameObject;
    private GameObject PointerClick_hintpanel_gameObject, PointerClick_ImageTimebar_gameObject;
    private GameObject PointerClick_textRounQuestion_gameObject, PointerClick_textAnswerspell_gameObject;
    private GameObject PointerClick_btplayAgain_gameObject, PointerClick_btnextlevel_gameObject;
    private GameObject Pointerclick_btreturnhome_gameObject, PointerClick_textScore_gameObject;
    private GameObject pointer_Clicktexttime_gameObject, PointerClick_bthint_gameObject, PointerClick_QuestionField_gameObject;
    private GameObject PointerClick_AnswerBttom_gameObject;
    private GameObject btTemp1, btTemp2, btTemp3, btTemp4, btTemp5, textSampleAnswer_gameobject, Sprite3, Sprite4, Sprite5, Sprite6, Sprite7;
    private GameObject GameProgressPanel_gameobject;
    //Private_Resident_Animator
    private Animator  ContentnMessage1_animator, ContentnMessage2_animator,ContentnMessage3_animator, HintPanel;
    private Animator ContentnMessage4_animator, ContentnMessage5_animator, ContentnMessage6_animator;
    private Animator PointerClick_btanswer, PointerClick_btnextQuestio, PointerClick_btprogressbutton, PointerClick_btAnswerreview, PointerClick_bthint;
    private Animator PointerClick_hintpanel, PointerClick_ImageTimebar, PointerClick_textRounQuestion, PointerClick_textAnswerspell;
    private Animator PointerClick_btplayAgain, PointerClick_btnextlevel, Pointerclick_btreturnhome, PointerClick_textScore, pointer_Clicktexttime;
    private Animator PointerClick_QuestionField,PointerClick_AnswerBottom;
    private List<GameObject> list_btTemp = new List<GameObject>();
    private Button btcontinuesentence1, btcontinuesentence2, btSkiptutroial1, btSkiptutroial2, btbubblemessage1, btbubblemessage2, btSkiptutroial3, btbubblemessage3, btcontinuesentence3;
    private Button btbubblemessage4, btSkiptutroial4, btcontinuesentence4, btbubblemessage5, btSkiptutroial5, btcontinuesentence5;
    private Button btbubblemessage6;
    //Private_ Resident_bool
    private bool TuttorialShow_bool = false, TuttorialShow_bool_bool2 = false, bool_btmessage1 = false, bool_btmessage2 = false;
    private bool NextSlide_bool = false, bool_pointerclickhintbutton = false, bool_pointerclickhintpanel = false, bool_pointerclickQuestionfield = false;
    private bool bool_pointerclickAnswerBottom = false, bool_pointerClickQuestionfiled = false, bool_pointertextnswerspeel = false, bool_pointerTimer = false;
    private bool bool_pointerTextQuestionCount = false, bool_btmessageandbtconsentence2 = false, bool_btcoontinue3 = false, bool_btbubblemessage3 = false;
    private bool bool_stoptheTime = false, bool_pointerclickbtNext = false, bool_pointerclickbtProgress = false, bool_btcontinuesentence1 = false;
    private bool bool_btcontinuesentence2 = false, bool_btcontinuesentence4 = false, bool_Pointerclick_btprogress = false, bool_Sprite6 = false, bool_btbubblemessage4 = false;
    private bool bool_pointerclick_btPlayagain = false,  bool_pointerclick_btNextlevel = false  ,bool_pointerclick_btReturnhome = false;
    private bool bool_btcontinuesentence5 = false;
    private void Start()
    {

        
        ContentnMessage1_animator = GameObject.Find("ContentMessage1").GetComponent<Animator>();
        ContentnMessage2_animator = GameObject.Find("ContentMessage2").GetComponent<Animator>();
        ContentnMessage3_animator = GameObject.Find("ContentMessage3").GetComponent<Animator>();
        ContentnMessage4_animator = GameObject.Find("ContentMessage4").GetComponent<Animator>();
        ContentnMessage5_animator = GameObject.Find("ContentMessage5").GetComponent<Animator>();
        ContentnMessage6_animator = GameObject.Find("ContentMessage6").GetComponent<Animator>();
        ContentMessage1_gameObject = GameObject.Find("ContentMessage1");
        ContentMessage2_gameObject = GameObject.Find("ContentMessage2");
        ContentMessage3_gameObject = GameObject.Find("ContentMessage3");
        ContentMessage4_gameObject = GameObject.Find("ContentMessage4");
        ContentMessage5_gameObject = GameObject.Find("ContentMessage5");
        ContentMessage6_gameObject = GameObject.Find("ContentMessage6");

        DialogueManager_Riddle = GameObject.Find("DialogueManager");
        DialogueTitle1 = GameObject.Find("Text_Title_Message1").GetComponent<TMP_Text>();
        DialogueTitle2 = GameObject.Find("Text_Title_Message2").GetComponent<TMP_Text>();
        DialogueTitle3 = GameObject.Find("Text_Title_Message3").GetComponent<TMP_Text>();
        DialogueTitle4 = GameObject.Find("Text_Title_Message4").GetComponent<TMP_Text>();
        DialogueTitle5 = GameObject.Find("Text_Title_Message5").GetComponent<TMP_Text>();
        DialogueTitle6= GameObject.Find("Text_Title_Message6").GetComponent<TMP_Text>();
        DialogueText1 = GameObject.Find("Text_Dialogue1").GetComponent<TMP_Text>();
        DialogueText2 = GameObject.Find("Text_Dialogue2").GetComponent<TMP_Text>();
        DialogueText3 = GameObject.Find("Text_Dialogue3").GetComponent<TMP_Text>();
        DialogueText4 = GameObject.Find("Text_Dialogue4").GetComponent<TMP_Text>();
        DialogueText5 = GameObject.Find("Text_Dialogue5").GetComponent<TMP_Text>();
        DialogueText6 = GameObject.Find("Text_Dialogue6").GetComponent<TMP_Text>();
        GameResultPanel = GameObject.Find("GameResultPanel");
        GameProgressPanel_gameobject = GameObject.Find("GameResultPanel_Temp");
        HintPanel = GameObject.Find("HintPanel").GetComponent<Animator>();
        MessagePop = GameObject.Find("MessagePop");
        Tutorial_for_newcommer = GameObject.Find("Tutorial for newcommer");

        btSkiptutroial1 = GameObject.Find("btSkip1").GetComponent<Button>();
        btSkiptutroial2 = GameObject.Find("btSkip2").GetComponent<Button>();
        btSkiptutroial3 = GameObject.Find("btSkip3").GetComponent<Button>();
        btSkiptutroial4 = GameObject.Find("btSkip4").GetComponent<Button>();
        btSkiptutroial5 = GameObject.Find("btSkip5").GetComponent<Button>();
        btcontinuesentence1 = GameObject.Find("btContinueSentence1").GetComponent<Button>();
        btcontinuesentence2 = GameObject.Find("btContinueSentence2").GetComponent<Button>();
        btcontinuesentence3 = GameObject.Find("btContinueSentence3").GetComponent<Button>();
        btcontinuesentence4 = GameObject.Find("btContinueSentence4").GetComponent<Button>();
        btcontinuesentence5 = GameObject.Find("btContinueSentence5").GetComponent<Button>();
        btbubblemessage1_gameObject = GameObject.Find("btnextBubblemessage1");
        btbubblemessage2_gameObject = GameObject.Find("btnextBubblemessage2");
        btbubblemessage3_gameObject = GameObject.Find("btnextBubblemessage3");
        btbubblemessage1 = GameObject.Find("btnextBubblemessage1").GetComponent<Button>();
        btbubblemessage2 = GameObject.Find("btnextBubblemessage2").GetComponent<Button>();
        btbubblemessage3 = GameObject.Find("btnextBubblemessage3").GetComponent<Button>();
        btbubblemessage4 = GameObject.Find("btnextBubblemessage4").GetComponent<Button>();
        btbubblemessage5 = GameObject.Find("btnextBubblemessage5").GetComponent<Button>();
        btbubblemessage6 = GameObject.Find("btnextBubblemessage6").GetComponent<Button>();

        btTemp1 = GameObject.Find("buttontempShow1");
        btTemp2 = GameObject.Find("buttontempShow2");
        btTemp3 = GameObject.Find("buttontempShow3");
        btTemp4 = GameObject.Find("buttontempShow4");
        btTemp5 = GameObject.Find("buttontempShow5");
        if (btTemp1 && btTemp2 && btTemp3 && btTemp4 && btTemp5 != null)
        {
            list_btTemp.Add(btTemp1);
            list_btTemp.Add(btTemp2);
            list_btTemp.Add(btTemp3);
            list_btTemp.Add(btTemp4);
            list_btTemp.Add(btTemp5);
            foreach (GameObject item in list_btTemp)
            {
                item.gameObject.SetActive(false);
            }
        }

        textSampleAnswer_gameobject = GameObject.Find("TextSampleAnswer");

        Sprite1 = GameObject.Find("Sprite1");
        Sprite2 = GameObject.Find("Sprite2");
        Sprite3 = GameObject.Find("Sprite3");
        Sprite4 = GameObject.Find("Sprite4");
        Sprite5 = GameObject.Find("Sprite5");
        Sprite6 = GameObject.Find("Sprite6");
        Sprite7 = GameObject.Find("Sprite7");

        
        panel_playersavesysteml = GameObject.Find("PlayerSaveSystem");
        sentences = new Queue<string>();
        sentences2 = new Queue<string>();
        sentences3 = new Queue<string>();
        sentences4 = new Queue<string>();
        sentences5 = new Queue<string>();
        sentences6 = new Queue<string>();
        showAnswerpanel = GameObject.Find("ShowAnswer");

        PointerClick_hintpanel = GameObject.Find("pointer_Clickhintpanel").GetComponent<Animator>();
        PointerClick_btnextQuestio = GameObject.Find("pointer_Clickbtnextquestion").GetComponent<Animator>();
        PointerClick_btprogressbutton = GameObject.Find("pointer_ClickbtProgress").GetComponent<Animator>();
        PointerClick_ImageTimebar = GameObject.Find("pointer_ClickImage_Timer").GetComponent<Animator>();
        PointerClick_textRounQuestion = GameObject.Find("pointer_ClickTextRoundQuestion").GetComponent<Animator>();
        PointerClick_textAnswerspell = GameObject.Find("pointer_ClickTextAnswerSpell").GetComponent<Animator>();
        PointerClick_btplayAgain = GameObject.Find("pointer_ClickbtPlayAgain").GetComponent<Animator>();
        PointerClick_btnextlevel = GameObject.Find("pointer_ClickbtNextlevel").GetComponent<Animator>();
        Pointerclick_btreturnhome = GameObject.Find("pointer_ClickbtReturnHome").GetComponent<Animator>();
        PointerClick_btAnswerreview = GameObject.Find("pointer_ClickbtAnswerReview").GetComponent<Animator>();
        PointerClick_textScore = GameObject.Find("pointer_ClickTexScore").GetComponent<Animator>();
        pointer_Clicktexttime = GameObject.Find("pointer_Clicktexttime").GetComponent<Animator>();
        PointerClick_bthint = GameObject.Find("pointer_Clickbthint").GetComponent<Animator>();
        PointerClick_QuestionField = GameObject.Find("pointer_ClickQuestionField").GetComponent<Animator>();
        PointerClick_AnswerBottom = GameObject.Find("pointer_ClickAnswerBottom").GetComponent<Animator>();

        PointerClick_bthint_gameObject = GameObject.Find("pointer_Clickbthint");
        PointerClick_hintpanel_gameObject = GameObject.Find("pointer_Clickhintpanel");
        PointerClick_btnextQuestio_gameObject = GameObject.Find("pointer_Clickbtnextquestion");
        PointerClick_btprogressbutton_gameObject = GameObject.Find("pointer_ClickbtProgress");
        PointerClick_ImageTimebar_gameObject = GameObject.Find("pointer_ClickImage_Timer");
        PointerClick_textRounQuestion_gameObject = GameObject.Find("pointer_ClickTextRoundQuestion");
        PointerClick_textAnswerspell_gameObject = GameObject.Find("pointer_ClickTextAnswerSpell");
        PointerClick_btplayAgain_gameObject = GameObject.Find("pointer_ClickbtPlayAgain");
        PointerClick_btnextlevel_gameObject = GameObject.Find("pointer_ClickbtNextlevel");
        Pointerclick_btreturnhome_gameObject = GameObject.Find("pointer_ClickbtReturnHome");
        PointerClick_btAnswerreview_gameObject = GameObject.Find("pointer_ClickbtAnswerReview");
        PointerClick_textScore_gameObject = GameObject.Find("pointer_ClickTexScore");
        pointer_Clicktexttime_gameObject = GameObject.Find("pointer_Clicktexttime");
        PointerClick_QuestionField_gameObject = GameObject.Find("pointer_ClickQuestionField");
        PointerClick_AnswerBttom_gameObject = GameObject.Find("pointer_ClickAnswerBottom");

        bthint = GameObject.Find("HintButton");
        btnext = GameObject.Find("NextButtonQuestion_temp");
        btProgress = GameObject.Find("BtResult_temp");
        btPlayagain = GameObject.Find("img_playAgain_temp");
        btnextlevel = GameObject.Find("img_continue_temp");
        btReturnchome = GameObject.Find("img_Home_temp");
        btAnswerReview = GameObject.Find("img_review_temp");



        if (panel_playersavesysteml.GetComponent<PlayerSaveSystem>().Tutiroal_BoolRiddleScene == true)
        {
            StartCoroutine("StartDialogue1Coroutine");
            Gameplaylevel1.GetComponent<GameplayLevel1>().enabled = false;
            (Gameplaylevel1.GetComponent<GameplayLevel1>() as MonoBehaviour).enabled = false;

            if (DialogueTitle1 && DialogueText1 && DialogueTitle2 && DialogueText2  != null)
            {
                DialogueTitle1.text = TextTitle1;
                DialogueTitle2.text = TextTitle3;
                DialogueTitle1.gameObject.SetActive(false);
                DialogueTitle2.gameObject.SetActive(false);
                DialogueText1.gameObject.SetActive(false);
                DialogueText2.gameObject.SetActive(false);
            }

            if ( DialogueTitle3 && DialogueText3 != null)
            {
                DialogueText3.gameObject.SetActive(false);
                DialogueTitle3.gameObject.SetActive(false);
                DialogueTitle3.text = TextTitle5;
            }

            if ( DialogueTitle4 && DialogueText4 != null)
            {
                DialogueText4.gameObject.SetActive(false);
                DialogueTitle4.gameObject.SetActive(false);                
                DialogueTitle4.text = TextTitle7;                
            }
            if ( DialogueTitle5 && DialogueText5 != null)
            {
                DialogueText5.gameObject.SetActive(false);
                DialogueTitle5.gameObject.SetActive(false);                
                DialogueTitle5.text = TextTitle9;                
            }
            if ( DialogueTitle6 && DialogueText6 != null)
            {
                DialogueText6.gameObject.SetActive(false);
                DialogueTitle6.gameObject.SetActive(false);                
                DialogueTitle6.text = TextTitle10;                
            }

            if (Sprite1 && Sprite2 && Sprite3 && Sprite4 && Sprite5 && Sprite6  && Sprite7 != null)
            {
                Sprite1.gameObject.SetActive(false);
                Sprite2.gameObject.SetActive(false);
                Sprite3.gameObject.SetActive(false);
                Sprite4.gameObject.SetActive(false);
                Sprite5.gameObject.SetActive(false);
                Sprite6.gameObject.SetActive(false);
                Sprite7.gameObject.SetActive(false);
            }

            if (MessagePop != null)
            {
                Destroy(MessagePop);
            }
            if (bthint != null)
            {
                bthint.gameObject.SetActive(false);
                bthint.GetComponent<Button>().onClick.AddListener(() => Destroy(PointerClick_bthint_gameObject));
                bthint.GetComponent<Button>().onClick.AddListener(() => btcontinuesentence1.gameObject.SetActive(false));
                Debug.Log("bthin Have been found");
            }
            if (btnext != null)
            {
                btnext.gameObject.SetActive(false);
                Debug.Log("btnext Have been found");
            }

            if (btProgress != null)
            {
                btProgress.gameObject.SetActive(false);
                btProgress.GetComponent<Button>().onClick.AddListener(()=> GameProgressPanel_gameobject.gameObject.SetActive(true));
                btProgress.GetComponent<Button>().onClick.AddListener(()=> btSkip4_addlistiner());
            }
            if (btPlayagain != null)
            {
                btPlayagain.gameObject.SetActive(false);
            }
            if (btnextlevel !=null)
            {
                btnextlevel.gameObject.SetActive(false);
            }
            if (btReturnchome != null)
            {
                btReturnchome.gameObject.SetActive(false);
            }
            if (btAnswerReview != null)
            {      
                btAnswerReview.gameObject.SetActive(false);
            }

            if (GameResultPanel && showAnswerpanel != null)
            {
                GameResultPanel.gameObject.SetActive(false);
                showAnswerpanel.gameObject.SetActive(false);

            }
            if (GameProgressPanel_gameobject != null)
            {
                GameProgressPanel_gameobject.gameObject.SetActive(false);
            }

            if (PointerClick_bthint && PointerClick_hintpanel && PointerClick_btnextQuestio && PointerClick_btprogressbutton && PointerClick_ImageTimebar &&
               PointerClick_textRounQuestion && PointerClick_textRounQuestion && PointerClick_textAnswerspell && PointerClick_btplayAgain && PointerClick_btnextlevel
               && Pointerclick_btreturnhome && PointerClick_btAnswerreview && PointerClick_textScore && pointer_Clicktexttime && PointerClick_QuestionField && 
               PointerClick_AnswerBottom != null)
            {
                PointerClick_bthint.gameObject.SetActive(false);
                PointerClick_hintpanel.gameObject.SetActive(false);
                PointerClick_btnextQuestio.gameObject.SetActive(false);
                PointerClick_btprogressbutton.gameObject.SetActive(false);
                PointerClick_ImageTimebar.gameObject.SetActive(false);
                PointerClick_textRounQuestion.gameObject.SetActive(false);
                PointerClick_textAnswerspell.gameObject.SetActive(false);
                PointerClick_btplayAgain.gameObject.SetActive(false);
                PointerClick_btnextlevel.gameObject.SetActive(false);
                Pointerclick_btreturnhome.gameObject.SetActive(false);
                PointerClick_btAnswerreview.gameObject.SetActive(false);
                PointerClick_textScore.gameObject.SetActive(false);
                pointer_Clicktexttime.gameObject.SetActive(false);
                PointerClick_QuestionField.gameObject.SetActive(false);
                PointerClick_AnswerBottom.gameObject.SetActive(false);
            }



            if (btcontinuesentence1 && btSkiptutroial1 && btbubblemessage1 != null)
            {
                btcontinuesentence1.gameObject.SetActive(false);
                btSkiptutroial1.gameObject.SetActive(false);
                btSkiptutroial1.onClick.AddListener(()=> btSkip1_addlistiner());
                btcontinuesentence1.onClick.AddListener(() => DisplayNexSentence());
                btcontinuesentence1.onClick.AddListener(() => DialogueTitle1.text = TextTitle2);
                btcontinuesentence1.onClick.AddListener(() => btcontinuesentence1.gameObject.SetActive(false));

                btbubblemessage1.gameObject.SetActive(false);
                btbubblemessage1.onClick.AddListener(() => ContentnMessage1_animator.Play("Content_Message_Tutorial_Riddle_TurnBack"));
                btbubblemessage1.onClick.AddListener(() => ContentnMessage2_animator.Play("Content_Message_Tutorial_Riddle_Show"));
                btbubblemessage1.onClick.AddListener(() => Destroy(PointerClick_hintpanel_gameObject));
                btbubblemessage1.onClick.AddListener(() => Destroy(PointerClick_bthint_gameObject));
                btbubblemessage1.onClick.AddListener(() => btbubblemessage1.gameObject.SetActive(false));
                btbubblemessage1.onClick.AddListener(() => btSkiptutroial1.gameObject.SetActive(false));
                btbubblemessage1.onClick.AddListener(() => bthint.GetComponent<Button>().interactable = false);
                btbubblemessage1.onClick.AddListener(() => HintPanel.SetBool("IsTrigger", false));
                btbubblemessage1.onClick.AddListener(() => StartCoroutine("StartDialogue2Coroutine"));

                btbubblemessage1.onClick.AddListener(() => DialogueText1.gameObject.SetActive(false));
                btbubblemessage1.onClick.AddListener(() => DialogueTitle1.gameObject.SetActive(false));
                btbubblemessage1.onClick.AddListener(() => Sprite1.gameObject.SetActive(false));
                btbubblemessage1.onClick.AddListener(() => Sprite2.gameObject.SetActive(false));
            }
            if (btcontinuesentence2 && btSkiptutroial2 && btbubblemessage2 != null)
            {
                btcontinuesentence2.gameObject.SetActive(false);                
                btcontinuesentence2.onClick.AddListener(()=> DisplayNexSentence2());                
                btcontinuesentence2.onClick.AddListener(() => btcontinuesentence2.gameObject.SetActive(false));
                btcontinuesentence2.onClick.AddListener(()=> StartCoroutine("DestroyGameObjectPointerAnswerandQuestiofiledandbtntempshow_coroutine")); 
                btSkiptutroial2.gameObject.SetActive(false);
                btSkiptutroial2.onClick.AddListener(()=> btSkip2_addlistiner());
                btbubblemessage2.gameObject.SetActive(false);
                btbubblemessage2.onClick.AddListener(() => ContentnMessage2_animator.Play("Content_Message_Tutorial_Riddle_TurnBack"));
                btbubblemessage2.onClick.AddListener(() => ContentnMessage3_animator.Play("Content_Message_Tutorial_Riddle_Show"));
                btbubblemessage2.onClick.AddListener(() => Destroy(textSampleAnswer_gameobject));
                btbubblemessage2.onClick.AddListener(() => Destroy(PointerClick_textAnswerspell_gameObject));
                btbubblemessage2.onClick.AddListener(() => StartCoroutine("StartDialogue3Coroutine"));
                btbubblemessage2.onClick.AddListener(() => DialogueText2.gameObject.SetActive(false));
                btbubblemessage2.onClick.AddListener(() => DialogueTitle2.gameObject.SetActive(false));
                btbubblemessage2.onClick.AddListener(() => btcontinuesentence2.gameObject.SetActive(false));
                btbubblemessage2.onClick.AddListener(() => btbubblemessage2.gameObject.SetActive(false));
                btbubblemessage2.onClick.AddListener(() => btSkiptutroial2.gameObject.SetActive(false));
            }            

            if (btcontinuesentence3 && btSkiptutroial3 && btbubblemessage3 != null)
            {
                btcontinuesentence3.gameObject.SetActive(false);
                btcontinuesentence3.onClick.AddListener(()=> Destroy(PointerClick_ImageTimebar_gameObject));
                btcontinuesentence3.onClick.AddListener(()=> DisplayNexSentence3());
                btcontinuesentence3.onClick.AddListener(()=> Sprite3.gameObject.SetActive(false));
                btcontinuesentence3.onClick.AddListener(()=> DialogueTitle3.text = TextTitle6);
                btcontinuesentence3.onClick.AddListener(()=> btcontinuesentence3.gameObject.SetActive(false));
                btSkiptutroial3.gameObject.SetActive(false);
                btSkiptutroial3.onClick.AddListener(()=> btSkip3_addlistiner());
                btbubblemessage3.gameObject.SetActive(false);
                btbubblemessage3.onClick.AddListener(() => ContentnMessage3_animator.Play("Content_Message_Tutorial_Riddle_TurnBack"));
                btbubblemessage3.onClick.AddListener(() => ContentnMessage4_animator.Play("Content_Message_Tutorial_Riddle_Show"));
                btbubblemessage3.onClick.AddListener(() => Destroy(PointerClick_textRounQuestion_gameObject));
                btbubblemessage3.onClick.AddListener(() => DialogueText3.gameObject.SetActive(false));
                btbubblemessage3.onClick.AddListener(() => DialogueTitle3.gameObject.SetActive(false));
                btbubblemessage3.onClick.AddListener(() => btSkiptutroial3.gameObject.SetActive(false));
                btbubblemessage3.onClick.AddListener(() => btcontinuesentence3.gameObject.SetActive(false));
                btbubblemessage3.onClick.AddListener(() => btbubblemessage3.gameObject.SetActive(false));
                btbubblemessage3.onClick.AddListener(() => StartCoroutine("StartDialogue4Coroutine"));
            }
            if (btcontinuesentence4 && btSkiptutroial4 && btbubblemessage4 != null)
            {
                btcontinuesentence4.gameObject.SetActive(false);
                btcontinuesentence4.onClick.AddListener(() => DisplayNexSentence4()); ;
                btcontinuesentence4.onClick.AddListener(() => Sprite4.gameObject.SetActive(false));
                btcontinuesentence4.onClick.AddListener(() => Sprite5.gameObject.SetActive(false));
                btcontinuesentence4.onClick.AddListener(() => btnext.gameObject.SetActive(false));
                btcontinuesentence4.onClick.AddListener(() => btcontinuesentence4.gameObject.SetActive(false));
                btcontinuesentence4.onClick.AddListener(() => Destroy(PointerClick_btnextQuestio_gameObject));
                btbubblemessage4.onClick.AddListener(() => btcontinuesentence4.gameObject.SetActive(false));
                btbubblemessage4.onClick.AddListener(() => DialogueText4.gameObject.SetActive(false));
                btbubblemessage4.onClick.AddListener(() => DialogueTitle4.gameObject.SetActive(false));
                btbubblemessage4.onClick.AddListener(() => btSkiptutroial4.gameObject.SetActive(false));
                btbubblemessage4.onClick.AddListener(() => btbubblemessage4.gameObject.SetActive(false));
                btbubblemessage4.onClick.AddListener(() => btnext.gameObject.SetActive(false));
                btbubblemessage4.onClick.AddListener(() => btProgress.gameObject.SetActive(false));
                btbubblemessage4.onClick.AddListener(() => Sprite6.gameObject.SetActive(false));
                btbubblemessage4.onClick.AddListener(() => Sprite7.gameObject.SetActive(false));
                btbubblemessage4.onClick.AddListener(() => GameProgressPanel_gameobject.gameObject.SetActive(true));
                btbubblemessage4.onClick.AddListener(() => Destroy(PointerClick_btprogressbutton_gameObject));
                btbubblemessage4.onClick.AddListener(() => ContentnMessage4_animator.Play("Content_Message_Tutorial_Riddle_TurnBack"));
                btbubblemessage4.onClick.AddListener(() => StartCoroutine("Show_contentmessage5"));
                btSkiptutroial4.gameObject.SetActive(false);
                btSkiptutroial4.onClick.AddListener(() => btSkip4_addlistiner());
                btbubblemessage4.gameObject.SetActive(false);
            }

            if (btcontinuesentence5 && btSkiptutroial5 && btbubblemessage5 != null)
            {
                btcontinuesentence5.gameObject.SetActive(false);
                //btcontinuesentence5.onClick.AddListener(()=> DisplayNexSentence5());                
                //btcontinuesentence5.onClick.AddListener(()=> Destroy(pointer_Clicktexttime_gameObject));
                //btcontinuesentence5.onClick.AddListener(()=> Destroy(PointerClick_textScore_gameObject));
                //btcontinuesentence5.onClick.AddListener(()=> Destroy(PointerClick_btplayAgain_gameObject));
                //btcontinuesentence5.onClick.AddListener(()=> Destroy(PointerClick_btnextlevel_gameObject));
                //btcontinuesentence5.onClick.AddListener(()=> Destroy(Pointerclick_btreturnhome_gameObject));
                //btcontinuesentence5.onClick.AddListener(()=> btbubblemessage5.gameObject.SetActive(false));
                btcontinuesentence5.onClick.AddListener(()=> btcontinuesentence5.gameObject.SetActive(false));
                btSkiptutroial5.gameObject.SetActive(false);
                btSkiptutroial5.onClick.AddListener(() => btSkip5_addlinter());
                btbubblemessage5.gameObject.SetActive(false);
            }
            if (btbubblemessage6 != null)
            {
               
                
                btbubblemessage6.gameObject.SetActive(false);
                btbubblemessage6.onClick.AddListener(()=> ContentnMessage6_animator.Play("Content_Message_Tutorial_Riddle_TurnBack"));
                btbubblemessage6.onClick.AddListener(()=> btbubblemessage6.gameObject.SetActive(false));
                btbubblemessage6.onClick.AddListener(()=> DialogueTitle6.gameObject.SetActive(false));
                btbubblemessage6.onClick.AddListener(()=> DialogueText6.gameObject.SetActive(false));
                btbubblemessage6.onClick.AddListener(() => DialogueTitle6.text = "");
                btbubblemessage6.onClick.AddListener(() => DialogueText6.text = "");
                btbubblemessage6.onClick.AddListener(() => StartCoroutine("leavingTutorialRiddle"));
            }
            if (textSampleAnswer_gameobject != null)
            {
                textSampleAnswer_gameobject.gameObject.SetActive(false);
            }
            
        }
        else
        {
            DialogueManager_Riddle.GetComponent<DialogueManagerRiddleGame>().enabled = false;
           (DialogueManager_Riddle.GetComponent<DialogueManagerRiddleGame>() as MonoBehaviour).enabled = false;
            Destroy(Tutorial_for_newcommer);
        }



    }
    //Update_ City_Hall
    void Update()
    {
        panel_playersavesysteml = GameObject.Find("PlayerSaveSystem");

        if (panel_playersavesysteml.gameObject.GetComponent<PlayerSaveSystem>().Tutiroal_BoolRiddleScene == true)
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
            ContentnMessage1_animator.Play("Content_Message_Tutorial_Riddle_Show");
      
        }
    

        if (DialogueText1.text.Contains(containtext) && bool_btcontinuesentence1 == false)
        {
            bool_btcontinuesentence1 = true;
            btcontinuesentence1.gameObject.SetActive(true);
        }

       
        if (DialogueText1.text.Contains(containtext2) && bool_pointerclickhintbutton == false)
        {
            bool_pointerclickhintbutton = true;
            Sprite1.gameObject.SetActive(true);
            StartCoroutine("ShowPointer_hintbt");
        }

        if (DialogueText1.text.Contains(containtext3) && bool_pointerclickhintpanel == false)
        {
            bool_pointerclickhintpanel = true;
            Sprite2.gameObject.SetActive(true);
            StartCoroutine("ShowPointer_hintpanel");
            HintPanel.SetBool("IsTrigger", true);
        }
        if (DialogueText1.text.Contains(containtext4) && bool_btmessage1 == false)
        {
            bool_btmessage1 = true;
            btcontinuesentence1.gameObject.SetActive(false);
            btbubblemessage1.gameObject.SetActive(true);
        }

        if (DialogueText2.text.Contains(containtext5) && bool_pointerclickQuestionfield == false )
        {
            bool_pointerclickQuestionfield = true;
            StartCoroutine("ShowPointer_QuestioField");
        }

        if (DialogueText2.text.Contains(containtext6) && bool_pointerclickAnswerBottom == false)
        {
            bool_pointerclickAnswerBottom = true;
            DialogueTitle2.text = TextTitle4;
            StartCoroutine("ShowClick_btTemp");
            Destroy(PointerClick_QuestionField_gameObject);
            StartCoroutine("ShowPointer_AnswwerBottom");
        }

        if (DialogueText2.text.Contains(containtext7) && bool_pointertextnswerspeel == false)
        {
            bool_pointertextnswerspeel = true;
            StartCoroutine("ShowPointer_textAnswerSpell");
        }
        if (DialogueText2.text.Contains(containtext8) && bool_btcontinuesentence2 == false)
        {
            bool_btcontinuesentence2 = true;
            btcontinuesentence2.gameObject.SetActive(true);
        }
        if (DialogueText2.text.Contains(containtext9)&& bool_btmessageandbtconsentence2 == false)
        {
            bool_btmessageandbtconsentence2 = true;
            btcontinuesentence2.gameObject.SetActive(false);
            btbubblemessage2.gameObject.SetActive(true);
        }
        if (DialogueText3.text.Contains(containtext10) && bool_pointerTimer == false)
        {
            bool_pointerTimer = true;
            StartCoroutine("ShowPointer_TimerBar");
            Sprite3.gameObject.SetActive(true);            
        }
        if (DialogueText3.text.Contains(containtext10) && bool_stoptheTime == false)
        {
            StartCoroutine("Timer_of_game");
        }
        if (DialogueText3.text.Contains(containtext11) && bool_pointerTextQuestionCount == false)
        {
            bool_pointerTextQuestionCount = true;
            StartCoroutine("ShowPointer_textQuestionRound");
        }
        if (DialogueText3.text.Contains(containtext12) && bool_btcoontinue3 == false)
        {
            bool_btcoontinue3 = true;
            btcontinuesentence3.gameObject.SetActive(true);
        }
        if (DialogueText3.text.Contains(containtext13)&& bool_btbubblemessage3 == false)
        {
            bool_btbubblemessage3 = true;
            btbubblemessage3.gameObject.SetActive(true);
        }
        if (DialogueText4.text.Contains(containtext14) && bool_pointerclickbtNext == false)
        {
            bool_pointerclickbtNext = true;
            Sprite4.gameObject.SetActive(true);
            btnext.gameObject.SetActive(true);
            StartCoroutine("ShowPointer_btNextbutton");
        }
        if (DialogueText4.text.Contains(containtext15) && bool_pointerclickbtProgress == false)
        {
            bool_pointerclickbtProgress = true;
            Sprite5.gameObject.SetActive(true);
        }
        if (DialogueText4.text.Contains(containtext16) && bool_btcontinuesentence4 == false)
        {
            bool_btcontinuesentence4 = true;
            btcontinuesentence4.gameObject.SetActive(true);
        }
        if (DialogueText4.text.Contains(containtext17)&& bool_Sprite6 == false)
        {
            bool_Sprite6 = true;
            Sprite6.gameObject.SetActive(true);
        }
        if (DialogueText4.text.Contains(containtext18) && bool_Pointerclick_btprogress == false)
        {
            bool_Pointerclick_btprogress = true;
            Sprite7.gameObject.SetActive(true);
            btProgress.gameObject.SetActive(true);
            StartCoroutine("ShowPointer_btProgressbutton");
        }
        if (DialogueText4.text.Contains(containtext19) && bool_btbubblemessage4 == false)
        {
            bool_btbubblemessage4 = true;
            btbubblemessage4.gameObject.SetActive(true);

        }
        if (DialogueText5.text.Contains(containtext20) && bool_btcontinuesentence5 == false)
        {
            bool_btcontinuesentence5 = true;
            btcontinuesentence5.gameObject.SetActive(true);
            btcontinuesentence5.onClick.AddListener(() => StartCoroutine("DisableContentMessage5ThenShowGameProgress1"));

        }
        if (DialogueText5.text.Contains(containtext21) && bool_btcontinuesentence5 == true)
        {
            bool_btcontinuesentence5 = false;
            btcontinuesentence5.gameObject.SetActive(true);
            btcontinuesentence5.onClick.AddListener(()=> StartCoroutine("DisableContentMessage5ThenShowGameProgress2"));

        }
        if (DialogueText5.text.Contains(containtext22) && bool_btcontinuesentence5 == false)
        {
            bool_btcontinuesentence5 = true;
            btcontinuesentence5.onClick.AddListener(() => DisplayNexSentence5());
            btcontinuesentence5.onClick.AddListener(() => btcontinuesentence5.onClick.RemoveAllListeners());
            btcontinuesentence5.gameObject.SetActive(true);
        }
        if (DialogueText5.text.Contains(containtext23) && bool_btcontinuesentence5 == true)
        {
            bool_btcontinuesentence5 = false;
            btcontinuesentence5.gameObject.SetActive(true);
            btcontinuesentence5.onClick.AddListener(() => StartCoroutine("DisableContentMessage5ThenShowGameProgress3"));
        }
        if (DialogueText5.text.Contains(containtext24) && bool_btcontinuesentence5 == false)
        {
            bool_btcontinuesentence5 = true;
            btcontinuesentence5.gameObject.SetActive(true);
            btcontinuesentence5.onClick.AddListener(() => StartCoroutine("DisableContentMessage5ThenShowGameProgress4"));
        }
        if (DialogueText5.text.Contains(containtext25) && bool_btcontinuesentence5 == true)
        {
            bool_btcontinuesentence5 = false;
            btbubblemessage5.gameObject.SetActive(true);
            btbubblemessage5.onClick.AddListener(() => StartCoroutine("DisableContentMessage5ThenShowGameProgress5"));
        }
        if (DialogueText6.text.Contains(containtext26))
        {
            btbubblemessage6.gameObject.SetActive(true);
            
        }

    }

    //Void_Village
    void loading()
    {
        float fill = (float)Float_Timer_of_game / 30f;
        Image_Timbar.fillAmount = fill;    
    }
    void ContentMessage2_transform_Method()
    {
        RectTransform rectTransform = ContentMessage2_gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector3(58f, 30f, 0f);

    }    
    void btSkip1_addlistiner()
    {
        ContentnMessage1_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        Destroy(PointerClick_bthint_gameObject);
        Destroy(PointerClick_hintpanel_gameObject);
        DialogueText1.gameObject.SetActive(false);
        DialogueText1.text = "";
        DialogueTitle1.gameObject.SetActive(false);
        DialogueTitle1.text = "";
        HintPanel.SetBool("IsTrigger", false);
        Sprite1.gameObject.SetActive(false);
        Sprite2.gameObject.SetActive(false);
        StartCoroutine("StartDialogue2Coroutine");
        btSkiptutroial1.gameObject.SetActive(false);
        btbubblemessage1.gameObject.SetActive(false);
        btcontinuesentence1.gameObject.SetActive(false);
        bthint.GetComponent<Button>().interactable = false;
        ContentnMessage2_animator.Play("Content_Message_Tutorial_Riddle_Show");
    }
    void btSkip2_addlistiner()
    {
        ContentnMessage2_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        StartCoroutine("DestroyGameObjectPointerAnswerandQuestiofiledandbtntempshow_coroutine");
        ContentnMessage3_animator.Play("Content_Message_Tutorial_Riddle_Show");
        Destroy(textSampleAnswer_gameobject);
        Destroy(PointerClick_QuestionField_gameObject);
        Destroy(PointerClick_AnswerBttom_gameObject);
        Destroy(PointerClick_textAnswerspell_gameObject);
        StartCoroutine("StartDialogue3Coroutine");
        DialogueText2.gameObject.SetActive(false);
        DialogueTitle2.gameObject.SetActive(false);
        DialogueTitle2.text = "";
        DialogueText2.text = "";
        btcontinuesentence2.gameObject.SetActive(false);
        btbubblemessage2.gameObject.SetActive(false);
        btSkiptutroial2.gameObject.SetActive(false);
    }
    void btSkip3_addlistiner()
    {
        ContentnMessage3_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        ContentnMessage4_animator.Play("Content_Message_Tutorial_Riddle_Show");
        Destroy(PointerClick_ImageTimebar_gameObject);
        Destroy(PointerClick_textRounQuestion_gameObject);
        DialogueText3.gameObject.SetActive(false);
        DialogueTitle3.gameObject.SetActive(false);
        DialogueTitle3.text = "";
        DialogueText3.text = "";
        StartCoroutine("StartDialogue4Coroutine");
        Sprite3.gameObject.SetActive(false);
        btSkiptutroial3.gameObject.SetActive(false);
        btbubblemessage3.gameObject.SetActive(false);
        btcontinuesentence3.gameObject.SetActive(false);
    }
    void btSkip4_addlistiner()
    {
        btProgress.gameObject.SetActive(false);
        btSkiptutroial4.gameObject.SetActive(false);
        btbubblemessage4.gameObject.SetActive(false);
        btcontinuesentence4.gameObject.SetActive(false);
        btcontinuesentence4.gameObject.SetActive(false);
        btnext.gameObject.SetActive(false);
        btnext.gameObject.SetActive(false);
        ContentnMessage4_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        Destroy(PointerClick_btnextQuestio_gameObject);
        Destroy(PointerClick_btprogressbutton_gameObject);
        DialogueText4.gameObject.SetActive(false);
        DialogueText4.text = "";
        DialogueTitle4.gameObject.SetActive(false);
        DialogueTitle4.text = "";
        StartCoroutine("Show_contentmessage5");
        Sprite4.gameObject.SetActive(false);
        Sprite5.gameObject.SetActive(false);
        Sprite6.gameObject.SetActive(false);
        Sprite7.gameObject.SetActive(false);
        GameProgressPanel_gameobject.gameObject.SetActive(true);
    }
    void btSkip5_addlinter()
    {
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        ContentnMessage6_animator.Play("Content_Message_Tutorial_Riddle_Show");
        btSkiptutroial5.gameObject.SetActive(false);
        btcontinuesentence5.gameObject.SetActive(false);
        btbubblemessage5.gameObject.SetActive(false);
        DialogueText5.gameObject.SetActive(false);
        DialogueText5.text = "";
        DialogueTitle5.gameObject.SetActive(false);
        DialogueTitle5.text = "";
        Destroy(PointerClick_btplayAgain_gameObject);
        Destroy(PointerClick_textScore_gameObject);
        Destroy(pointer_Clicktexttime_gameObject);
        Destroy(PointerClick_btAnswerreview_gameObject);
        Destroy(PointerClick_btnextlevel_gameObject);
        Destroy(Pointerclick_btreturnhome_gameObject);
        GameProgressPanel_gameobject.gameObject.SetActive(false);
        StartCoroutine("StartDialogue6Coroutine");
    }

    //Public_Village
    public void StartDialogue1(DialogueRiddle dialogue)
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

    public void StartDialogue2(DialogueRiddle dialogue)
    {

        sentences2.Clear();

        foreach (string sentence in dialogue.sentences1)
        {
            sentences2.Enqueue(sentence);
        }

        DisplayNexSentence2();
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
    public void StartDialogue3(DialogueRiddle dialogue)
    {

        sentences3.Clear();

        foreach (string sentence in dialogue.sentences2)
        {
            sentences3.Enqueue(sentence);
        }

        DisplayNexSentence3();
    }

    public void DisplayNexSentence3()
    {
        if (sentences3.Count == 0)
        {

            return;
        }

        string sentence = sentences3.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence3(sentence));
    }

    public void StartDialogue4(DialogueRiddle dialogue)
    {

        sentences4.Clear();

        foreach (string sentence in dialogue.sentences3)
        {
            sentences4.Enqueue(sentence);
        }

        DisplayNexSentence4();
    }

    public void DisplayNexSentence4()
    {
        if (sentences4.Count == 0)
        {

            return;
        }

        string sentence = sentences4.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence4(sentence));
    }
    public void StartDialogue5(DialogueRiddle dialogue)
    {

        sentences5.Clear();

        foreach (string sentence in dialogue.sentences4)
        {
            sentences5.Enqueue(sentence);
        }

        DisplayNexSentence5();
    }

    public void DisplayNexSentence5()
    {
        if (sentences5.Count == 0)
        {

            return;
        }

        string sentence = sentences5.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence5(sentence));
    }

    public void StartDialogue6(DialogueRiddle dialogue)
    {

        sentences6.Clear();

        foreach (string sentence in dialogue.sentences5)
        {
            sentences6.Enqueue(sentence);
        }

        DisplayNexSentence6();
    }

    public void DisplayNexSentence6()
    {
        if (sentences6.Count == 0)
        {

            return;
        }

        string sentence = sentences6.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence6(sentence));
    }


    public void Assuring()
    {

        panel_playersavesysteml.GetComponent<PlayerSaveSystem>().Tutiroal_BoolMainScene = false;
        panel_playersavesysteml.GetComponent<PlayerSaveSystem>().SaveGame();
        SceneManager.LoadScene("MemoryGame1");
    }
   

    //IEnumator_Viilage
    IEnumerator TypeSentence(string sentence)
    {
        DialogueText1.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText1.text += letter;
            yield return null;

        }
    }
    IEnumerator TypeSentence2(string sentence)
    {
        DialogueText2.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText2.text += letter;
            yield return null;

        }
    }
    IEnumerator TypeSentence3(string sentence)
    {
        DialogueText3.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText3.text += letter;
            yield return null;

        }
    }
    IEnumerator TypeSentence4(string sentence)
    {
        DialogueText4.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText4.text += letter;
            yield return null;

        }
    }
     IEnumerator TypeSentence5(string sentence)
    {
        DialogueText5.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText5.text += letter;
            yield return null;

        }
    }
    IEnumerator TypeSentence6(string sentence)
    {
        DialogueText6.text = " ";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText6.text += letter;
            yield return null;

        }
    }


    IEnumerator StartDialogue1Coroutine()
    {
        yield return new WaitForSeconds(1f);
        StartDialogue1(dialogue);
        DialogueText1.gameObject.SetActive(true);
        DialogueTitle1.gameObject.SetActive(true);
        btSkiptutroial1.gameObject.SetActive(true);
    }

    IEnumerator StartDialogue2Coroutine()
    {
        yield return new WaitForSeconds(1f);
        StartDialogue2(dialogue);
        DialogueText2.gameObject.SetActive(true);
        DialogueTitle2.gameObject.SetActive(true);
        btSkiptutroial2.gameObject.SetActive(true);
    }
    IEnumerator StartDialogue3Coroutine()
    {
        yield return new WaitForSeconds(1f);
        StartDialogue3(dialogue);
        DialogueText3.gameObject.SetActive(true);
        DialogueTitle3.gameObject.SetActive(true);
        btSkiptutroial3.gameObject.SetActive(true);
    }
    IEnumerator StartDialogue4Coroutine()
    {
        yield return new WaitForSeconds(1f);
        StartDialogue4(dialogue);
        DialogueText4.gameObject.SetActive(true);
        DialogueTitle4.gameObject.SetActive(true);
        btSkiptutroial4.gameObject.SetActive(true);
    }
    IEnumerator StartDialogue5Coroutine()
    {
        yield return new WaitForSeconds(1f);
        StartDialogue5(dialogue);
        DialogueText5.gameObject.SetActive(true);
        DialogueTitle5.gameObject.SetActive(true);
        btSkiptutroial5.gameObject.SetActive(true);
    }

    IEnumerator StartDialogue6Coroutine()
    {
        yield return new WaitForSeconds(1f);
        StartDialogue6(dialogue);
        DialogueText6.gameObject.SetActive(true);
        DialogueTitle6.gameObject.SetActive(true);
        
    }

    IEnumerator ShowPointer_hintbt()
    {
        yield return new WaitForSeconds(1.4f);
        PointerClick_bthint.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_bthint.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_bthint.Play("Pointer_guidde_ClickButtonPlay_idle");
        yield return new WaitForSeconds(0.01f);
        bthint.gameObject.SetActive(true);
        bthint.GetComponent<Button>().interactable = true;
    }

    IEnumerator ShowPointer_hintpanel()
    {
        yield return new WaitForSeconds(1.4f);
        PointerClick_hintpanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_hintpanel.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_hintpanel.Play("Pointer_guidde_ClickButtonPlay_idle");
    }
    IEnumerator ShowPointer_QuestioField()
    {
        yield return new WaitForSeconds(1.4f);
        PointerClick_QuestionField.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_QuestionField.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_QuestionField.Play("Pointer_guidde_ClickButtonPlay_idle");
    }
    IEnumerator ShowPointer_AnswwerBottom()
    {
        yield return new WaitForSeconds(1.4f);
        PointerClick_AnswerBottom.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_AnswerBottom.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_AnswerBottom.Play("Pointer_guidde_ClickButtonPlay_idle");
    }

    IEnumerator ShowPointer_TimerBar()
    {
        yield return new WaitForSeconds(1.4f);
        PointerClick_ImageTimebar.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_ImageTimebar.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_ImageTimebar.Play("Pointer_guidde_ClickButtonPlay_idle");
    }
    IEnumerator ShowPointer_textQuestionRound()
    {
        yield return new WaitForSeconds(1.4f);
        PointerClick_textRounQuestion.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_textRounQuestion.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_textRounQuestion.Play("Pointer_guidde_ClickButtonPlay_idle");
    }

    IEnumerator ShowPointer_btNextbutton()
    {
        yield return new WaitForSeconds(1.4f);
        PointerClick_btnextQuestio.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_btnextQuestio.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_btnextQuestio.Play("Pointer_guidde_ClickButtonPlay_idle");
    }
    IEnumerator ShowPointer_btProgressbutton()
    {
        yield return new WaitForSeconds(1.4f);
        PointerClick_btprogressbutton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_btprogressbutton.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_btprogressbutton.Play("Pointer_guidde_ClickButtonPlay_idle");
    }
    IEnumerator ShowPointer_btAnswerReview()
    {
        yield return new WaitForSeconds(1.4f);
        PointerClick_btAnswerreview.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_btAnswerreview.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_btAnswerreview.Play("Pointer_guidde_ClickButtonPlay_idle");
    }
    
    IEnumerator ShowPointer_textScore()
    { 
        yield return new WaitForSeconds(1.4f);
        PointerClick_textScore.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_textScore.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_textScore.Play("Pointer_guidde_ClickButtonPlay_idle");
    }
    IEnumerator ShowPointer_textTime()
    { 
        yield return new WaitForSeconds(1.4f);
        pointer_Clicktexttime.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        pointer_Clicktexttime.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        pointer_Clicktexttime.Play("Pointer_guidde_ClickButtonPlay_idle");
    }
     IEnumerator ShowPointer_btPlayAgain()
    { 
        yield return new WaitForSeconds(1.4f);
        PointerClick_btplayAgain.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_btplayAgain.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_btplayAgain.Play("Pointer_guidde_ClickButtonPlay_idle");
    }
    IEnumerator ShowPointer_btNextlevel()
    { 
        yield return new WaitForSeconds(1.4f);
        PointerClick_btnextlevel.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_btnextlevel.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_btnextlevel.Play("Pointer_guidde_ClickButtonPlay_idle");
    }

    IEnumerator ShowPointer_btReturnHome()
    { 
        yield return new WaitForSeconds(1.4f);
        Pointerclick_btreturnhome.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Pointerclick_btreturnhome.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        Pointerclick_btreturnhome.Play("Pointer_guidde_ClickButtonPlay_idle");
    }

    IEnumerator ShowPointer_textAnswerSpell()
    {
        ContentMessage2_transform_Method();
        RectTransform rectTransform = textSampleAnswer_gameobject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector3(-59f, -259, 0f);
        textSampleAnswer_gameobject.gameObject.SetActive(true);
        textSampleAnswer_gameobject.GetComponent<Animator>().Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        textSampleAnswer_gameobject.GetComponent<Animator>().Play("Pointer_guidde_ClickButtonPlay_idle");
        yield return new WaitForSeconds(1.4f);
        PointerClick_textAnswerspell.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PointerClick_textAnswerspell.Play("Pointer_guidde_ClickButtonPlay_ShowUp");
        yield return new WaitForSeconds(0.3f);
        PointerClick_textAnswerspell.Play("Pointer_guidde_ClickButtonPlay_idle");       
    }



    IEnumerator bthint_coroutine()
    {
        bthint.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(0.01f);
        bthint.gameObject.SetActive(false);
    }

    IEnumerator ShowClick_btTemp()
    {
        foreach (GameObject item in list_btTemp)
        {
            //yield return new WaitForSeconds(1.4f);
            item.gameObject.SetActive(true);
            //yield return new WaitForSeconds(0.3f);
            item.GetComponent<Animator>().Play("Pointer_guidde_ClickButtonPlay_ShowUp");
            //yield return new WaitForSeconds(0.3f);
            item.GetComponent<Animator>().Play("Pointer_guidde_ClickButtonPlay_idle");
        }
        yield return null;
    }

    IEnumerator DestroyGameObjectPointerAnswerandQuestiofiledandbtntempshow_coroutine()
    {
        yield return new WaitForSeconds(0.01f);
        foreach (GameObject item in list_btTemp)
        {
            Destroy(item);
        }
        yield return new WaitForSeconds(0.01f);
        list_btTemp.Clear();
        Destroy(PointerClick_AnswerBttom_gameObject);
    }

    IEnumerator Timer_of_game()
    {
        yield return new WaitForSeconds(1f);
        Float_Timer_of_game -= Time.deltaTime;
        Image_Timbar = GameObject.Find("TimerIMage").GetComponent<Image>();
        loading();
        TextTimer = GameObject.Find("Time").GetComponent<Text>();
        TextTimer.text = Mathf.Round(Float_Timer_of_game).ToString();
        if (Mathf.Round(Float_Timer_of_game) == 0)
        {
            Float_Timer_of_game = 0f;
            bool_stoptheTime = true;
        }
    }
    IEnumerator Show_contentmessage5()
    {
        yield return new WaitForSeconds(1f);
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        StartCoroutine("StartDialogue5Coroutine");
    }
    IEnumerator DisableContentMessage5ThenShowGameProgress1()
    {
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        DialogueText5.gameObject.SetActive(false);
        DialogueTitle5.gameObject.SetActive(false);
        btSkiptutroial5.gameObject.SetActive(false);
        btcontinuesentence5.gameObject.SetActive(false);
        btbubblemessage5.gameObject.SetActive(false);
        btcontinuesentence5.onClick.RemoveAllListeners();
        yield return new WaitForSeconds(0.3f);
        //ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        StartCoroutine("ShowPointer_textScore");
        StartCoroutine("ShowPointer_textTime");
        yield return new WaitForSeconds(3f);
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        Destroy(PointerClick_textScore_gameObject);
        Destroy(pointer_Clicktexttime_gameObject);
        yield return new WaitForSeconds(1f);
        DialogueTitle5.gameObject.SetActive(true);
        DialogueText5.gameObject.SetActive(true);
        btSkiptutroial5.gameObject.SetActive(true);
        DisplayNexSentence5();
    }
      IEnumerator DisableContentMessage5ThenShowGameProgress2()
    {
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        DialogueText5.gameObject.SetActive(false);
        DialogueTitle5.gameObject.SetActive(false);
        btSkiptutroial5.gameObject.SetActive(false);
        btcontinuesentence5.gameObject.SetActive(false);
        btbubblemessage5.gameObject.SetActive(false);
        btcontinuesentence5.onClick.RemoveAllListeners();
        yield return new WaitForSeconds(0.3f);
        //ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        StartCoroutine("ShowPointer_btAnswerReview");
        btAnswerReview.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        Destroy(PointerClick_btAnswerreview_gameObject);
        yield return new WaitForSeconds(1f);
        DialogueTitle5.gameObject.SetActive(true);
        DialogueText5.gameObject.SetActive(true);
        btSkiptutroial5.gameObject.SetActive(true);
        DisplayNexSentence5();
    }
     IEnumerator DisableContentMessage5ThenShowGameProgress3()
    {
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        DialogueText5.gameObject.SetActive(false);
        DialogueTitle5.gameObject.SetActive(false);
        btSkiptutroial5.gameObject.SetActive(false);
        btcontinuesentence5.gameObject.SetActive(false);
        btbubblemessage5.gameObject.SetActive(false);
        btcontinuesentence5.onClick.RemoveAllListeners();
        yield return new WaitForSeconds(0.3f);
        //ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        StartCoroutine("ShowPointer_btPlayAgain");
        btPlayagain.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        Destroy(PointerClick_btplayAgain_gameObject);
        yield return new WaitForSeconds(1f);
        DialogueTitle5.gameObject.SetActive(true);
        DialogueText5.gameObject.SetActive(true);
        btSkiptutroial5.gameObject.SetActive(true);
        DisplayNexSentence5();
    }
    IEnumerator DisableContentMessage5ThenShowGameProgress4()
    {
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        DialogueText5.gameObject.SetActive(false);
        DialogueTitle5.gameObject.SetActive(false);
        btSkiptutroial5.gameObject.SetActive(false);
        btcontinuesentence5.gameObject.SetActive(false);
        btbubblemessage5.gameObject.SetActive(false);
        btcontinuesentence5.onClick.RemoveAllListeners();
        yield return new WaitForSeconds(0.3f);
        //ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        StartCoroutine("ShowPointer_btNextlevel");
        btnextlevel.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        Destroy(PointerClick_btnextlevel_gameObject);
        yield return new WaitForSeconds(1f);
        DialogueTitle5.gameObject.SetActive(true);
        DialogueText5.gameObject.SetActive(true);
        btSkiptutroial5.gameObject.SetActive(true);
        DisplayNexSentence5();
    }IEnumerator DisableContentMessage5ThenShowGameProgress5()
    {
        ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_TurnBack");
        DialogueText5.gameObject.SetActive(false);
        DialogueTitle5.gameObject.SetActive(false);
        btSkiptutroial5.gameObject.SetActive(false);
        btcontinuesentence5.gameObject.SetActive(false);
        btbubblemessage5.gameObject.SetActive(false);
        btcontinuesentence5.onClick.RemoveAllListeners();
        yield return new WaitForSeconds(0.3f);
        //ContentnMessage5_animator.Play("Content_Message_Tutorial_Riddle_Show");
        StartCoroutine("ShowPointer_btReturnHome");
        btReturnchome.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        ContentnMessage6_animator.Play("Content_Message_Tutorial_Riddle_Show");
        Destroy(Pointerclick_btreturnhome_gameObject);
        GameProgressPanel_gameobject.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        DialogueText6.gameObject.SetActive(true);
        DialogueTitle6.gameObject.SetActive(true);
        StartDialogue6(dialogue);
        
    }
    IEnumerator leavingTutorialRiddle()
    {
        panel_playersavesysteml.GetComponent<PlayerSaveSystem>().Tutiroal_BoolRiddleScene = false;
        panel_playersavesysteml.GetComponent<PlayerSaveSystem>().SaveGame();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameplayLevel1");

    }

    //Bot


}
