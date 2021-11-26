using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public static float doorStatus = 1; // 0 door opening - 1 door open - 2 door closing - 3 door closed
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        // animator.SetBool("OpenDoor", false);
        // animator.SetBool("StayClosed", false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (doorStatus % 2)
        {
            case 0:
                OpenDoor();
                break;

            case 1:
                CloseDoor();
                break;

        }
    }

    void OpenDoor()
    {
        animator.SetBool("OpenDoor", true);
        animator.SetBool("CloseDoor", false);
    }

    void CloseDoor()
    {
        animator.SetBool("OpenDoor", false);
        animator.SetBool("CloseDoor", true);
    }

    
}
