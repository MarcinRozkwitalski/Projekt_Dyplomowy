using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatementAnimations : MonoBehaviour
{

    public GameObject playerFront, playerFrontLeft45, playerSideLeft, playerBackLeft45, playerBack, player_yes_11;
    Animator animator_no_11, animator_yes_11;
    public bool No_11_Helper = false;
    // Start is called before the first frame update
    void Start()
    {
        animator_yes_11 = player_yes_11.GetComponent<Animator>();
        animator_no_11 = playerSideLeft.GetComponent<Animator>();
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
    public string MoveHands_Get_Name_11()
    {
        string name = "PlayerSideLeftJudoPickingHandsign";
        return name;
    }
    public string PlayerSideLeftJudoPose_Get_Name_11()
    {
        string name = "PlayerSideLeftJudoPose";
        return name;
    }
    public string PlayerSideLeftJudoStandingBow_Get_Name_11()
    {
        string name = "PlayerSideLeftJudoStandingBow";
        return name;
    }
    public string PlayerSideLeftJudoGettingReady_Get_Name_11()
    {
        string name = "PlayerSideLeftJudoGettingReady";
        return name;
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
        playerSideLeft.transform.Rotate(0, 180, 0);
        playerSideLeft.SetActive(true);
        animator_no_11.SetBool("is11False", true);
    }

    public void End_No_11()
    {
        animator_no_11.SetBool("is11False", false);
        No_11_Helper = true;
    }

    public string PlayerSideSittingInArmchair_Get_Name_No_11()
    {
        string name = "PlayerSideSittingInArmchair";
        return name;
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

    public void HideAllPlayerPerspectives()
    {
        playerFront.SetActive(false);
        playerFrontLeft45.SetActive(false);
        playerSideLeft.SetActive(false);
        playerBackLeft45.SetActive(false);
        playerBack.SetActive(false);
    }
}
