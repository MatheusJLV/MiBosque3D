using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDialogue : MonoBehaviour
{
    //public Dictionary<string, string> variables;
    [Header("Mini-Script para reemplazar las palabras $nombre e $institucion del Dialogue Trigger")]
    public Player player;
    public DialogueTrigger dialogueTrigger;

    void Start()
    {
        ChangeVariables();
    }

    void ChangeVariables()
    {
        PlayerData data = player.playerData;
        string finalDialogue = dialogueTrigger.dialogue.sentences[0];
        finalDialogue = finalDialogue.Replace("$nombre", data.nombre);
        finalDialogue = finalDialogue.Replace("$institucion", data.unidadEducativa);
        dialogueTrigger.dialogue.sentences[0] = finalDialogue;
    }
}
