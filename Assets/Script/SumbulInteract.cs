using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumbulInteract : MonoBehaviour
{
    float distance;
    [SerializeField] Animator anim;
    //public GameObject objectInteraction;
    //public GameObject InteractionUI;
    bool isTalking = false;
    private float targetWeight;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TalkingInteract()
    {
        Debug.Log("Hi, My Name is Sumbul. What Can I Do For You Young Man?");
        anim.SetBool("Angry",true);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sumbul masuk");
        if (other.tag == "Player")
        {
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("sumbul Keluar");
        anim.SetBool("Angry", false);
    }
}
