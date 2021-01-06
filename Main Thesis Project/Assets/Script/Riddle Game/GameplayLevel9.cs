using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/*
    TODOlist:
    * put save fucntion
    * put Achinevment function
    * put function sound function
    * put it on every gamelevel script, this is your Original copy of your work
 
*/

public class GameplayLevel9 : MonoBehaviour
{
    public ParticleSystem Effect_01, Effect_02;
    public ParticleSystem Effect_background;
    public Transform EffectsPrefabContainer;
    public Animator animator, SAchieveanimator, SAAchievemet_Completet_allLevels, messagepop, AnsrBtnPrefab_anim, Level_anim;
    private bool timeofgamestop = false, CanBeRemove = false, startquestioning = false, showhintOnStart = false, ShowAnswerButtonPrefab = false, Pause = false, PlaySound_Clock_bool = false, times_up = true, StartingCount_bool = false;
    private float timermessage = 3f, ramdomNumber, secondsCount, timeLeft = 30f;
    public Text QuestionField, QuestionCountText, ScoreFieldText, Points, ShowtextAnswer, ShowHintText, Hinttexnum, TimerText, Timeofgame, TimerCountDown, message_text_Ready, Einstien_Quote;
    public Button HintButton, NextButton, ProgressButton;
    public GameObject GameQuestion, SA, ReviewGo, AnswerText, Buttonprefab, PlayAgain_btn, NextLevelBtn;
    public Image result, CorrectAnswer, WrongAnswer, timebar;
    private List<GameObject> AnswerItem;
    private List<string> randStr = new List<string>();
    private List<GameObject> AllPrefab = new List<GameObject>();
    List<QuestionTemplate> Questions;
    private int Hintnum = 3, TotalAnswer = 0, QuestionCount = 0, minuteCount, hourCount, TotalQuestionPerRound = 6;
    public int Score = 0, wordLen;
    private GameObject ButtonprefabTemp, playersaveSystem;
    public Transform ButtonContainer, spellword;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public AudioClip ClipSound_TimeClock;
    public AudioClip ClipSound_Ui_InterActive;
    public AudioClip ClipSound_UI_Close;
    public AudioClip ClipSound_UI_big;
    public AudioClip ClipSound_UI_Times_up;
    public AudioClip ClipSound_UI_Achievement;
    public AudioClip ClipSound_UI_Correct_Sound;
    public AudioClip ClipSound_UI_Wrong_Sound;
    public AudioSource SourceSound_TimeClock;
    public AudioSource SourceSound_UI_InterActive;
    public AudioSource SourceSound_UI_Close;
    public AudioSource SourceSound_UI_Big;
    public AudioSource SourceSound_UI_Times_up;
    public AudioSource SourceSound_UI_Achievement_Sound;
    public AudioSource SourceSound_UI_Correct_Sound;
    public AudioSource SourceSound_UI_Wrong_Sound;
    float fillamount;
    private bool tempBool_timeclock = true;
    [TextArea(5, 10)]
    public List<string> list_Quote = new List<string>();
    private string randomListString;


