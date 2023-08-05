using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine.UI;

public class InteractionPopUp : MonoBehaviour
{
    // public NPCDialogue npc;

    float distance;
    public GameObject objectInteraction;
    public GameObject InteractionUI;
    bool isTalking = false;

    void Start()
    {
        InteractionUI.SetActive(false);
    }

void StartDialogue()
    {
        isTalking = true;
        InteractionUI.SetActive(true);
    }

    void EndDialogue()
    {
        isTalking = false;
        InteractionUI.SetActive(false);
    }

    void chooseAnswer()
    {
        if (isTalking == true && Input.GetKeyDown(KeyCode.Alpha1))
        {

        }
    }
}
