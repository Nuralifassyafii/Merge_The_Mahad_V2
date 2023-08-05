using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public ScriptableItem item;
    public GameObject panel;
    public KeyCode OpenChestKey;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Input.GetKeyDown(OpenChestKey))
            {
                if(item.keyItem < 1)
                {
                    Debug.Log("cari Kunci Terlebih Dahulu");
                }
                else
                {
                    panel.SetActive(true);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
