using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NPCHeadLookAt : MonoBehaviour
{
    [SerializeField] private Rig rig;
    [SerializeField] private Transform headlook;

    private bool islooking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float targetweight = islooking ? 1f : 0f;
        float lerpspeed = 2f;
        rig.weight = Mathf.Lerp(rig.weight, targetweight, Time.deltaTime * lerpspeed);
    }

    public void LookAt(Vector3 lookatposition)
    {
        islooking = true;
        headlook.position = lookatposition;
    }
}
