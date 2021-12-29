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
    }

    public void OpenDoor()
    {
        animator.SetBool("CloseDoor", false);
        animator.SetBool("OpenDoor", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("OpenDoor", false);
        animator.SetBool("CloseDoor", true);
    }

    public Animator Get_Animator(){
        return animator;
    }

    
}
