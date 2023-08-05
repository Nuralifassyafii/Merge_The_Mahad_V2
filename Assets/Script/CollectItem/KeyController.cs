using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public ScriptableItem item;
    public KeyCode collectItemKey;

    public GameObject keyObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        { 
        if (Input.GetKey(collectItemKey))
        {
            item.keyItem += 1;
            keyObject.SetActive(false);
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
