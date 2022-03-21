using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatementAnimations : MonoBehaviour
{

    public GameObject playerFront, playerFrontLeft45, playerSideLeft, playerBackLeft45, playerBack, player_yes_11;
    Animator animator_no_1, animator_yes_1, animator_yes_7, animator_no_11, animator_yes_11, animator_no_23;
    public bool No_11_Helper = false;
    public bool No_23_Helper = false;

    void Start()
    {
        animator_yes_1 = playerFront.GetComponent<Animator>();
        animator_no_1 = playerBackLeft45.GetComponent<Animator>();
        animator_yes_7 = playerSideLeft.GetComponent<Animator>();
        animator_yes_11 = player_yes_11.GetComponent<Animator>();
        animator_no_11 = playerSideLeft.GetComponent<Animator>();
        animator_no_23 = playerSideLeft.GetComponent<Animator>();
    }

    public void Start_Yes_1()
    {
        HideAllPlayerPerspectives();
        gameObject.transform.position = new Vector3(0, -4, 0);
        playerFront.SetActive(true);
        animator_yes_1.SetBool("is1True", true);
    }

    public Animator Player_Get_Animator_Yes_1()
    {
        Animator animator = animator_yes_1;
        return animator;
    }

    public void Start_No_1()
    {
        HideAllPlayerPerspectives();
        gameObject.transform.position = new Vector3(1.998f, -3.72f, 0);
        if (playerBackLeft45.transform.eulerAngles.y == 180) playerBackLeft45.transform.Rotate(0, -180, 0);
        playerBackLeft45.SetActive(true);
        animator_no_1.SetBool("is1False", true);
    }

    public void End_No_1()
    {
        animator_no_1.SetBool("is1False", false);
    }

    public Animator Player_Get_Animator_No_1()
    {
        Animator animator = animator_no_1;
        return animator;
    }

    public void Start_Yes_7()
    {
        HideAllPlayerPerspectives();
        if (playerSideLeft.transform.eulerAngles.y == 180) playerSideLeft.transform.Rotate(0, -180, 0);
        playerSideLeft.SetActive(true);
        animator_yes_7.SetBool("doCCC", true);
    }

    public void Start_No_7()
    {

    }

    public Animator Player_Get_Animator_Yes_7()
    {
        Animator animator = animator_yes_7;
        return animator;
    }

    public void SetActive_False_Object_Yes_11()
    {
        player_yes_11.SetActive(false);
    }
    public void Start_Yes_11()
    {
        HideAllPlayerPerspectives();
        gameObject.transform.position = new Vector3(-2, -4, 0);
        player_yes_11.SetActive(true);
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
    public Animator Player_Get_Animator_Yes_11()
    {
        Animator animator = animator_yes_11;
        return animator;
    }
    public void Start_No_11()
    {
        HideAllPlayerPerspectives();
        gameObject.transform.position = new Vector3(-2, -4, 0);
        if (playerSideLeft.transform.eulerAngles.y == 0) playerSideLeft.transform.Rotate(0, 180, 0);
        playerSideLeft.SetActive(true);
        animator_no_11.SetBool("is11False", true);
    }

    public void End_No_11()
    {
        animator_no_11.SetBool("is11False", false);
        No_11_Helper = true;
    }

    public Animator Player_Get_Animator_No_11()
    {
        Animator animator = animator_no_11;
        return animator;
    }

    public bool Player_Get_Bool_PlayerSideLeft_Animator_is11False()
    {
        bool is11False = animator_no_11.GetBool("is11False");
        return is11False;
    }

    public void Start_No_23()
    {
        HideAllPlayerPerspectives();
        gameObject.transform.position = new Vector3(-2, -4, 0);
        if (playerSideLeft.transform.eulerAngles.y == 0) playerSideLeft.transform.Rotate(0, 180, 0);
        playerSideLeft.SetActive(true);
        animator_no_23.SetBool("is23False", true);
    }

    public void End_No_23()
    {
        animator_no_23.SetBool("is23False", false);
        No_23_Helper = true;
    }

    public Animator Player_Get_Animator_No_23()
    {
        Animator animator = animator_no_23;
        return animator;
    }

    public bool Player_Get_Bool_PlayerSideLeft_Animator_is23False()
    {
        bool is23False = animator_no_23.GetBool("is23False");
        return is23False;
    }

    public void HideAllPlayerPerspectives()
    {
        playerFront.SetActive(false);
        playerFrontLeft45.SetActive(false);
        playerSideLeft.SetActive(false);
        playerBackLeft45.SetActive(false);
        playerBack.SetActive(false);
    }
}
