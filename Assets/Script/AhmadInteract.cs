using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AhmadInteract : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WavingInteract()
    {
        Debug.Log("Hai, Player. I'm Ahmad, Enjoy The Game");
        anim.SetTrigger("waving");
    }

    public void BigJumpInteract()
    {
        Debug.Log("See This, I Bet You Can't Do It, Do Yaa?");
        anim.SetTrigger("bigjump");
    }

}
