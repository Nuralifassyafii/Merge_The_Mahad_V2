using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsInRange;
    public KeyCode IntercatKey;
    public UnityEvent InteractAction;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange)
        {
            if (Input.GetKeyDown(IntercatKey))
            {
                InteractAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            IsInRange = true;
            Debug.Log("Player masuk");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            IsInRange = false;
            Debug.Log("Player Keluar");
        }
    }
}