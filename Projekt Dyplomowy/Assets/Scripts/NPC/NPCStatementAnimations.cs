using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatementAnimations : MonoBehaviour
{
    public GameObject npc_no_7, npc_yes_11;
    Animator animator_no_7, animator_yes_11;
    void Start()
    {
        animator_yes_11 = npc_yes_11.GetComponent<Animator>();
        npc_no_7 = GameObject.Find("NPC").transform.Find("7").gameObject;
        animator_no_7 = npc_no_7.GetComponent<Animator>();
    }

    void Update()
    {

    }
    public Animator Npc_Get_Animator_No_7()
    {
        Animator animator = animator_no_7;
        return animator;
    }

    public void SetActive_False_Object_Yes_11()
    {
        npc_yes_11.SetActive(false);
    }
    public void Start_Yes_11()
    {
        npc_yes_11.SetActive(true);
        animator_yes_11.SetBool("Start", true);
    }
    public void MoveHands_Yes_11()
    {
        animator_yes_11.SetBool("MoveHands", true);
    }
    public void MoveHands_No_11()
    {
        animator_yes_11.SetBool("MoveHands", false);
    }
    public void Start_No_11()
    {

    }
}
