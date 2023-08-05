using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HeadController : MonoBehaviour
{
    protected Animator animator;
    public GameObject Object;
    public bool ikActive = false;
    public Transform lookObj = null;
    public float lookWeight = 2f;
    private Rig rig;
    private float targetWeight;

    private void Awake()
    {
        rig = GetComponent<Rig>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            transform.LookAt(Object.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Kepala Keluar");
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

    /*void OnAnimatorIK()
    {

        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {
                // Set the look target position, if one has been assigned
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(lookWeight);
                    animator.SetLookAtPosition(lookObj.position);
                }

            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetLookAtWeight(0);
            }
        }
    }*/
}