    void Start() // ===== function Main Starting Program
    {
        StartingCount_bool = true;
        playersaveSystem = GameObject.Find("PlayerSaveSystem");
        Level_anim.Play("Level_Animation");
        GameQuestion.gameObject.SetActive(false);
        messagepop.SetBool("IsTrigger", true);
        message_text_Ready.text = "Ready..";
        Pause = true;
        NextLevelBtn.SetActive(false);
        ProgressButton.gameObject.SetActive(false);
        HintButton.interactable = false;
        CorrectAnswer.gameObject.SetActive(false);
        WrongAnswer.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(false);
        SAAchievemet_Completet_allLevels = GameObject.Find("Achievement_notify_panel_Completeted_All_Level").GetComponent<Animator>();
        AnswerItem = new List<GameObject>();
        Questions = new List<QuestionTemplate>();
        // Question will be add here //
        Questions.Add(new QuestionTemplate(1, "What always runs but never walks, often murmurs, never talks, has a bed but never sleeps, has a mouth but never eats?", "RIVER", " R"));
        Questions.Add(new QuestionTemplate(2, "Tool of thief, toy of queen. Always used to be unseen. Sign of joy, sign of sorrow. Giving all likeness borrowed. What am I?", "MASK", "M"));
        Questions.Add(new QuestionTemplate(3, "I am not alive, but I grow; I don't have lungs, but I need air; I don't have a mouth, but water kills me. What am I?", "FIRE", "F"));
        Questions.Add(new QuestionTemplate(4, "There is an ancient invention still used in some parts of the world today that allows people to see through walls. What is it?", "WINDOW", "W"));
        Questions.Add(new QuestionTemplate(5, "If seven cats kill seven rats in 7 minutes, how many would be needed to kill one hundred rats in 50 minutes?", "FOURTHEEN", "fist number IS 1"));
        Questions.Add(new QuestionTemplate(6, "In the form of fork or sheet, I hit the ground. And if you wait a heartbeat, You can hear my roaring sound", "LIGHTNING", "L"));
        NextButtonClick();
        SourceSound_TimeClock.clip = ClipSound_TimeClock;
        SourceSound_UI_Big.clip = ClipSound_UI_big;
        SourceSound_UI_Close.clip = ClipSound_UI_Close;
        SourceSound_UI_InterActive.clip = ClipSound_Ui_InterActive;
        SourceSound_UI_Times_up.clip = ClipSound_UI_Times_up;
        SourceSound_UI_Achievement_Sound.clip = ClipSound_UI_Achievement;
        SourceSound_UI_Correct_Sound.clip = ClipSound_UI_Correct_Sound;
        SourceSound_UI_Wrong_Sound.clip = ClipSound_UI_Wrong_Sound;
        foreach (GameObject item in AllPrefab)
        {
            item.SetActive(false);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().PArticle_bool == true)
        {
            Effect_01.gameObject.SetActive(true);
            Effect_02.gameObject.SetActive(true);
            Effect_background.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().PArticle_bool == false)
        {
            Effect_01.gameObject.SetActive(false);
            Effect_02.gameObject.SetActive(false);
            Effect_background.gameObject.SetActive(false);
        }

    }

    public void ShowHInt() // ===== function for hint
    {

        if (Hintnum > 0)
        {
            Hintnum--;
            Hinttexnum.text = Hintnum.ToString();
            HintButton.interactable = false;
            animator.SetBool("IsTrigger", true);

            for (int i = 0; i < Questions.Count; i++)
            {
                if (ramdomNumber == i)
                {
                    ShowHintText.text = "It is start from" + " " + Questions[i].hintshow;
                }
            }
        }

        else if (Hintnum == 0)
        {
            Hintnum = 0;
        }
    }
    public void Progress() // ===== function Progress Button show up
    {
        GameQuestion.gameObject.SetActive(false);
        result.gameObject.SetActive(true);
        //GameControl.control.Save();
    }

    public void playsound() // ===== function play sound
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void ShowA() // ===== function show recently answers in all questions
    {
        SA.gameObject.SetActive(true);
    }

    public void PlayAgian() // ===== function play again same Game level
    {
        SceneManager.LoadScene("GameplayLevel9");
        playersaveSystem.GetComponent<PlayerSaveSystem>().SaveGame();

    }
    public void CloseReview() // ===== function close the panle of Review answers
    {
        ReviewGo.gameObject.SetActive(false);
    }

    public void ReturnHomeBt() // ===== function Back to Main Scene
    {
        SceneManager.LoadScene("Main");
        GameObject audioSource = GameObject.Find("AudioSource");
        audioSource.GetComponent<AudioSource>().gameObject.SetActive(true);
        playersaveSystem.GetComponent<PlayerSaveSystem>().SaveGame();
    }

