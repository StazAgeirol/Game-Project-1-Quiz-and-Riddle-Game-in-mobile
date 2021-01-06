using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerSaveSystem : MonoBehaviour
{
    public static PlayerSaveSystem Plyr;
    public bool PArticle_bool;
    public bool MusicBackground_bool;
    public float volume = 0f;
    public bool Tutiroal_BoolMainScene;
    public bool Tutiroal_BoolCategoryScene;
    public bool Tutiroal_BoolRiddleScene;
    public bool Tutiroal_BoolMemorYGame;
    public bool Riddlelevel1;
    public bool Riddlelevel2;
    public bool Riddlelevel3;
    public bool Riddlelevel4;
    public bool Riddlelevel5;
    public bool Riddlelevel6;
    public bool Riddlelevel7;
    public bool Riddlelevel8;
    public bool Riddlelevel9;

    public bool Memorylevel1;
    public bool Memorylevel2;
    public bool Memorylevel3;
    public bool Memorylevel4;
    public bool Memorylevel5;
    public bool Memorylevel6;
    public bool Memorylevel7;
    public bool Memorylevel8;
    public bool Memorylevel9;

    public string RiddleScore_1;
    public string RiddleScore_2;
    public string RiddleScore_3;
    public string RiddleScore_4;
    public string RiddleScore_5;
    public string RiddleScore_6;
    public string RiddleScore_7;
    public string RiddleScore_8;
    public string RiddleScore_9;

    public string MemorygameScore_1;
    public string MemorygameScore_2;
    public string MemorygameScore_3;
    public string MemorygameScore_4;
    public string MemorygameScore_5;
    public string MemorygameScore_6;
    public string MemorygameScore_7;
    public string MemorygameScore_8;
    public string MemorygameScore_9;

    public string RiddleTime_1;
    public string RiddleTime_2;
    public string RiddleTime_3;
    public string RiddleTime_4;
    public string RiddleTime_5;
    public string RiddleTime_6;
    public string RiddleTime_7;
    public string RiddleTime_8;
    public string RiddleTime_9;

    public string MemorygameTime_1;
    public string MemorygameTime_2;
    public string MemorygameTime_3;
    public string MemorygameTime_4;
    public string MemorygameTime_5;
    public string MemorygameTime_6;
    public string MemorygameTime_7;
    public string MemorygameTime_8;
    public string MemorygameTime_9;

    

    
    void Start()
    {

    }
    private void OnEnable()
    {
        LoadGame();
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPayer();
        PArticle_bool = data.PArticle_bool;
        Tutiroal_BoolCategoryScene = data.Tutorial_CategoryScene;
        Tutiroal_BoolMainScene = data.Tutorial_MainScene;
        Tutiroal_BoolMemorYGame = data.Tutorial_MemoryGame;
        Tutiroal_BoolRiddleScene = data.Tutorial_RiddleScene;
        Tutiroal_BoolRiddleScene = data.Tutorial_RiddleScene;
        MusicBackground_bool = data.MusicBackground_bool;
        volume = data.volume;
        Riddlelevel1 = data.Riddlelevel1;
        Riddlelevel2 = data.Riddlelevel2;
        Riddlelevel3 = data.Riddlelevel3;
        Riddlelevel4 = data.Riddlelevel4;
        Riddlelevel5 = data.Riddlelevel5;
        Riddlelevel6 = data.Riddlelevel6;
        Riddlelevel7 = data.Riddlelevel7;
        Riddlelevel8 = data.Riddlelevel8;
        Riddlelevel9 = data.Riddlelevel9;
        RiddleScore_1 = data.RiddleScore_1;
        RiddleScore_2 = data.RiddleScore_2;
        RiddleScore_3 = data.RiddleScore_3;
        RiddleScore_4 = data.RiddleScore_4;
        RiddleScore_5 = data.RiddleScore_5;
        RiddleScore_6 = data.RiddleScore_6;
        RiddleScore_7 = data.RiddleScore_7;
        RiddleScore_8 = data.RiddleScore_8;
        RiddleScore_9 = data.RiddleScore_9;
        RiddleTime_1 = data.RiddleTime_1;
        RiddleTime_2 = data.RiddleTime_2;
        RiddleTime_3 = data.RiddleTime_3;
        RiddleTime_4 = data.RiddleTime_4;
        RiddleTime_5 = data.RiddleTime_5;
        RiddleTime_6 = data.RiddleTime_6;
        RiddleTime_7 = data.RiddleTime_7;
        RiddleTime_8 = data.RiddleTime_8;
        RiddleTime_9 = data.RiddleTime_9;
        Memorylevel1 = data.Memorygamelevel1;
        Memorylevel2 = data.Memorygamelevel2;
        Memorylevel3 = data.Memorygamelevel3;
        Memorylevel4 = data.Memorygamelevel4;
        Memorylevel5 = data.Memorygamelevel5;
        Memorylevel6 = data.Memorygamelevel6;
        Memorylevel7 = data.Memorygamelevel7;
        Memorylevel8 = data.Memorygamelevel8;
        Memorylevel9 = data.Memorygamelevel9;
        MemorygameScore_1 = data.MemorygameScore_1;
        MemorygameScore_2 = data.MemorygameScore_2;
        MemorygameScore_3 = data.MemorygameScore_3;
        MemorygameScore_4 = data.MemorygameScore_4;
        MemorygameScore_5 = data.MemorygameScore_5;
        MemorygameScore_6 = data.MemorygameScore_6;
        MemorygameScore_7 = data.MemorygameScore_7;
        MemorygameScore_8 = data.MemorygameScore_8;
        MemorygameScore_9 = data.MemorygameScore_9;
        MemorygameTime_1 = data.MemorygameTime_1;
        MemorygameTime_2 = data.MemorygameTime_2;
        MemorygameTime_3 = data.MemorygameTime_3;
        MemorygameTime_4 = data.MemorygameTime_4;
        MemorygameTime_5 = data.MemorygameTime_5;
        MemorygameTime_6 = data.MemorygameTime_6;
        MemorygameTime_7 = data.MemorygameTime_7;
        MemorygameTime_8 = data.MemorygameTime_8;
        MemorygameTime_9 = data.MemorygameTime_9;

    }
    

    public void SaveGame()
    {
        SaveSystem.SavePlayer(this);

    }

}
