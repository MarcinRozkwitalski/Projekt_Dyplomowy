using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public static float doorStatus = 2; // 0 door opening - 1 door open - 2 door closing - 3 door closed
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (doorStatus % 4)
        {
            case 0:
                OpeningDoor();
                break;
            case 1:
                OpenDoor();
                break;
            case 2:
                ClosingDoor();
                break;
            case 3:
                ClosedDoor();
                break;
        }
    }

    void OpenDoor()
    {
        animator.SetBool("OpenDoor", false);
        animator.SetBool("StayOpened", true);
        animator.SetBool("CloseDoor", false);
        animator.SetBool("StayClosed", false);

    }

    void ClosedDoor()
    {
        animator.SetBool("OpenDoor", false);
        animator.SetBool("StayOpened", false);
        animator.SetBool("CloseDoor", false);
        animator.SetBool("StayClosed", true);
    }

    void OpeningDoor()
    {
        animator.SetBool("OpenDoor", true);
        animator.SetBool("StayOpened", false);
        animator.SetBool("CloseDoor", false);
        animator.SetBool("StayClosed", false);
    }
    void ClosingDoor()
    {
        animator.SetBool("OpenDoor", false);
        animator.SetBool("StayOpened", false);
        animator.SetBool("CloseDoor", true);
        animator.SetBool("StayClosed", false);
    }
}
