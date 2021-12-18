using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSAnimations : MonoBehaviour
{
    public GameObject rps;
    Animator animator;
    void Start()
    {
        animator = rps.GetComponent<Animator>();
    }


    public void Intro(){
        animator.SetBool("Intro",true);
    }

    public void Outro(){
        animator.SetBool("Outro",true);
    }

}
