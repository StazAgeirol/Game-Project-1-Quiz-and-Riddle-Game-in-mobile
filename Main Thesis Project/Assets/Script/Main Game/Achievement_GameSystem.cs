using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement_GameSystem : MonoBehaviour
{
    public Image SliderRilddeGameLevel1;
    public Image SliderRilddeGameLevel2;
    public Image SliderRilddeGameLevel3;
    public Image SliderRilddeGameLevel4;
    public Image SliderRilddeGameLevel5;
    public Image SliderRilddeGameLevel6;
    public Image SliderRilddeGameLevel7;
    public Image SliderRilddeGameLevel8;
    public Image SliderRilddeGameLevel9;
    public Text TextRiddleGamelevel1;
    public Text TextRiddleGamelevel2;
    public Text TextRiddleGamelevel3;
    public Text TextRiddleGamelevel4;
    public Text TextRiddleGamelevel5;
    public Text TextRiddleGamelevel6;
    public Text TextRiddleGamelevel7;
    public Text TextRiddleGamelevel8;
    public Text TextRiddleGamelevel9;
    public Image ImageRiddleGamelevel1;
    public Image ImageRiddleGamelevel2;
    public Image ImageRiddleGamelevel3;
    public Image ImageRiddleGamelevel4;
    public Image ImageRiddleGamelevel5;
    public Image ImageRiddleGamelevel6;
    public Image ImageRiddleGamelevel7;
    public Image ImageRiddleGamelevel8;
    public Image ImageRiddleGamelevel9;
    public Image ImageRiddleGamelevel1Default;
    public Image ImageRiddleGamelevel2Default;
    public Image ImageRiddleGamelevel3Default;
    public Image ImageRiddleGamelevel4Default;
    public Image ImageRiddleGamelevel5Default;
    public Image ImageRiddleGamelevel6Default;
    public Image ImageRiddleGamelevel7Default;
    public Image ImageRiddleGamelevel8Default;
    public Image ImageRiddleGamelevel9Default;

    public Image SlideMemoryGamelevel1;
    public Image SlideMemoryGamelevel2;
    public Image SlideMemoryGamelevel3;
    public Image SlideMemoryGamelevel4;
    public Image SlideMemoryGamelevel5;
    public Image SlideMemoryGamelevel6;
    public Image SlideMemoryGamelevel7;
    public Image SlideMemoryGamelevel8;
    public Image SlideMemoryGamelevel9;
    public Text TextMemoryGamelevel1;
    public Text TextMemoryGamelevel2;
    public Text TextMemoryGamelevel3;
    public Text TextMemoryGamelevel4;
    public Text TextMemoryGamelevel5;
    public Text TextMemoryGamelevel6;
    public Text TextMemoryGamelevel7;
    public Text TextMemoryGamelevel8;
    public Text TextMemoryGamelevel9;
    public Image ImageMemoryGamelevel1;
    public Image ImageMemoryGamelevel2;
    public Image ImageMemoryGamelevel3;
    public Image ImageMemoryGamelevel4;
    public Image ImageMemoryGamelevel5;
    public Image ImageMemoryGamelevel6;
    public Image ImageMemoryGamelevel7;
    public Image ImageMemoryGamelevel8;
    public Image ImageMemoryGamelevel9;
    public Image ImageMemoryGamelevel1Default;
    public Image ImageMemoryGamelevel2Default;
    public Image ImageMemoryGamelevel3Default;
    public Image ImageMemoryGamelevel4Default;
    public Image ImageMemoryGamelevel5Default;
    public Image ImageMemoryGamelevel6Default;
    public Image ImageMemoryGamelevel7Default;
    public Image ImageMemoryGamelevel8Default;
    public Image ImageMemoryGamelevel9Default;

    private List<Image> List_Slider = new List<Image>();
    private List<Image> List_Image = new List<Image>();
    private List<Text> List_Text = new List<Text>();

    private List<Image> List_Slider_mg = new List<Image>();
    private List<Image> List_Image_mg = new List<Image>();
    private List<Text> List_Text_mg = new List<Text>();
    private GameObject playersaveSystem;
    

    void Start()
    {
        List_Slider.Add(SliderRilddeGameLevel1);
        List_Slider.Add(SliderRilddeGameLevel2);
        List_Slider.Add(SliderRilddeGameLevel3);
        List_Slider.Add(SliderRilddeGameLevel4);
        List_Slider.Add(SliderRilddeGameLevel5);
        List_Slider.Add(SliderRilddeGameLevel6);
        List_Slider.Add(SliderRilddeGameLevel7);
        List_Slider.Add(SliderRilddeGameLevel8);
        List_Slider.Add(SliderRilddeGameLevel9);
        foreach (Image item in List_Slider)
        {
            item.fillAmount = 0.046f;
        }

        List_Text.Add(TextRiddleGamelevel1);
        List_Text.Add(TextRiddleGamelevel2);
        List_Text.Add(TextRiddleGamelevel3);
        List_Text.Add(TextRiddleGamelevel4);
        List_Text.Add(TextRiddleGamelevel5);
        List_Text.Add(TextRiddleGamelevel6);
        List_Text.Add(TextRiddleGamelevel7);
        List_Text.Add(TextRiddleGamelevel8);
        List_Text.Add(TextRiddleGamelevel9);

        foreach (Text item in List_Text)
        {
            item.text = "0/1";
        }

        List_Image.Add(ImageRiddleGamelevel1);
        List_Image.Add(ImageRiddleGamelevel2);
        List_Image.Add(ImageRiddleGamelevel3);
        List_Image.Add(ImageRiddleGamelevel4);
        List_Image.Add(ImageRiddleGamelevel5);
        List_Image.Add(ImageRiddleGamelevel6);
        List_Image.Add(ImageRiddleGamelevel7);
        List_Image.Add(ImageRiddleGamelevel8);
        List_Image.Add(ImageRiddleGamelevel9);
        foreach (Image item in List_Image)
        {
            item.gameObject.SetActive(false);
        }
        playersaveSystem = GameObject.Find("PlayerSaveSystem");

        playersaveSystem.GetComponent<PlayerSaveSystem>();

        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel1 == true)
        {
            SliderRilddeGameLevel1.fillAmount = 1f;
            TextRiddleGamelevel1.text = "1/1";
            ImageRiddleGamelevel1Default.gameObject.SetActive(false);
            ImageRiddleGamelevel1.gameObject.SetActive(true);
        }

        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel2 == true)
        {
            SliderRilddeGameLevel2.fillAmount = 1f;
            TextRiddleGamelevel2.text = "1/1";
            ImageRiddleGamelevel2Default.gameObject.SetActive(false);
            ImageRiddleGamelevel2.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel3 == true)
        {
            SliderRilddeGameLevel3.fillAmount = 1f;
            TextRiddleGamelevel3.text = "1/1";
            ImageRiddleGamelevel3Default.gameObject.SetActive(false);
            ImageRiddleGamelevel3.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel4 == true)
        {
            SliderRilddeGameLevel4.fillAmount = 1f;
            TextRiddleGamelevel4.text = "1/1";
            ImageRiddleGamelevel4Default.gameObject.SetActive(false);
            ImageRiddleGamelevel4.gameObject.SetActive(true);
        }

        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel5 == true)
        {
            SliderRilddeGameLevel5.fillAmount = 1f;
            TextRiddleGamelevel5.text = "1/1";
            ImageRiddleGamelevel5Default.gameObject.SetActive(false);
            ImageRiddleGamelevel5.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel6 == true)
        {
            SliderRilddeGameLevel6.fillAmount = 1f;
            TextRiddleGamelevel6.text = "1/1";
            ImageRiddleGamelevel6Default.gameObject.SetActive(false);
            ImageRiddleGamelevel6.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel7 == true)
        {
            SliderRilddeGameLevel7.fillAmount = 1f;
            TextRiddleGamelevel7.text = "1/1";
            ImageRiddleGamelevel7Default.gameObject.SetActive(false);
            ImageRiddleGamelevel7.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel8 == true)
        {
            SliderRilddeGameLevel8.fillAmount = 1f;
            TextRiddleGamelevel8.text = "1/1";
            ImageRiddleGamelevel8Default.gameObject.SetActive(false);
            ImageRiddleGamelevel8.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Riddlelevel9 == true)
        {
            SliderRilddeGameLevel9.fillAmount = 1f;
            TextRiddleGamelevel9.text = "1/1";
            ImageRiddleGamelevel9Default.gameObject.SetActive(false);
            ImageRiddleGamelevel9.gameObject.SetActive(true);
        }

        List_Slider.Add(SlideMemoryGamelevel1);
        List_Slider.Add(SlideMemoryGamelevel2);
        List_Slider.Add(SlideMemoryGamelevel3);
        List_Slider.Add(SlideMemoryGamelevel4);
        List_Slider.Add(SlideMemoryGamelevel5);
        List_Slider.Add(SlideMemoryGamelevel6);
        List_Slider.Add(SlideMemoryGamelevel7);
        List_Slider.Add(SlideMemoryGamelevel8);
        List_Slider.Add(SlideMemoryGamelevel9);
        foreach (Image item in List_Slider_mg)
        {
            item.fillAmount = 0.046f;
        }

        List_Text.Add(TextMemoryGamelevel1);
        List_Text.Add(TextMemoryGamelevel2);
        List_Text.Add(TextMemoryGamelevel3);
        List_Text.Add(TextMemoryGamelevel4);
        List_Text.Add(TextMemoryGamelevel5);
        List_Text.Add(TextMemoryGamelevel6);
        List_Text.Add(TextMemoryGamelevel7);
        List_Text.Add(TextMemoryGamelevel8);
        List_Text.Add(TextMemoryGamelevel9);

        foreach (Text item in List_Text_mg)
        {
            item.text = "0/1";
        }

        List_Image.Add(ImageMemoryGamelevel1);
        List_Image.Add(ImageMemoryGamelevel2);
        List_Image.Add(ImageMemoryGamelevel3);
        List_Image.Add(ImageMemoryGamelevel4);
        List_Image.Add(ImageMemoryGamelevel5);
        List_Image.Add(ImageMemoryGamelevel6);
        List_Image.Add(ImageMemoryGamelevel7);
        List_Image.Add(ImageMemoryGamelevel8);
        List_Image.Add(ImageMemoryGamelevel9);

        foreach (Image item in List_Image_mg)
        {
            item.gameObject.SetActive(false);
        }

        playersaveSystem = GameObject.Find("PlayerSaveSystem");

        playersaveSystem.GetComponent<PlayerSaveSystem>();

        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Memorylevel1 == true)
        {
            SlideMemoryGamelevel1.fillAmount = 1f;
            TextMemoryGamelevel1.text = "1/1";
            ImageMemoryGamelevel1Default.gameObject.SetActive(false);
            ImageMemoryGamelevel1.gameObject.SetActive(true);
        }

        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Memorylevel2 == true)
        {
            SlideMemoryGamelevel2.fillAmount = 1f;
            TextMemoryGamelevel2.text = "1/1";
            ImageMemoryGamelevel2Default.gameObject.SetActive(false);
            ImageMemoryGamelevel2.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Memorylevel3 == true)
        {
            SlideMemoryGamelevel3.fillAmount = 1f;
            TextMemoryGamelevel3.text = "1/1";
            ImageMemoryGamelevel3Default.gameObject.SetActive(false);
            ImageMemoryGamelevel3.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Memorylevel4 == true)
        {
            SlideMemoryGamelevel4.fillAmount = 1f;
            TextMemoryGamelevel4.text = "1/1";
            ImageMemoryGamelevel4Default.gameObject.SetActive(false);
            ImageMemoryGamelevel4.gameObject.SetActive(true);
        }

        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Memorylevel5 == true)
        {
            SlideMemoryGamelevel5.fillAmount = 1f;
            TextMemoryGamelevel5.text = "1/1";
            ImageMemoryGamelevel5Default.gameObject.SetActive(false);
            ImageMemoryGamelevel5.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Memorylevel6 == true)
        {
            SlideMemoryGamelevel6.fillAmount = 1f;
            TextMemoryGamelevel6.text = "1/1";
            ImageMemoryGamelevel6Default.gameObject.SetActive(false);
            ImageMemoryGamelevel6.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Memorylevel7 == true)
        {
            SlideMemoryGamelevel7.fillAmount = 1f;
            TextMemoryGamelevel7.text = "1/1";
            ImageMemoryGamelevel7Default.gameObject.SetActive(false);
            ImageMemoryGamelevel7.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Memorylevel8 == true)
        {
            SlideMemoryGamelevel8.fillAmount = 1f;
            TextMemoryGamelevel8.text = "1/1";
            ImageMemoryGamelevel8Default.gameObject.SetActive(false);
            ImageMemoryGamelevel8.gameObject.SetActive(true);
        }
        if (playersaveSystem.GetComponent<PlayerSaveSystem>().Memorylevel9 == true)
        {
            SlideMemoryGamelevel9.fillAmount = 1f;
            TextMemoryGamelevel9.text = "1/1";
            ImageMemoryGamelevel9Default.gameObject.SetActive(false);
            ImageMemoryGamelevel9.gameObject.SetActive(true);
        }
    }
}
