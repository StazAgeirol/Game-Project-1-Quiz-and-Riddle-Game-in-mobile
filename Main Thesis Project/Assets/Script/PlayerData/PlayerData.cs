using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class PlayerData
{
    public bool Tutorial_MainScene;
    public bool Tutorial_CategoryScene;
    public bool Tutorial_RiddleScene;
    public bool Tutorial_MemoryGame;
    public bool MusicBackground_bool;
    public float volume;
    public bool PArticle_bool;
    public bool Riddlelevel1;
    public bool Riddlelevel2;
    public bool Riddlelevel3;
    public bool Riddlelevel4;
    public bool Riddlelevel5;
    public bool Riddlelevel6;
    public bool Riddlelevel7;
    public bool Riddlelevel8;
    public bool Riddlelevel9;
    public string RiddleScore_1;
    public string RiddleScore_2;
    public string RiddleScore_3;
    public string RiddleScore_4;
    public string RiddleScore_5;
    public string RiddleScore_6;
    public string RiddleScore_7;
    public string RiddleScore_8;
    public string RiddleScore_9;
    public string RiddleTime_1;
    public string RiddleTime_2;
    public string RiddleTime_3;
    public string RiddleTime_4;
    public string RiddleTime_5;
    public string RiddleTime_6;
    public string RiddleTime_7;
    public string RiddleTime_8;
    public string RiddleTime_9;


    public bool Memorygamelevel1;
    public bool Memorygamelevel2;
    public bool Memorygamelevel3;
    public bool Memorygamelevel4;
    public bool Memorygamelevel5;
    public bool Memorygamelevel6;
    public bool Memorygamelevel7;
    public bool Memorygamelevel8;
    public bool Memorygamelevel9;
    public string MemorygameScore_1;
    public string MemorygameScore_2;
    public string MemorygameScore_3;
    public string MemorygameScore_4;
    public string MemorygameScore_5;
    public string MemorygameScore_6;
    public string MemorygameScore_7;
    public string MemorygameScore_8;
    public string MemorygameScore_9;
    public string MemorygameTime_1;
    public string MemorygameTime_2;
    public string MemorygameTime_3;
    public string MemorygameTime_4;
    public string MemorygameTime_5;
    public string MemorygameTime_6;
    public string MemorygameTime_7;
    public string MemorygameTime_8;
    public string MemorygameTime_9;


    public PlayerData (PlayerSaveSystem plry)
    {
        Tutorial_MainScene = plry.Tutiroal_BoolMainScene;
        Tutorial_CategoryScene = plry.Tutiroal_BoolCategoryScene;
        Tutorial_RiddleScene = plry.Tutiroal_BoolRiddleScene;
        Tutorial_MemoryGame = plry.Tutiroal_BoolMemorYGame;
        PArticle_bool = plry.PArticle_bool;
        MusicBackground_bool = plry.MusicBackground_bool;
        Riddlelevel1 = plry.Riddlelevel1;
        Riddlelevel2 = plry.Riddlelevel2;
        Riddlelevel3 = plry.Riddlelevel3;
        Riddlelevel4 = plry.Riddlelevel4;
        Riddlelevel5 = plry.Riddlelevel5;
        Riddlelevel6 = plry.Riddlelevel6;
        Riddlelevel7 = plry.Riddlelevel7;
        Riddlelevel8 = plry.Riddlelevel8;
        Riddlelevel9 = plry.Riddlelevel9;
        RiddleScore_1 = plry.RiddleScore_1;
        RiddleScore_2 = plry.RiddleScore_2;
        RiddleScore_3 = plry.RiddleScore_3;
        RiddleScore_4 = plry.RiddleScore_4;
        RiddleScore_5 = plry.RiddleScore_5;
        RiddleScore_6 = plry.RiddleScore_6;
        RiddleScore_7 = plry.RiddleScore_7;
        RiddleScore_8 = plry.RiddleScore_8;
        RiddleScore_9 = plry.RiddleScore_9;
        RiddleTime_1 = plry.RiddleTime_1;
        RiddleTime_2 = plry.RiddleTime_2;
        RiddleTime_3 = plry.RiddleTime_3;
        RiddleTime_4 = plry.RiddleTime_4;
        RiddleTime_5 = plry.RiddleTime_5;
        RiddleTime_6 = plry.RiddleTime_6;
        RiddleTime_7 = plry.RiddleTime_7;
        RiddleTime_8 = plry.RiddleTime_8;
        RiddleTime_9 = plry.RiddleTime_9;
        Memorygamelevel1 = plry.Memorylevel1;
        Memorygamelevel2 = plry.Memorylevel2;
        Memorygamelevel3 = plry.Memorylevel3;
        Memorygamelevel4 = plry.Memorylevel4;
        Memorygamelevel5 = plry.Memorylevel5;
        Memorygamelevel6 = plry.Memorylevel6;
        Memorygamelevel7 = plry.Memorylevel7;
        Memorygamelevel8 = plry.Memorylevel8;
        Memorygamelevel9 = plry.Memorylevel9;
        MemorygameScore_1 = plry.MemorygameScore_1;
        MemorygameScore_2 = plry.MemorygameScore_2;
        MemorygameScore_3 = plry.MemorygameScore_3;
        MemorygameScore_4 = plry.MemorygameScore_4;
        MemorygameScore_5 = plry.MemorygameScore_5;
        MemorygameScore_6 = plry.MemorygameScore_6;
        MemorygameScore_7 = plry.MemorygameScore_7;
        MemorygameScore_8 = plry.MemorygameScore_8;
        MemorygameScore_9 = plry.MemorygameScore_9;
        MemorygameTime_1 = plry.MemorygameTime_1;
        MemorygameTime_2 = plry.MemorygameTime_2;
        MemorygameTime_3 = plry.MemorygameTime_3;
        MemorygameTime_4 = plry.MemorygameTime_4;
        MemorygameTime_5 = plry.MemorygameTime_5;
        MemorygameTime_6 = plry.MemorygameTime_6;
        MemorygameTime_7 = plry.MemorygameTime_7;
        MemorygameTime_8 = plry.MemorygameTime_8;
        MemorygameTime_9 = plry.MemorygameTime_9;
    }

   
}
