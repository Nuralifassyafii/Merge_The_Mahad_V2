using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HeadLookAtRig : MonoBehaviour
{
    // Start is called before the first frame update
    private Rig rig;
    private float targetWeight;

    private void Awake()
    {
        rig = GetComponent<Rig>();
    }

    private void Update()
    {
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * 10f);
               if (Input.GetKeyDown(KeyCode.O))
                {
                    LookAt();
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    StopLookAt();
                }
    }

    public void LookAt()
    {
        targetWeight = 1f;
        Debug.Log("Start Look");
    }

    public void StopLookAt()
    {
        targetWeight = 0f;
        Debug.Log("Stop Look");
    }
}
