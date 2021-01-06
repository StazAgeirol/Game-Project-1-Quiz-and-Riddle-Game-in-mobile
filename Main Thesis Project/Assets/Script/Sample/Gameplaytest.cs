using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class Gameplaytest : MonoBehaviour
{
    public Animator animator;
    public Animator SAchieveanimator;
    public Animator messagepop;

    private float timermessage = 4f;
    public Text QuestionField;
    public Text QuestionCountText;
    public Text ScoreFieldText;
    public Text Points;
    public Text ShowtextAnswer;

    public Button HintButton;
    public GameObject GameQuestion;
    public GameObject SA;
    public GameObject ReviewGo;
    public Image result;
    public GameObject AnswerText;
    private List<GameObject> AnswerItem;

    public Text ShowHintText;
    public Button NextButton;
    private int Hintnum = 3;
    public Text Hinttexnum;


    public InputField usertype;


    private int TotalAnswer = 0;
    private bool Pause;
    public Image CorrectAnswer;
    public Image WrongAnswer;



    List<QuestionTemplate> Questions;

    private float ramdomNumber;
    private int QuestionCount = 0;

    private int TotalQuestionPerRound = 50;


    public Text OverallTime;
    public Text TimerText;
    public Text Timeofgame;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    private bool timeofgamestop = false;
    private float timeLeft = 60f;
    public Button ProgressButton;
    public int Score = 0;
    List<string> randStr = new List<string>();
    public GameObject Buttonprefab;
    public Transform ButtonContainer;
    public Transform spellword;
    public int wordLen;


    void Start()
    {
        GameQuestion.gameObject.SetActive(false);
        messagepop.SetBool("IsTrigger", true);
        

        timeofgamestop = true;
        ProgressButton.gameObject.SetActive(false);
        Pause = true;
        usertype = GameObject.Find("InputField").GetComponent<InputField>();

        CorrectAnswer.gameObject.SetActive(false);

        WrongAnswer.gameObject.SetActive(false);

        NextButton.gameObject.SetActive(false);

        AnswerItem = new List<GameObject>();

        Questions = new List<QuestionTemplate>();



        Questions.Add(new QuestionTemplate(1, "I am a three digit number. My tens digit is five more than my ones digit. My hundreds digit is eight less than my tens digit. What number am I?", "Number 194", "N"));
        Questions.Add(new QuestionTemplate(2, "What are moving left to right, right now?", "Eyes", "E"));
        Questions.Add(new QuestionTemplate(3, "If a rooster laid a brown egg and a white egg, what kind of chicks would hatch?", "Roosters don't lay eggs", "R"));
        Questions.Add(new QuestionTemplate(4, "I have two hands, but I can not scratch myself. What am I?", "Clock", "C"));
        Questions.Add(new QuestionTemplate(5, "What's a lifeguard's favorite game?", "Pool", "P"));
        Questions.Add(new QuestionTemplate(6, "What always runs but never walks, often murmurs, never talks, has a bed but never sleeps, has a mouth but never eats?", "River", " R"));
        Questions.Add(new QuestionTemplate(7, "Flat as a leaf, round as a ring; Has two eyes, can't see a thing.  What is it?", "Button", "B"));
        Questions.Add(new QuestionTemplate(8, "I have a head and a tail but no body... What am I?", "Coin", "C"));
        Questions.Add(new QuestionTemplate(9, "I have no feet, no hands, no wings, but I climb to the sky. What am I?", "Smoke", "S"));
        Questions.Add(new QuestionTemplate(10, "Tool of thief, toy of queen. Always used to be unseen. Sign of joy, sign of sorrow. Giving all likeness borrowed. What am I?", "Mask", "M"));
        Questions.Add(new QuestionTemplate(11, "What kind of nut has no shell?", "Donut", "D"));
        Questions.Add(new QuestionTemplate(12, "What food lives at the beach?", "Sandwich", "S"));
        Questions.Add(new QuestionTemplate(13, "I have hundreds of legs but I can only lean;  You make me feel dirty so you feel clean.  What am I?", "Broom", "B"));
        Questions.Add(new QuestionTemplate(14, "What is shaped like a box, has no feet, and runs up and down?", "Elevator", "E"));
        Questions.Add(new QuestionTemplate(15, "Four fingers and a thumb,  Yet flesh and blood,  I have none. What am I? ", "Glove", "G"));
        Questions.Add(new QuestionTemplate(16, "What runs without legs?", "Water", "W"));
        Questions.Add(new QuestionTemplate(17, "What can hold water even though it has holes?", "Sponge", "S"));
        Questions.Add(new QuestionTemplate(18, "A slender body, a tiny eye, no matter what happens, I never cry. What am I?", "Needle", "N"));
        Questions.Add(new QuestionTemplate(19, "What word contains all of the twenty six letters?", "Alphabet", "A"));
        Questions.Add(new QuestionTemplate(20, "I am the breath of relief and depression. What am I?", "Sigh", "S"));
        Questions.Add(new QuestionTemplate(21, "Voiceless it cries, Wingless flutters, Toothless bites, Mouthless mutters. What is it?", "Wind", "W"));
        Questions.Add(new QuestionTemplate(22, "The more you take, the more you leave behind. What am I?", "Footsep", "F"));
        Questions.Add(new QuestionTemplate(23, "David's father has three sons : Snap, Crackle and _____ ??", "David", "D"));
        Questions.Add(new QuestionTemplate(24, "What belongs to you, but other people use it more than you?", "Name", "N"));
        Questions.Add(new QuestionTemplate(25, "What can point in every direction but can't reach the destination by itself.", "Finger", "F"));
        Questions.Add(new QuestionTemplate(26, "I am not alive, but I grow; I don't have lungs, but I need air; I don't have a mouth, but water kills me. What am I?", "Fire", "F"));
        Questions.Add(new QuestionTemplate(27, "This is as light as a feather, yet no man can hold it for long. What am I?", "Breathing", "B"));
        Questions.Add(new QuestionTemplate(28, "Poor people have it. Rich people need it. If you eat it you die. what is it?", "Nothing", "N"));
        Questions.Add(new QuestionTemplate(29, "What goes up when the rain comes down?", "Umbrella", "U"));
        Questions.Add(new QuestionTemplate(30, "I make two people out of one.  What am I?", "Mirror", "M"));
        Questions.Add(new QuestionTemplate(31, "What travels around the world but stays in one spot?", "Stamp", "S"));
        Questions.Add(new QuestionTemplate(32, "There is an ancient invention still used in some parts of the world today that allows people to see through walls. What is it?", "Window", "W"));
        Questions.Add(new QuestionTemplate(33, "If you have me, you want to share me. If you share me, you haven't got me. What am I?", "Secret", "S"));
        Questions.Add(new QuestionTemplate(34, "If seven cats kill seven rats in 7 minutes, how many would be needed to kill one hundred rats in 50 minutes?", "14", "fist number 1"));
        Questions.Add(new QuestionTemplate(35, "What five long word become shorter when you add two letters", "Short", "S"));
        Questions.Add(new QuestionTemplate(36, "Two friends stand and travel together, one nearly useless without the other", "Boots", "B"));
        Questions.Add(new QuestionTemplate(37, "Men desire me in public, but fear me in private", "Truth", "T"));
        Questions.Add(new QuestionTemplate(38, "What is so fragile, even speaking its name will break it?", "Silence", "S"));
        Questions.Add(new QuestionTemplate(39, "Brought to the table. Cut and served. Never eaten", "Card", "C"));
        Questions.Add(new QuestionTemplate(40, "It is a journey whose path depends, on an other’s vision of where it ends. ", "Book", "B"));
        Questions.Add(new QuestionTemplate(41, "Men seize it from its home, tear apart its flesh, drink the sweet blood, then cast its skin aside.", "Orange", "O"));
        Questions.Add(new QuestionTemplate(42, "In the form of fork or sheet, I hit the ground. And if you wait a heartbeat, You can hear my roaring sound", "Lightning", "L"));
        Questions.Add(new QuestionTemplate(43, "I have no tears but I perspire, I stretch but cannot respire, I can jump, walk, run and dance, Though I have no mind. I’ll take a stance. What am I?", "Leg", "L"));
        Questions.Add(new QuestionTemplate(44, "The more you walk on me the more we get along, and while other may still use me, with you is where I belong. What am I?", "Shoes", "S"));
        Questions.Add(new QuestionTemplate(45, "Up and down they go and travel, but never do they move an inch", "Stairs", "S"));
        Questions.Add(new QuestionTemplate(46, "The more you take, the more you leave behind. What am I? ", "Footsteps", "F"));
        Questions.Add(new QuestionTemplate(47, "What has a head and a tail, can flip but has no legs?", "Coin", "C"));
        Questions.Add(new QuestionTemplate(48, "If I’m in front I don’t matter, If I’m in back I make everything be more, I am something yet I am nothing. What am I?", "Zero", "Z"));
        Questions.Add(new QuestionTemplate(49, "I am taken from a mine, and shut up in a wooden case, from which I am never released, and yet I am used by almost everybody", "Pencil lead", "P"));
        Questions.Add(new QuestionTemplate(50, "What tastes better than it smells?", "Tongue", "T"));
        Questions.Add(new QuestionTemplate(51, "At night they come without being fetched. By day they are lost without being stolen. What are they?", "Stars", "S"));
        Questions.Add(new QuestionTemplate(52, "Each morning I appear to lie at your feet, All day I will follow no matter how fast you run, Yet I nearly perish in the midday sun.", "Shadow", "S"));
        Questions.Add(new QuestionTemplate(53, "My life can be measured in hours, I serve by being devoured. Thin, I am quick Fat, I am slow Wind is my foe.", "Candle", "C"));
        Questions.Add(new QuestionTemplate(54, "You heard me before, yet you hear me again, Then I die, ’till you call me again.", "Echo", "E"));
        Questions.Add(new QuestionTemplate(55, "Three lives have I. Gentle enough to soothe the skin, Light enough to caress the sky, Hard enough to crack rocks", "Water", "W"));
        Questions.Add(new QuestionTemplate(56, "At the sound of me, men may dream or stamp their feet, At the sound of me, women may laugh or sometimes weep.", "Music", "M"));
        Questions.Add(new QuestionTemplate(57, "Say my name and I disappear. What am I?", "Silence", "S"));
        Questions.Add(new QuestionTemplate(58, "Alive without breath, As cold as death, Clad in mail never clinking, Never thirsty, ever drinking", "Fish", "F"));
        Questions.Add(new QuestionTemplate(59, "I have keys without key locks. I have space without rooms. You can enter but you cannot go outside.", "Keyboard", "K"));
        Questions.Add(new QuestionTemplate(60, "I have forests but no trees. I have lakes but no water. I have roads but no cars.  What Am I?", "Map", "M"));
        Questions.Add(new QuestionTemplate(61, "Passed from father to son, And shared between brothers. Its importance is unquestioned, Though it is used more by others. ", "Name", "N"));



        NextButtonClick();
    }


    public void ShowHInt()
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
    public void Progress()
    {

        GameQuestion.gameObject.SetActive(false);
        result.gameObject.SetActive(true);
        //GameControl.control.Save();

    }
    public void ShowA()
    {
        SA.gameObject.SetActive(true);
    }

    public void PlayAgian()
    {
        SceneManager.LoadScene(1);
    }
    public void CloseReview()
    {
        ReviewGo.gameObject.SetActive(false);
    }

    public void CloaseAchievement()
    {
        SAchieveanimator.SetBool("IsTrigger", false);
    }
    public void ReturnHomeBt()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowAchievement()
    {
        SAchieveanimator.SetBool("IsTrigger", true);
    }

    public void NextButtonClick()
    {

        useranswer();

        HintButton.interactable = true;
        timeLeft = 60f;
        Pause = false;
        Time.timeScale = 1f;
        NextButton.gameObject.SetActive(false);
        CorrectAnswer.gameObject.SetActive(false);
        WrongAnswer.gameObject.SetActive(false);
        usertype.text = "";
        animator.SetBool("IsTrigger", false);

        QuestionCount = QuestionCount + 1;
        QuestionCountText.text = QuestionCount + "/" + TotalQuestionPerRound;


        if (QuestionCount == TotalQuestionPerRound)
        {
            NextButton.gameObject.SetActive(false);
        }
        ramdomNumber = UnityEngine.Random.Range(0, Questions.Count);
        /*PUT HERE  THE STARTING FUNCTION OF THE SCRIPT
         */
        for (int i = 0; i < Questions.Count; i++)
        {
            if (ramdomNumber == i)
            {
                animator.SetBool("IsTrigger", false);
                QuestionField.text = Questions[i].Question;
                TotalAnswer += 1;
                if (AnswerItem.Count == Questions.Count)
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
            }
        }

    }


    IEnumerator TimerScript()
    {

        if (QuestionCount == TotalQuestionPerRound + 1)
        {
            Time.timeScale = 1f;
            timeLeft = -1f;
            Progress();

        }
        timermessage -= Time.deltaTime;




        if (Mathf.Round(timermessage) == 0)
        {
            messagepop.SetBool("IsTrigger", false);
            GameQuestion.gameObject.SetActive(true);
            Pause = false;

        }

        yield return new WaitForSeconds(1f);
        timeLeft -= Time.deltaTime;
        TimerText.text = Mathf.Round(timeLeft).ToString();
        if (Mathf.Round(timeLeft) == 0)
        {

            WrongAnswer.gameObject.SetActive(true);
            QuestionField.text = ("Times UP !");
            Pause = true;
            timeLeft = 0f;



            if (QuestionCount == TotalQuestionPerRound)
            {
                timeofgamestop = true;
            }
            if (Mathf.Round(timeLeft) == 0f)
            {

            }

            NextButton.gameObject.SetActive(true);
        }


    }

    IEnumerator QuestionstText()
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


    void Update()
    {
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

        ScoreFieldText.text = "" + Score;

    }

    string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        return char.ToUpper(s[0]) + s.Substring(1);
    }
    public void useranswer()
    {


        Correcting();

    }
    void Correcting()
    {

        for (int i = 0; i < Questions.Count; i++)
        {
            if (ramdomNumber == i)
            {

                for (int var = 0; var < Questions[i].CorrectAnswer.Length; var++)
                {
                    char c = Questions[i].CorrectAnswer[Random.Range(0, Questions[i].CorrectAnswer.Length)];

                    if (randStr.Contains(c.ToString()))
                    {
                        var--;
                    }
                    else
                    {
                        randStr.Add(c.ToString());

                        for (int var2 = 0; var2 < randStr[var].Length; var2++)
                        {
                            GameObject go = Instantiate(Buttonprefab) as GameObject;
                            go.transform.SetParent(ButtonContainer);
                            Button tempButton = go.GetComponent<Button>();
                            string temp = randStr[var];
                            tempButton.onClick.AddListener(() => ButtonClick(temp));
                            string ClickedAnswer = go.GetComponentInChildren<Text>().text = randStr[var];

                        }
                    }
                }





                HintButton.interactable = false;

                RemoveQuestionsAfterDisplay();
            }


        }


    }
    void ButtonClick(string letter)
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

                        if (QuestionCount == TotalQuestionPerRound)
                        {
                            NextButton.gameObject.SetActive(false);
                            Time.timeScale = 1f;
                            ProgressButton.gameObject.SetActive(true);
                            timeofgamestop = false;



                        }
                        else
                        {
                            NextButton.gameObject.SetActive(true);

                        }
                    }
                    else
                    {
                        WrongAnswer.gameObject.SetActive(true);
                        CorrectAnswer.gameObject.SetActive(false);


                        if (QuestionCount == TotalQuestionPerRound)
                        {
                            NextButton.gameObject.SetActive(false);

                            Time.timeScale = 1f;
                            ProgressButton.gameObject.SetActive(true);
                            timeofgamestop = false;
                        }

                        else
                        {
                            NextButton.gameObject.SetActive(true);

                        }

                        Pause = true;

                    }

                }
            }
        }
    }
    void RemoveQuestionsAfterDisplay()
    {


        for (int i = 0; i < Questions.Count; i++)
        {
            if (ramdomNumber == i)
            {

                Questions.Remove(Questions[i]);


            }
        }

    }



    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        Timeofgame.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
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


        //void ShowAnswer()
        //{
        //    for (int i = 0; i < Questions.Count; i++)
        //    {
        //        if (ramdomNumber == i)
        //        {


        //        }
        //    }
        //}

    }

}





