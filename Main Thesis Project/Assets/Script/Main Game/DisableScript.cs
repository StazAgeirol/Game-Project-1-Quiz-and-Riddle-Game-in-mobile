using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScript : MonoBehaviour
{
   public static DisableScript dsript;
    public GameObject DailogueManager;
    public void DisbleDialoguemanagerScriptMainScene()
    {
        
        (DailogueManager.GetComponent<DialogueManagerMainScene>()as MonoBehaviour).enabled = false;
        DailogueManager.GetComponent<DialogueManagerMainScene>().enabled = false;
    }
}
