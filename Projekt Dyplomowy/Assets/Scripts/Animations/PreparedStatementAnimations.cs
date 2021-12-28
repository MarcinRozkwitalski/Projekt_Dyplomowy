using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedStatementAnimations : MonoBehaviour
{
    PlayerDirectionDisplayHandler playerDirectionDisplayHandler;
    PlayerStatementAnimations playerStatementAnimations;
    NPCStatementAnimations npcStatementAnimations;
    RPSAnimations rpsAnimations;
    RockPaperScissors rockPaperScissors;
    AnimationTime animationtime;

    void Start()
    {
        playerDirectionDisplayHandler = GameObject.Find("Player").GetComponent<PlayerDirectionDisplayHandler>();
        playerStatementAnimations = GameObject.Find("Player").GetComponent<PlayerStatementAnimations>();
        npcStatementAnimations = GameObject.Find("NPC").GetComponent<NPCStatementAnimations>();
        rockPaperScissors = GameObject.Find("11RockPaperScissors").GetComponent<RockPaperScissors>();
        rpsAnimations = GameObject.Find("11RockPaperScissors").GetComponent<RPSAnimations>();
        animationtime = GameObject.Find("AnimationHandler").GetComponent<AnimationTime>();
    }

    public IEnumerator Statement_Yes_11()
    {
        if (PlayerCanInteract.canChangeIndex == false) // dopóki nie można zmienić indexu rozgrywaj scenariusz
        {
            if (RockPaperScissors.HasGameEnded && PlayerMovement.canMove == false)
            {
                rpsAnimations.Outro();
                //BŁAD BO UŻYTE DWA RAZY JEST KIEDY NOWY INDEX ????????????CHYBA 
                // tranzycja spada głaz potem wciągnięty na linie 
                // przywrócenie gracza wraz z kliakniem obiektów
                npcStatementAnimations.SetActive_False_Object_Yes_11();
                playerStatementAnimations.SetActive_False_Object_Yes_11();
                playerDirectionDisplayHandler.EnablePLayersCollider();
                playerDirectionDisplayHandler.ShowPlayerFront();
                playerDirectionDisplayHandler.PlayerSetDeafultPosition();
                PlayerCanInteract.canChangeIndex = true; // włączenie możliwości generowania nowego indexu - playerCanInteract.cs w tym pliku jest to wyłączane
                PlayerMovement.canMove = true; // Włączenie chodzenia gracza
                PlayerCanInteract.playerCanDecide = true; // Gracz może znowu dokonywac wyboru
                TriggerAnimation.runAnimation = true; // drzwi przypadek 1
                TriggerAnimation.runAgain = true; // drzwi przypadek 1
                // wyłaczenie ostatniego kliknięcia
            }
            else if (RockPaperScissors.HasGameEnded == false)
            {
                Start_Yes_11();
                yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(),
                 "PlayerSideLeftJudoPose") + animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(),
                  "PlayerSideLeftJudoStandingBow") + animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(),
                   "PlayerSideLeftJudoGettingReady") - 2f);
                rpsAnimations.Intro();
                if (RockPaperScissors.doRandomization == true)
                {
                    StartCoroutine(rockPaperScissors.RandomiseChoicesOnScoreboard(RockPaperScissors.stopRandomisingPlayerChoice, "Player"));
                    StartCoroutine(rockPaperScissors.RandomiseChoicesOnScoreboard(RockPaperScissors.stopRandomisingAIChoice, "AI"));
                    RockPaperScissors.doRandomization = false;
                }
            }
        }

    }

    public IEnumerator Statement_No_11()
    {
        if (PlayerCanInteract.canChangeIndex == false)
        {
            if (!playerStatementAnimations.Player_Get_Bool_PlayerSideLeft_Animator_is11False() && PlayerMovement.canMove == false && playerStatementAnimations.No_11_Helper == true)
            {
                npcStatementAnimations.SetActive_False_Object_Yes_11();
                playerStatementAnimations.SetActive_False_Object_Yes_11();
                playerDirectionDisplayHandler.Player.transform.position = new Vector3(-0.789f, -3.616f, 0); // ustawienie player'a w dokładnym miejscu zakończenia Armchair -> idle
                playerDirectionDisplayHandler.EnablePLayersCollider();
                playerDirectionDisplayHandler.HideAllPlayerPerspectives();
                playerDirectionDisplayHandler.PlayerSideLeft.SetActive(true);
                PlayerCanInteract.canChangeIndex = true; // włączenie możliwości generowania nowego indexu - playerCanInteract.cs w tym pliku jest to wyłączane
                PlayerMovement.canMove = true; // Włączenie chodzenia gracza
                PlayerCanInteract.playerCanDecide = true; // Gracz może znowu dokonywac wyboru
                TriggerAnimation.runAnimation = true; // drzwi przypadek 1
                TriggerAnimation.runAgain = true; // drzwi przypadek 1
            }
            else if (!playerStatementAnimations.Player_Get_Bool_PlayerSideLeft_Animator_is11False())
            {
                Debug.Log("Początek 11 Fałsz");
                Start_No_11();
                yield return new WaitForSeconds(
                    animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_No_11(),
                    "PlayerSideSittingInArmchair") + 1.8f);
                End_No_11();
            }
        }
    }

    public void Start_Yes_11()
    {
        playerStatementAnimations.Start_Yes_11();
        npcStatementAnimations.Start_Yes_11();
    }

    public float MoveHands_Yes_11()
    {
        playerStatementAnimations.MoveHands_Yes_11();
        npcStatementAnimations.MoveHands_Yes_11();
        return animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(),
         "PlayerSideLeftJudoPickingHandsign");

    }
    public void MoveHands_No_11()
    {
        playerStatementAnimations.MoveHands_No_11();
        npcStatementAnimations.MoveHands_No_11();
    }
    public void Start_No_11()
    {
        playerStatementAnimations.Start_No_11();
    }

    public void End_No_11()
    {
        playerStatementAnimations.End_No_11();
    }




    public IEnumerator Statement_Yes_1()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            TransitionStart();
            yield return new WaitForSeconds(2.8f);
            PlayerMovement.canMove = false;
            Debug.Log("canMove" + PlayerMovement.canMove);
            Start_Yes_1();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_1(),
             "PlayerFrontJump") - 2.0f);
            TransitionEnd();
            yield return new WaitForSeconds(2f);
            PlayerStopAnimations();
            Debug.Log("Skończone");
            PlayerMovement.canMove = true; // skrypt zajmujący się czasem tranzycji po której można przywrócić postać do ruchu
            PlayerCanInteract.canChangeIndex = true; // musi być pierwsze 
        }
    }

    void Start_Yes_1()
    {
        playerStatementAnimations.Start_Yes_1();
    }

    void TransitionStart()
    {
        Debug.Log("Start tranzycji");
        GameObject square = GameObject.Find("Square");
        Animator squareAnimator = square.GetComponent<Animator>();
        squareAnimator.SetBool("RunRight", true);
        TriggerAnimation.startTransition = false;
    }

    void TransitionEnd()
    {
        Debug.Log("Koniec tranzycji");
        GameObject square = GameObject.Find("Square");
        Animator squareAnimator = square.GetComponent<Animator>();
        squareAnimator.SetBool("RunLeft", true);
        squareAnimator.SetBool("RunRight", false);
    }

    void PlayerStopAnimations()
    {
        playerDirectionDisplayHandler.StopAnimations();
    }

    float PlayerAnimationTime()
    {
        return playerDirectionDisplayHandler.AnimationLength();
    }
}
