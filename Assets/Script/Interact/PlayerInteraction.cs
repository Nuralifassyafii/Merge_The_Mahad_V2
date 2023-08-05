using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("Player masuk interaksi");
            float interactrange = 2f;
            Collider[] colliderarray = Physics.OverlapSphere(transform.position, interactrange);
            foreach(Collider collider in colliderarray) {
            if(collider.TryGetComponent(out NPCInteract nPCInteract))
            {
                    nPCInteract.interact(transform);
            }
                else
                {
                    Debug.Log("Pala gagal");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "NPC")
        {
            Debug.Log("Player Keluar Interaksi");
        }
    }
}
