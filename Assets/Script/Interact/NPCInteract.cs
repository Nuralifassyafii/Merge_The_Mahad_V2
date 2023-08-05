using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    private NPCHeadLookAt npchead;

    private void Awake()
    {
        npchead = GetComponent<NPCHeadLookAt>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(Transform interactortransform) {
        float playerheight = 1.7f;
        npchead.LookAt(interactortransform.position + Vector3.up * playerheight);
    }
}
