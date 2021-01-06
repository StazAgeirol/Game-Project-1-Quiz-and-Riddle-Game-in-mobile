using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MemoryGameContol5 : MonoBehaviour
{
    //Top
    private bool bool_pause = false, TurnitBack = false, TurnNow, Bool_correctanswer = false, bool_gameresult_panel = false, bool_AnswerReview_panel = false, bool_Image_Correct = false, bool_Image_Wrong;
    private bool bool_btresult = false, bool_btNext, bool_nextlevel = false, bool_btreturnhome = false, bool_btplayagain = false, bool_btclosereview_panel;
    private bool bool_CanBeRemoveQuestion = false, bool_nextround_animators_for_prefab = false, bool_content_btnextlevel = false;
    private bool bool_timerofgame = false, times_up = true, StartQuestion = false, bool_Play_clockSound = false, DestroyCorrecteffect_bool = false;
    private Queue<int> QueueAnimator;
    private TMP_Text TextQuestionCount, TextAnswerSpell, textCorrectandWrong, TextQuestionField;
    private Text TextTimer, textoveralltime, textnumscore, textstringpoint;
    private int firstGuessIndex, randomNum, IntQuestionCount = 0, intTotalQuestion = 6, int_num_round = 0,   int_num_totalRound = 6, int_numericalTotalAnswer = 0;
    private int Int_score = 0;
    private List<GameObject> btns = new List<GameObject>(); // Default don't toucht it
    private List<string> randStr = new List<string>();
    private List<int> TempAnimator = new List<int>();
    private List<GameObject> AnswerItem = new List<GameObject>();
    List<QuestionTemplateMG> Questions;
    private IEnumerator currentprocess;
    private float Float_Timer_of_game = 30f, secondsCount, hourCount , minuteCount;

    [SerializeField]
    private ParticleSystem StarEffect; // Drag and Drop Gameobject

    [SerializeField]
    private GameObject btn; // Drag and Drop Gameobject

    [SerializeField]
    private ParticleSystem effect_1, effect_2; // Drag and Drop Gameobject
        



    private string ClickAnnswer, randomListString;
    private Transform PuzzleField, ParticleContainer, particle_win_container; // Gameobject Find
    private Image Image_Correct, Image_Wrong, Image_Timbar;
    private ParticleSystem Effect_Background;
    private Button btProgress, btNext, btNextlevel, btplayagain, btAnswerReview, btreturnhome, btcloseAnswerreview, btTurnback;
    private GameObject Panel_gameresltpanel, panel_AnswerReview, content_image_btnextlevel, AnswertextPrefab, panel_playersavesystem;
    private Animator Aniamtor_Achievement_panel_notify;
    private AudioSource Sound_interactive, Sound_Big_Ui, Sound_Correct, Sound_Wrong, Sound_Win, Sound_close, Sound_timeClock, Sound_times_up;

    public AudioClip ClipInteractive, ClipBug_Ui, ClipCorrect, ClipWrong, ClipWin, Clipclose, Cliptimeclock, ClipTimes_up;
    private Animator Ready_Panel;
    private Button btReady;

    //Start
    void Start()
    {
        //btbot
        btProgress = GameObject.Find("btProgress").GetComponent<Button>();
        btProgress.onClick.AddListener(() => ProgressButtonAddlistiner());
        btProgress.onClick.AddListener(() => SoundBig_ui_addlistiner());
        btNext = GameObject.Find("btNextQuestion").GetComponent<Button>();
        btNext.onClick.AddListener(() => InitializingQuestion());
        btNext.onClick.AddListener(() => SoundInteractive_ui_addlistiner());
        btAnswerReview = GameObject.Find("btanswerreview").GetComponent<Button>();
        btAnswerReview.onClick.AddListener(() => ShowAnswerReview_panelAddlistiner());
        btAnswerReview.onClick.AddListener(() => SoundInteractive_ui_addlistiner());
        btcloseAnswerreview = GameObject.Find("btCloseAnswerReview").GetComponent<Button>();
        btcloseAnswerreview.onClick.AddListener(() => CloseAnswerReview_Panel());
        btTurnback = GameObject.Find("btTurnBack").GetComponent<Button>();
        btcloseAnswerreview.onClick.AddListener(() => SoundClose());
        btNextlevel = GameObject.Find("btnextlevl").GetComponent<Button>();
        btNextlevel.onClick.AddListener(() => NextlevelbtAddlistiner());
        btNextlevel.onClick.AddListener(() => SoundInteractive_ui_addlistiner());
        btplayagain = GameObject.Find("btplayagain").GetComponent<Button>();
        btplayagain.onClick.AddListener(() => PlayagainAddlistiner());
        btplayagain.onClick.AddListener(() => SoundInteractive_ui_addlistiner());
        btreturnhome = GameObject.Find("btreturnhome").GetComponent<Button>();
        btreturnhome.onClick.AddListener(() => ReturnHomeAddlistiner());
        btreturnhome.onClick.AddListener(() => SoundInteractive_ui_addlistiner());
        //bt Top
        Panel_gameresltpanel = GameObject.Find("GameResultPanel");
        panel_AnswerReview = GameObject.Find("panel_ShowAnswer");
        content_image_btnextlevel = GameObject.Find("content_image_btnexlevel");
        AnswertextPrefab = GameObject.Find("TextAnswertReview");
        panel_playersavesystem = GameObject.Find("PlayerSaveSystem");
        textoveralltime = GameObject.Find("TextoverAlltime").GetComponent<Text>();
        textnumscore = GameObject.Find("textScoreNum").GetComponent<Text>();
        textstringpoint = GameObject.Find("textPointString").GetComponent<Text>();
        particle_win_container = GameObject.Find("Effect_OnWinLevel").GetComponent<Transform>();
        Aniamtor_Achievement_panel_notify = GameObject.Find("Achievement_notify_panel").GetComponent<Animator>();
        Effect_Background = GameObject.Find("CFX3_Flying_Ember_Upward").GetComponent<ParticleSystem>();
        Sound_Big_Ui = GameObject.Find("Sound_Ui_big").GetComponent<AudioSource>();
        Sound_close = GameObject.Find("Sound_Close").GetComponent<AudioSource>();
        Sound_Correct = GameObject.Find("Sound_Correct").GetComponent<AudioSource>();
        Sound_interactive = GameObject.Find("Sound_interactive").GetComponent<AudioSource>();
        Sound_timeClock = GameObject.Find("Sound_TimerClock").GetComponent<AudioSource>();
        Sound_times_up = GameObject.Find("Sound_Times Up").GetComponent<AudioSource>();
        Sound_Win = GameObject.Find("Sound_Win").GetComponent<AudioSource>();
        Sound_Wrong = GameObject.Find("Sound_Wrong").GetComponent<AudioSource>();

        Sound_timeClock.clip = Cliptimeclock;
        Sound_Big_Ui.clip = ClipBug_Ui;
        Sound_close.clip = Clipclose;
        Sound_interactive.clip = ClipInteractive;
        Sound_times_up.clip = ClipTimes_up;
        Sound_Correct.clip = ClipCorrect;
        Sound_Wrong.clip = ClipWrong;
        if (Panel_gameresltpanel && panel_AnswerReview && btNextlevel && btreturnhome && btplayagain && content_image_btnextlevel != null)
        {
            bool_gameresult_panel = false;
            bool_AnswerReview_panel = false;
            bool_nextlevel = false;
            bool_content_btnextlevel = false;
        }
        if (btTurnback != null)
        {
            btTurnback.gameObject.SetActive(false);
            btTurnback.onClick.AddListener(() => btTurnback.gameObject.SetActive(false));
            btTurnback.onClick.AddListener(() => StopCoroutine("TurnPuzzleButtonBack"));
            btTurnback.onClick.AddListener(() => StopCoroutine("CoroutineCorrectandWrong"));
            btTurnback.onClick.AddListener(() => StartCoroutine("TurnPuzzleButtonBack_onTap"));
            btTurnback.onClick.AddListener(() => StartCoroutine("CoroutineCorrectandWrong_OnTap"));
        }
        List<string> list_string = new List<string>();
        list_string.Add("Wrong try again");
        list_string.Add("Incorrect do it again");
        list_string.Add("You spell it wrong, almost there");
        list_string.Add("You almost got it, try again");
         randomListString = list_string[Random.Range(0, list_string.Count)];

        QueueAnimator = new Queue<int>();
        //QueueText = new Queue<int>();
        Questions = new List<QuestionTemplateMG>();
        Questions.Add(new QuestionTemplateMG(1, "I am the breath of relief and depression. What am I?", "SIGH", 30f));
        Questions.Add(new QuestionTemplateMG(2, "What belongs to you, but other people use it more than you?", "NAME", 30f));
        Questions.Add(new QuestionTemplateMG(3, "What five long word become shorter when you add two letters", "SHORT", 30f));
        Questions.Add(new QuestionTemplateMG(4, "What is so fragile, even speaking its name will break it?", "SILENCE", 60f));
        Questions.Add(new QuestionTemplateMG(5, "The more you take, the more you leave behind. What am I? ", "FOOTSTEP", 60f));
        Questions.Add(new QuestionTemplateMG(6, "First you eat me, the you get eaten, what am I?", "FISHHOOK", 60f));
        InitializingQuestion();

        
        PuzzleField = GameObject.Find("FieldContainer").GetComponent<Transform>();
        ParticleContainer = GameObject.Find("ParticleContainer_Winner").GetComponent<Transform>();
        Image_Correct = GameObject.Find("Image_Correct").GetComponent<Image>();
        Image_Wrong = GameObject.Find("Image_Wrong").GetComponent<Image>();
        Ready_Panel = GameObject.Find("MessagePop").GetComponent<Animator>();
        btReady = GameObject.Find("btReady").GetComponent<Button>();

        bool_pause = true;

        foreach (GameObject item in btns)
        {
            item.gameObject.SetActive(false);
        }
        if (Sound_timeClock != null)
        {
            Sound_timeClock.Stop();
        }
        //Ready method Start here
        if (Ready_Panel && btReady != null)
        {
            
            Ready_Panel.Play("Read_Panel_Show");
            StartCoroutine("ReadY_Courtine");
            btReady.onClick.AddListener(()=> Ready_Panel.Play("Read_Panel_TurnBack"));
            btReady.onClick.AddListener(()=> StartCoroutine("Processiing_to_Startgame"));        
        }
        else
        {
            Debug.Log(" It didn't Work");
        }

        if (TextAnswerSpell.text == null)
        {
            StartCoroutine("TurnPuzzleButtonBack");
        }
        bool_timerofgame = true;//timer update in game result panel

        if (panel_playersavesystem.GetComponent<PlayerSaveSystem>().PArticle_bool == true)
        {
            effect_1.gameObject.SetActive(true);
            effect_2.gameObject.SetActive(true);
            Effect_Background.gameObject.SetActive(true);
        }
        if (panel_playersavesystem.GetComponent<PlayerSaveSystem>().PArticle_bool == false)
        {
            effect_1.gameObject.SetActive(false);
            effect_2.gameObject.SetActive(false);
            Effect_Background.gameObject.SetActive(false);
        }
    }
    //Update
    void Update()
    {
        textnumscore.text = "" + Int_score;
        panel_playersavesystem.GetComponent<PlayerSaveSystem>().MemorygameScore_5 = textnumscore.text = "" + Int_score;
        if (times_up == true && Mathf.Round(Float_Timer_of_game) == 0)
        {
            times_up = false;
            SoundTime_up();
            Sound_timeClock.Stop();
        }

        if (Int_score > 1)
        {
            textstringpoint.text = " Points";
        }

        else
        {
            textstringpoint.text = " Point";
        }

        if (bool_pause == false)
        {
            StartCoroutine("Timer_of_game");
        }
        else
        {
            StopCoroutine("Timer_of_game");
        }
        if (bool_gameresult_panel == true)
        {
            Panel_gameresltpanel.gameObject.SetActive(true);
        }
        else
        {
            Panel_gameresltpanel.gameObject.SetActive(false);
        }     

        if (bool_Image_Correct == true)
        {
            Image_Correct.gameObject.SetActive(true);
        }

        else
        {
            Image_Correct.gameObject.SetActive(false);
        }

        if (bool_Image_Wrong == true)
        {
            Image_Wrong.gameObject.SetActive(true);
        }

        else
        {
            Image_Wrong.gameObject.SetActive(false);
        }

        if (bool_btresult == true)
        {
            btProgress.gameObject.SetActive(true);
        }

        else
        {
            btProgress.gameObject.SetActive(false);
        }

        if (bool_btNext == true)
        {
            btNext.gameObject.SetActive(true);
        }
        else
        {
            btNext.gameObject.SetActive(false);
        }
        if (bool_nextlevel == true)
        {
            btNextlevel.gameObject.SetActive(true);
        }
        else
        {
            btNextlevel.gameObject.SetActive(false);
        }
        if (bool_AnswerReview_panel == true)
        {
            panel_AnswerReview.gameObject.SetActive(true);
        }
        else
        {
            panel_AnswerReview.gameObject.SetActive(false);
        }
        if (bool_content_btnextlevel == true)
        {
            content_image_btnextlevel.gameObject.SetActive(true);
        }
        else
        {
            content_image_btnextlevel.gameObject.SetActive(false);
        }
        if (bool_timerofgame == true)
        {
            UpdateTimerUI();
        }

    }


    public void InitializingQuestion()
    {
        StopAllCoroutines();
        ClearPreFabName();
        TempAnimator.Clear();
        if (DestroyCorrecteffect_bool == true)
        {
            DestroyCorrecteffect_bool = false;
            DestroyCorrectEffect();
        }
        if (StartQuestion == true)
        {
            bool_pause = false;
        }
        TextAnswerSpell = GameObject.Find("Text_AnswerSpell").GetComponent<TMP_Text>();
        TextAnswerSpell.GetComponent<TMP_Text>().text = "";
        textCorrectandWrong = GameObject.Find("Text_CorrectandWrong").GetComponent<TMP_Text>();
        if (bool_Play_clockSound == true)
        {
            Sound_timeClock.Play();
        }
        onClick.currentword = "";
        int_num_round = int_num_round + 1;

       
        foreach (GameObject item in btns)
        {
            Animator btnanimator = item.GetComponent<Animator>();
            btnanimator.Play("Return_idle");
        }
        
      
        TextQuestionCount = GameObject.Find("TextQuestionCount").GetComponent<TMP_Text>();
        TextQuestionCount.text = int_num_round + "/" + int_num_totalRound;
        bool_btNext = false;
        bool_Image_Correct = false;
        bool_Image_Wrong = false;
      
        string answer;

        IntQuestionCount++;

        if (bool_CanBeRemoveQuestion == true)
        {
            RemoveCurrentDisplay();
        }

        randomNum = UnityEngine.Random.Range(0, Questions.Count);
        for (int i = 0; i < Questions.Count; i++)
        {
            if (randomNum == i)
            {
                ++int_numericalTotalAnswer;
                if (AnswerItem.Count == intTotalQuestion)
                {

                    GameObject TempAnswer = AnswerItem[0];
                    Destroy(TempAnswer.gameObject);
                    AnswerItem.Remove(TempAnswer);

                }
                
                GameObject newText = Instantiate(AnswertextPrefab) as GameObject;
                newText.SetActive(true);

                newText.GetComponent<Text>().text = int_numericalTotalAnswer + ". " + Questions[i].CorrectAnswer;
                newText.transform.SetParent(AnswertextPrefab.transform.parent, false);

                AnswerItem.Add(newText.gameObject);


                TextQuestionField = GameObject.Find("QuestionText").GetComponent<TMP_Text>();
                TextQuestionField.text = "";
                TextQuestionField.text = Questions[i].Question;
                answer = Questions[i].CorrectAnswer;
                //kunin muna lahat ng letters sa answer at ilagay sa randStr
                Float_Timer_of_game = Questions[i].QTime;
                for (int f = 0; f < answer.Length; f++)
                {
                    randStr.Add(answer[f].ToString());
                }

                //shuffle mga letters sa randStr
                for (int k = 0; k < randStr.Count; k++)
                {
                    int index = UnityEngine.Random.Range(0, randStr.Count);
                    string c = randStr[index];

                    if (c == answer)
                    {
                        index = UnityEngine.Random.Range(0, randStr.Count);
                        string cc = randStr[index];
                        randStr[index] = randStr[k];
                        randStr[k] = cc;
                    }

                    randStr[index] = randStr[k];
                    randStr[k] = c;
                }

                for (int j = 0; j < randStr.Count; j++)
                {
                    GameObject button = Instantiate(btn) as GameObject;
                    button.name = "" + j;
                    btns.Add(button);
                    PuzzleField = GameObject.Find("FieldContainer").GetComponent<Transform>();
                    button.transform.SetParent(PuzzleField, false);
                    string tempstring2 = randStr[j];
                    button.GetComponentInChildren<TMP_Text>().text = randStr[j];
                    string temp = randStr[j];                    
                    Button tempButton = button.GetComponent<Button>();                    

                   
                    tempButton.onClick.AddListener(() => ProcessClick(temp));
                    tempButton.onClick.AddListener(() => ButtonClick());
                    tempButton.onClick.AddListener(() => SoundBig_ui_addlistiner());
                    tempButton.onClick.AddListener(() => TempAnimator.Add(firstGuessIndex));
                    tempButton.onClick.AddListener(() => Addlistener());

                }
            }
        }
    }

    public void UpdateTimerUI() // ===== function the timer will show up overall answer after finish answering the question or go it wrong answered
    {
        secondsCount += Time.deltaTime;
        textoveralltime.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
        panel_playersavesystem.GetComponent<PlayerSaveSystem>().MemorygameTime_5 = textoveralltime.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }

        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }

    void SoundBig_ui_addlistiner()
    {
        Sound_Big_Ui.Play();
    }

    void SoundInteractive_ui_addlistiner()
    {
        Sound_interactive.Play();
    }

    void SoundTime_up()
    {
        Sound_times_up.Play();
    }

    void SoundClose()
    {
        Sound_close.Play();
    }

    void SoundCorrec()
    {
        Sound_Correct.Play();
    }

    void SoundWwrong()
    {
        Sound_Wrong.Play();
    }

    void SoundWin_level()
    {
        Sound_Win.Play();
    }
  

    void NextlevelbtAddlistiner()
    {
        SceneManager.LoadScene("MemoryGame6");
        panel_playersavesystem.GetComponent<PlayerSaveSystem>().SaveGame();
    }

    public void DestroyPrefab() // ===== function Destroy all recent Button Answers
    {
        StartCoroutine("ClearPrefab");
    }

    void ClearPreFabName()
    {
        foreach (GameObject item in btns)
        {
            Destroy(item);
        }
        btns.Clear();
        randStr.Clear();
        
        
    }

    void Addlistener()
    {
        
        Button gameObjectbtn = btns[firstGuessIndex].GetComponent<Button>();
       // gameObjectbtn.interactable = true;
    }

    void ButtonClick()
    {
       
        firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Debug.Log(firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name));
        StartCoroutine("ButtonAnimate");       
    }   
    
   
    void RemoveCurrentDisplay() // ===== function remove question after show
    {
        for (int i = 0; i < Questions.Count; i++)
        {
            if (randomNum == i)
            {
                Questions.Remove(Questions[i]);
            }
        }
    }

    void PlayagainAddlistiner()
    {
        SceneManager.LoadScene("MemoryGame5");
        panel_playersavesystem.GetComponent<PlayerSaveSystem>().SaveGame();
    }

    void ReturnHomeAddlistiner()
    {
        SceneManager.LoadScene("Main");
    }

    public void ProgressButtonAddlistiner()
    {
        bool_gameresult_panel = true;
    }
    public void AnswerReviewBiuttonAddlistiner()
    {
        bool_AnswerReview_panel = true;
    }
    public void CloseAnswerReview_Panel()
    {
        bool_AnswerReview_panel = false;
    }

    void ShowAnswerReview_panelAddlistiner()
    {            
       bool_AnswerReview_panel = true;      
    }

   void ProcessClick(string letter)
    {
        onClick.currentword += letter;
       
        TextAnswerSpell.GetComponent<TMP_Text>().text = onClick.currentword;
        for (int i = 0; i < Questions.Count; i++)
        {
            if (randomNum == i)
            {
                if (onClick.currentword.Length == Questions[i].CorrectAnswer.Length)
                {
                    if (onClick.currentword == Questions[i].CorrectAnswer)
                    {
                        Debug.Log(" Correct all");
                        StartCoroutine("Correct");
                        StartCoroutine("PlayCorrectEffect");
                        bool_Image_Correct = true;
                        bool_btNext = true;
                        bool_pause = true;
                        Int_score += 1;
                        SoundCorrec();
                        Sound_timeClock.Stop();
                        TextQuestionField.text = "";
                        StartQuestion = true;
                        bool_Play_clockSound = true;
                        if (IntQuestionCount == intTotalQuestion)
                        {
                            panel_playersavesystem.GetComponent<PlayerSaveSystem>().Memorylevel5 = true;
                            bool_btresult = true;
                            Time.timeScale = 1f;
                            bool_pause = true;
                            bool_nextlevel = true;
                            bool_btNext = false;
                            bool_content_btnextlevel = true;
                            bool_timerofgame = false;
                            StartCoroutine("PLayEffect");
                            Aniamtor_Achievement_panel_notify.Play("Achievement_notify_panel_Show");
                            StartCoroutine("WaitingToCloseAcheivementPanel");
                            SoundWin_level();
                            WinLevel();
                            Sound_timeClock.Stop();
                            foreach (GameObject item in btns)
                            {
                                Destroy(item);
                            }
                        }
                        else
                        {
                            bool_btNext = true;
                        }

                    }

                    else
                    {
                        Debug.Log(" Wrong All");
                        StartCoroutine("TurnPuzzleButtonBack");
                        StartCoroutine("CoroutineCorrectandWrong");
                        bool_Image_Wrong = true;
                        SoundWwrong();
                        btTurnback.gameObject.SetActive(true);
                    }
                }

                for (int var = 0; var < onClick.currentword.Length; var++)
                {
                    if (onClick.currentword[var] != Questions[i].CorrectAnswer[var])
                    {
                       // StartCoroutine("Wrongfirstguest");
                       
                    }
                }
            }
            bool_CanBeRemoveQuestion = true;
        }
    }

    void loading()
    {
        for (int i = 0; i < Questions.Count; i++)
        {
            if (randomNum == i)
            {
                float fill = (float)Float_Timer_of_game / Questions[i].QTime;
                Image_Timbar.fillAmount = fill;
            }
            
        }
        
    }
    void DestroyCorrectEffect()
    {
        GameObject CorrectEfect;
        CorrectEfect = GameObject.Find("Effect_WinLevel(Clone)");
        Destroy(CorrectEfect);
        Debug.Log("The " + CorrectEfect + " have been destroyed");
    }
    IEnumerator Timer_of_game()
    {
        yield return new WaitForSeconds(1f);
        Float_Timer_of_game -= Time.deltaTime;
        Image_Timbar = GameObject.Find("Time_Bar").GetComponent<Image>();
        loading();
        TextTimer = GameObject.Find("textTimer").GetComponent<Text>();
        TextTimer.text = Mathf.Round(Float_Timer_of_game).ToString();
        if (Mathf.Round(Float_Timer_of_game) == 0)
        {
           
            TextQuestionField.text = "" + randomListString;
            onClick.currentword = "";
            Float_Timer_of_game = 0f;
            bool_btresult = true;
            bool_timerofgame = false;
        
            foreach (GameObject item in btns)
            {
                Destroy(item);
            }
            yield return new WaitForSeconds(0.1f);
            bool_pause = true; 
        }
    }
    

    IEnumerator Wrongfirstguest()
    {
       
        yield return new WaitForSeconds(1f);

        foreach (int item in TempAnimator)
        {
            QueueAnimator.Enqueue(item);
        }


      
        for (int i = 0; i < btns.Count; i++)
        {
            Animator  btnanimator = btns[QueueAnimator.Dequeue()].GetComponent<Animator>();
            btnanimator.Play("TurnBack");
            yield return new WaitForSeconds(0.1f);
            onClick.currentword = "";
            TextAnswerSpell.text = "";
        }
        TempAnimator.Clear();



    }

    IEnumerator TurnPuzzleButtonBack()
    {
        yield return new WaitForSeconds(3f);
  
        foreach (int  item in TempAnimator)
        {
            QueueAnimator.Enqueue(item);
        }       

        for (int i = 0; i < btns.Count; i++)
        {
            Animator btnanimator = btns[firstGuessIndex].GetComponent<Animator>();
            btnanimator = btns[QueueAnimator.Dequeue()].GetComponent<Animator>();
            btnanimator.Play("TurnBack");
            yield return new WaitForSeconds(0.1f);

        }
          onClick.currentword = "";
        TextAnswerSpell.text = "";                
        TempAnimator.Clear();
        yield return new WaitForSeconds(0.1f);
        StopCoroutine("TurnPuzzleButtonBack");
    }

    IEnumerator CoroutineCorrectandWrong_OnTap()
    {
        textCorrectandWrong.text = "" + randomListString;
        textCorrectandWrong.GetComponent<TMP_Text>().text = "";
        onClick.currentword = "";
        bool_Image_Wrong = false;
        yield return null;
    }
     IEnumerator TurnPuzzleButtonBack_onTap()
    {
        foreach (int item in TempAnimator)
        {
            QueueAnimator.Enqueue(item);
        }

        for (int i = 0; i < btns.Count; i++)
        {
            Animator btnanimator = btns[firstGuessIndex].GetComponent<Animator>();
            btnanimator = btns[QueueAnimator.Dequeue()].GetComponent<Animator>();
            btnanimator.Play("TurnBack");
            yield return new WaitForSeconds(0.1f);

        }
        onClick.currentword = "";
        TextAnswerSpell.text = "";
        TempAnimator.Clear();
    }
    IEnumerator ButtonAnimate( )
    {
        Button gameObjectbtn = btns[firstGuessIndex].GetComponent<Button>();
        gameObjectbtn.GetComponent<Animator>().Play("TurnUp");
        yield return new WaitForSeconds(0.01f);
       
    
    }

    IEnumerator Correct()
    {
        yield return new WaitForSeconds(1f);
        TextQuestionField.text = " Correct Answer";
        yield return new WaitForSeconds(1f);
       
        foreach (GameObject btn in btns)
        {
            btn.GetComponent<Animator>().Play("FadeOut");
        }
        yield return new WaitForSeconds(1f);
        foreach (GameObject  item in btns)
        {
            Destroy(item);
        }
        btns.Clear();
    }
    IEnumerator PlayCorrectEffect()
    {
        yield return new WaitForSeconds(0.3f);
        ParticleContainer = GameObject.Find("ParticleContainer_Winner").GetComponent<Transform>();
        ParticleSystem psStar = Instantiate(StarEffect);
        psStar.gameObject.SetActive(true);       
        psStar.transform.SetParent(ParticleContainer, false);
        psStar.Play();
        psStar.GetComponentInChildren<ParticleSystem>().Play();
        DestroyCorrecteffect_bool = true;
        yield return new WaitForSeconds(1f);
        DestroyCorrectEffect();
    }

    IEnumerator CoroutineCorrectandWrong()
    {
        textCorrectandWrong.text = "" + randomListString;
        yield return new WaitForSeconds(3f);
        textCorrectandWrong.GetComponent<TMP_Text>().text = "";
        onClick.currentword = "";
        bool_Image_Wrong = false;
        yield return null;
    }

    IEnumerator PLayEffect()
    {
        yield return new WaitForSeconds(1f);
        ParticleSystem psStar = Instantiate(effect_1);
        ParticleSystem psStar2 = Instantiate(effect_2);
        psStar.transform.SetParent(particle_win_container, false);
        psStar2.transform.SetParent(particle_win_container, false);
        psStar.Play();
        psStar2.Play();
        psStar.GetComponentInChildren<ParticleSystem>().Play();
        psStar2.GetComponentInChildren<ParticleSystem>().Play();
        Component[] children = psStar2.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem item in children)
        {
            item.Play();
        }
    }

    IEnumerator WaitingToCloseAcheivementPanel()
    {
        yield return new WaitForSeconds(4f);
        Aniamtor_Achievement_panel_notify.SetBool("Exit", true);
        panel_playersavesystem.GetComponent<PlayerSaveSystem>().Memorylevel5 = true;
    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReachedMG", 6);
    }
}

