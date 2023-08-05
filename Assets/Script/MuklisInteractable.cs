using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine.UI;

public class MuklisInteractable : MonoBehaviour
{
    // Start is called before the first frame update
    float distance;
    private Animator anim;
    public GameObject objectInteraction;
    public GameObject InteractionUI;
    bool isTalking = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        InteractionUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TalkingInteract()
    {
        Debug.Log("Hi, My Name is Muklis. What Can I Do For You Young Man?");
        anim.SetTrigger("talking");
        InteractionUI.SetActive(true);

    }

    public void WavingInteract()
    {
        Debug.Log("Byee");
        anim.SetTrigger("waving");
        InteractionUI.SetActive(false);
    }
    
}
