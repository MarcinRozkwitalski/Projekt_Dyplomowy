using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatementAnimations : MonoBehaviour
{

    public GameObject playerFront, playerFrontLeft45, playerSideLeft, playerBackLeft45, playerBack, player_no_11, player_yes_11;
    Animator animator_yo_11, animator_yes_11;
    // Start is called before the first frame update
    void Start()
    {
        animator_yes_11 = player_yes_11.GetComponent<Animator>();
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
