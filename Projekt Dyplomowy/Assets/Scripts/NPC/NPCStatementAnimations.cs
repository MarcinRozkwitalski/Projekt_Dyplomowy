using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatementAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject npc_yes_11;
    Animator animator_yes_11;
    void Start()
    {
        animator_yes_11 = npc_yes_11.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Start_Yes_11()
    {
        npc_yes_11.SetActive(true);
        animator_yes_11.SetBool("Start", true);
    }
    public void MoveHands_Yes_11()
    {
        animator_yes_11.SetBool("MoveHands", true);
        animator_yes_11.SetBool("MoveHands", false);
    }
    public void Start_No_11()
    {

    }
}