    public void NextButtonClick() // ===== function pressing the button for next question and answers 
    {
        AnsrBtnPrefab_anim.SetBool("isBool_open", true); // don't touch this

        if (PlaySound_Clock_bool == true)
        {
            SourceSound_TimeClock.Play();
        }


        if (CanBeRemove == true)
        {
            RemoveQuestionsAfterDisplay();
        }

        ObjectDestroyer();

        if (ShowAnswerButtonPrefab == true)
        {

            foreach (GameObject item in AllPrefab)
            {
                item.SetActive(true);
            }
        }

        if (showhintOnStart == true)
        {
            HintButton.interactable = true;
        }

        timeLeft = 30f;

        if (startquestioning == true)
        {
            Pause = false;
        }

        Time.timeScale = 1f;
        NextButton.gameObject.SetActive(false);
        CorrectAnswer.gameObject.SetActive(false);
        WrongAnswer.gameObject.SetActive(false);

        animator.SetBool("IsTrigger", false);
        onClick.currentword = "";
        spellword.GetComponent<Text>().text = "";
        QuestionCount = QuestionCount + 1;
        QuestionCountText.text = QuestionCount + "/" + TotalQuestionPerRound;

        if (QuestionCount == TotalQuestionPerRound)
        {
            NextButton.gameObject.SetActive(false);
        }
        ramdomNumber = UnityEngine.Random.Range(0, Questions.Count);
        randomListString = list_Quote[Random.Range(0, list_Quote.Count)];
        string answer;

        for (int i = 0; i < Questions.Count; i++)
        {
            if (ramdomNumber == i)
            {
                animator.SetBool("IsTrigger", false);
                QuestionField.text = Questions[i].Question;
                ++TotalAnswer;

                // randStr.Clear();
                answer = Questions[i].CorrectAnswer;

                if (AnswerItem.Count == TotalQuestionPerRound)
                {

                    GameObject TempAnswer = AnswerItem[0];
                    Destroy(TempAnswer.gameObject);
                    AnswerItem.Remove(TempAnswer);

                }
                StopAllCoroutines();
                StartCoroutine("QuestionstText");

                GameObject newText = Instantiate(AnswerText) as GameObject;
                newText.SetActive(true);

                newText.GetComponent<Text>().text = TotalAnswer + ". " + Questions[i].CorrectAnswer;
                newText.transform.SetParent(AnswerText.transform.parent, false);

                AnswerItem.Add(newText.gameObject);
                //kunin muna lahat ng letters sa answer at ilagay sa randStr

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

                //assign sa mga button
                for (int j = 0; j < randStr.Count; j++)
                {
                    GameObject go = Instantiate(Buttonprefab) as GameObject;
                    AllPrefab.Add(go);
                    go.transform.SetParent(ButtonContainer, false);
                    Button tempButton = go.GetComponent<Button>();
                    string temp = randStr[j];
                    tempButton.onClick.AddListener(() => ButtonClick(temp));
                    tempButton.onClick.AddListener(() => tempButton.interactable = false);
                    tempButton.onClick.AddListener(() => playsound());

                    tempButton.onClick.AddListener(() => randStr.Clear());
                    string ClickedAnswer = go.GetComponentInChildren<Text>().text = randStr[j];
                }
            }
        }
    }

    public void ObjectDestroyer() // ===== function Destroy all recent Button Answers
    {
        foreach (GameObject item in AllPrefab)
        {
            Destroy(item);
        }
        AllPrefab.Clear();
    }

    void loading()
    {
        float fill = (float)timeLeft / 30f;
        timebar.fillAmount = fill;
    }

    IEnumerator TimerScript() // ===== function all setting of timers (Time of the game, timer left)
    {

        if (QuestionCount == TotalQuestionPerRound + 1)
        {
            Time.timeScale = 1f;
            timeLeft = -1f;
            Progress();
        }
        loading();
        yield return new WaitForSeconds(1f);
        timeLeft -= Time.deltaTime;
        TimerText.text = Mathf.Round(timeLeft).ToString();
        if (Mathf.Round(timeLeft) == 0)
        {

            WrongAnswer.gameObject.SetActive(true);
            QuestionField.text = ("       Times UP !");
            Pause = true;
            timeLeft = 0f;

            NextButton.gameObject.SetActive(false);
            Time.timeScale = 1f;
            ProgressButton.gameObject.SetActive(true);
            timeofgamestop = false;

            foreach (GameObject item in AllPrefab)
            {
                item.SetActive(false);
            }

            if (QuestionCount == TotalQuestionPerRound)
            {
                timeofgamestop = false;
                NextButton.gameObject.SetActive(false);
                Time.timeScale = 1f;
                ProgressButton.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator QuestionstText() // ===== function Showing Question from random generator
    {
        QuestionField.text = "";
        for (int i = 0; i < Questions.Count; i++)
        {
            if (ramdomNumber == i)
            {
                foreach (char letter in Questions[i].Question.ToCharArray())
                {
                    QuestionField.text += letter;
                    yield return null;
                }
            }
        }
    }

    void Update() // ===== function update every frame
    {
        playersaveSystem = GameObject.Find("PlayerSaveSystem");
        ScoreFieldText.text = "" + Score;
        playersaveSystem.GetComponent<PlayerSaveSystem>().RiddleScore_9 = ScoreFieldText.text = "" + Score;
        if (StartingCount_bool == true)
        {

            StartCoroutine("StartingCountdown");
        }
        if (StartingCount_bool == false)
        {
            StopCoroutine("StartingCountdown");
        }


        //timermessage -= Time.deltaTime;

        //if (Mathf.Round(timermessage) == 0)
        //{

        //    showhintOnStart = true;
        //    messagepop.SetBool("IsTrigger", false);
        //    GameQuestion.gameObject.SetActive(true);
        //    Pause = false;

        //    timeofgamestop = true;
        //    HintButton.interactable = true;
        //    foreach (GameObject item in AllPrefab)
        //    {
        //        item.SetActive(true);
        //    }
        //}



        if (Mathf.Round(timermessage) == -3 && tempBool_timeclock == true)
        {
            tempBool_timeclock = false;

            TimerCountDown.gameObject.SetActive(false);
            SourceSound_TimeClock.Play();
            timermessage = Time.deltaTime;
            TimerCountDown.gameObject.SetActive(false);
            StopCoroutine("StartingCountdown");
        }
        if (times_up == true && Mathf.Round(timeLeft) == 0)
        {
            times_up = false;
            SourceSound_UI_Times_up.Play();
            SourceSound_TimeClock.Stop();
        }

        if (timeofgamestop == true)
        {
            UpdateTimerUI();
        }

        if (Pause == false)
        {
            StartCoroutine("TimerScript");
        }

        if (Score > 1)
        {
            Points.text = " Points";
        }

        else
        {
            Points.text = " Point";
        }


    }

    string UppercaseFirst(string s) // ===== function changing the String cases
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        return char.ToUpper(s[0]) + s.Substring(1);
    }

    void ButtonClick(string letter) // ===== function identifying the answer if correct and wrong in Button Answer prefab
    {
        onClick.currentword += letter;

        spellword.GetComponent<Text>().text = onClick.currentword;

        for (int i = 0; i < Questions.Count; i++)
        {
            if (ramdomNumber == i)
            {
                if (onClick.currentword.Length == Questions[i].CorrectAnswer.Length)
                {
                    if (onClick.currentword == Questions[i].CorrectAnswer)
                    {
                        CorrectAnswer.gameObject.SetActive(true);
                        WrongAnswer.gameObject.SetActive(false);
                        Time.timeScale = 0f;
                        Pause = true;
                        Score += 1;
                        startquestioning = true;
                        SourceSound_TimeClock.Stop();
                        PlaySound_Clock_bool = true;
                        SourceSound_UI_Correct_Sound.Play();
                        QuestionField.text = "";
                        if (QuestionCount == TotalQuestionPerRound)
                        {
							playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel9 = true;
                            NextButton.gameObject.SetActive(false);
                            Time.timeScale = 1f;
                            ProgressButton.gameObject.SetActive(true);
                            timeofgamestop = false;
                            WinLevel();
                            PlayAgain_btn.SetActive(false);
                            SourceSound_UI_Correct_Sound.Stop();
                            NextLevelBtn.SetActive(true);
                            StartCoroutine("PLayEffect");
                            SAchieveanimator.Play("Achievement_notify_panel_Show");
                            StartCoroutine("WaitingToCloseAcheivementPanel");
                            SourceSound_UI_Achievement_Sound.Play();
                            foreach (GameObject item in AllPrefab)
                            {
                                item.SetActive(false);
                            }
                        }

                        else
                        {
                            NextButton.gameObject.SetActive(true);
                        }
                    }

                    else
                    {
                        NextButton.gameObject.SetActive(false);
                        Time.timeScale = 1f;
                        ProgressButton.gameObject.SetActive(true);
                        timeofgamestop = false;
                        WrongAnswer.gameObject.SetActive(true);
                        StartCoroutine("WaitingToShowUp");
                        StartingCount_bool = false;
                        SourceSound_TimeClock.Stop();
                        SourceSound_UI_Wrong_Sound.Play();
                        Einstien_Quote.text = randomListString;
                        TimerCountDown.text = "";
                        foreach (GameObject item in AllPrefab)
                        {
                            item.SetActive(false);
                        }

                        if (QuestionCount == TotalQuestionPerRound)
                        {
                            NextButton.gameObject.SetActive(false);
                            Time.timeScale = 1f;
                            ProgressButton.gameObject.SetActive(true);
                            timeofgamestop = false;
                        }

                        Pause = true;
                    }

                }

                for (int var = 0; var < onClick.currentword.Length; var++)
                {
                    if (onClick.currentword[var] != Questions[i].CorrectAnswer[var])
                    {
                        NextButton.gameObject.SetActive(false);
                        Time.timeScale = 1f;
                        ProgressButton.gameObject.SetActive(true);
                        timeofgamestop = false;
                        WrongAnswer.gameObject.SetActive(true);
                        SourceSound_TimeClock.Stop();
                        StartCoroutine("WaitingToShowUp");
                        SourceSound_UI_Wrong_Sound.Play();
                        Einstien_Quote.text = randomListString;
                        TimerCountDown.text = "";
                        StartingCount_bool = false;
                        foreach (GameObject item in AllPrefab)
                        {
                            item.SetActive(false);
                        }

                        if (QuestionCount == TotalQuestionPerRound)
                        {
                            NextButton.gameObject.SetActive(false);

                            Time.timeScale = 1f;
                            ProgressButton.gameObject.SetActive(true);
                            timeofgamestop = false;
                        }

                        Pause = true;
                    }
                }

                HintButton.interactable = false;
            }

            CanBeRemove = true;
        }
    }

    void RemoveQuestionsAfterDisplay() // ===== function remove question after show
    {
        for (int i = 0; i < Questions.Count; i++)
        {
            if (ramdomNumber == i)
            {
                Questions.Remove(Questions[i]);
            }
        }
    }

    public void UpdateTimerUI() // ===== function the timer will show up overall answer after finish answering the question or go it wrong answered
    {
        secondsCount += Time.deltaTime;
        Timeofgame.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
        playersaveSystem.GetComponent<PlayerSaveSystem>().RiddleTime_9 = Timeofgame.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
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
    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", 9);
    }

    IEnumerator StartingCountdown()
    {
        yield return new WaitForSeconds(1f);
        timermessage -= Time.deltaTime;
        TimerCountDown.text = Mathf.Round(timermessage).ToString();

        if (Mathf.Round(timermessage) == 0)
        {
            TimerCountDown.text = "Go!";

        }
        if (Mathf.Round(timermessage) == -1)
        {
            TimerCountDown.text = "Go!";

        }

        if (Mathf.Round(timermessage) == -2)
        {
            TimerCountDown.text = "Go!";

        }

        if (Mathf.Round(timermessage) == -3)
        {
            TimerCountDown.text = "Go!";
            TimerCountDown.gameObject.SetActive(false);
        }

        if (Mathf.Round(timermessage) == -3)
        {

            showhintOnStart = true;
            messagepop.SetBool("IsTrigger", false);
            GameQuestion.gameObject.SetActive(true);
            Pause = false;

            timeofgamestop = true;
            HintButton.interactable = true;
            foreach (GameObject item in AllPrefab)
            {
                item.SetActive(true);
            }


        }

    }

    public void Sound_InterActive()
    {
        SourceSound_UI_InterActive.Play();
    }
    public void Sound_close()
    {
        SourceSound_UI_Close.Play();
    }
    public void Sound_UI_big()
    {
        SourceSound_UI_Big.Play();
    }

    IEnumerator WaitingToShowUp()
    {
        yield return new WaitForSeconds(3f);
        messagepop.SetBool("IsTrigger", true);
    }
    IEnumerator WaitingToCloseAcheivementPanel()
    {
        yield return new WaitForSeconds(4f);
        SAchieveanimator.SetBool("Exit", true);
        yield return new WaitForSeconds(1f);
        SAAchievemet_Completet_allLevels.Play("Achievement_notify_panel_Show");
        yield return new WaitForSeconds(4f);
        SAAchievemet_Completet_allLevels.SetBool("Exit", true);
        playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel9 = true;
    }
    IEnumerator PLayEffect()
    {
        yield return new WaitForSeconds(1f);
        ParticleSystem psStar = Instantiate(Effect_01);
        ParticleSystem psStar2 = Instantiate(Effect_02);
        psStar.transform.SetParent(EffectsPrefabContainer, false);
        psStar2.transform.SetParent(EffectsPrefabContainer, false);
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

    public void ContinueNextLevel(int level)
    {
        SceneManager.LoadScene(level);
        playersaveSystem.GetComponent<PlayerSaveSystem>().SaveGame();
    }
}
