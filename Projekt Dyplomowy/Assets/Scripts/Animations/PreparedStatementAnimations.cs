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
    DoorHandler doorHandler;

    void Start()
    {
        playerDirectionDisplayHandler = GameObject.Find("Player").GetComponent<PlayerDirectionDisplayHandler>();
        playerStatementAnimations = GameObject.Find("Player").GetComponent<PlayerStatementAnimations>();
        npcStatementAnimations = GameObject.Find("NPC").GetComponent<NPCStatementAnimations>();
        rockPaperScissors = GameObject.Find("11RockPaperScissors").GetComponent<RockPaperScissors>();
        rpsAnimations = GameObject.Find("11RockPaperScissors").GetComponent<RPSAnimations>();
        animationtime = GameObject.Find("AnimationHandler").GetComponent<AnimationTime>();
        doorHandler = GameObject.Find("DoorLeft").GetComponent<DoorHandler>();
    }

    // statement 1
    public IEnumerator Statement_Yes_1()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            CurtainTransitionIntro();
            yield return new WaitForSeconds(2.8f);
            PlayerMovement.canMove = false;
            Debug.Log("canMove" + PlayerMovement.canMove);
            playerStatementAnimations.Start_Yes_1();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_1(),
             "PlayerFrontJump") - 2.0f);
            CurtainTransitionOutro();
            yield return new WaitForSeconds(2f);
            playerDirectionDisplayHandler.StopAnimations();
            Debug.Log("Skończone-1-yes");
            PlayerMovement.canMove = true; // skrypt zajmujący się czasem tranzycji po której można przywrócić postać do ruchu
            PlayerCanInteract.canChangeIndex = true; // musi być pierwsze 
        }
    }

    public IEnumerator Statement_No_1()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            //Debug.Log(PlayerCanInteract.playerCanDecide + " <- playerCanDecide");
            CurtainTransitionIntro();
            yield return new WaitForSeconds(2.4f);
            PlayerMovement.canMove = false;
            GameObject.Find("DefaultObjects").transform.Find("Chair").gameObject.SetActive(false);
            playerStatementAnimations.Start_No_1();
            yield return new WaitForSeconds(0.2f);
            playerStatementAnimations.End_No_1();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_No_1(),
            "PlayerBackLeft45S1N") - 2.0f);
            CurtainTransitionOutro();
            yield return new WaitForSeconds(2f);
            GameObject.Find("DefaultObjects").transform.Find("Chair").gameObject.SetActive(true);
            PlayerMovement.canMove = true;
            PlayerCanInteract.canChangeIndex = true;
            Debug.Log("1-no");
        }

    }
    // statement 1

    // statement 2
    public void Statement_Yes_2()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
        }
    }

    public void Statement_No_2()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
        }
    }
    // statement 2

    // statement 3
    public IEnumerator Statement_Yes_3(Animator animator)
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            animator.SetInteger("Decision", 2);
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "AnswerYes"));
            animator.SetInteger("Decision", 3);
            GameObject.Find("Computer").transform.Find("Computer - Speaker").gameObject.SetActive(true);
            playerDirectionDisplayHandler.EnablePLayersCollider();
            Debug.Log("3-yes");
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
        }
    }

    public IEnumerator Statement_No_3(Animator animator)
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            animator.SetInteger("Decision", 1);
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "AnswerNo"));
            animator.SetInteger("Decision", 3);
            GameObject.Find("Computer").transform.Find("Computer - Speaker").gameObject.SetActive(true);
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
            Debug.Log("3-no");
        }
    }
    // statement 3

    // statement 4
    public void Statement_Yes_4()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }

    public void Statement_No_4()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }
    // statement 4

    // statement 8
    public void Statement_Yes_8()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }

    public void Statement_No_8()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }
    // statement 8

    // statement 10
    public IEnumerator Statement_Yes_10(Animator animator)
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            animator.SetInteger("Decision", 2);
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "AnswerYes"));
            // animator.SetInteger("Decision", 3);
            playerDirectionDisplayHandler.EnablePLayersCollider();
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
        }
    }

    public IEnumerator Statement_No_10(Animator animator)
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            animator.SetInteger("Decision", 1);
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "AnswerNo"));
            // animator.SetInteger("Decision", 3);
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }
    // statement 10    

    // statement 11


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
    // statement 11

    // statement 21
    public IEnumerator Statement_Yes_21(Animator animator)
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            animator.SetInteger("Decision", 2);
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "AnswerYes"));
            GameObject.Find("Room").transform.Find("DefaultObjects").transform.Find("DoorWardrobe").gameObject.SetActive(true);
            // animator.SetInteger("Decision", 3);
            playerDirectionDisplayHandler.EnablePLayersCollider();
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
        }
    }

    public IEnumerator Statement_No_21(Animator animator)
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            animator.SetInteger("Decision", 1);
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "AnswerNo"));
            GameObject.Find("Room").transform.Find("DefaultObjects").transform.Find("DoorWardrobe").gameObject.SetActive(true);
            // animator.SetInteger("Decision", 3);
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }
    // statement 21

    // statement 24
    public void Statement_Yes_24()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
            Debug.Log("24");
        }
    }

    public void Statement_No_24()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
            Debug.Log("24");

        }
    }
    // statement 24

    // statement 29
    public void Statement_Yes_29()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
            Debug.Log("29");

        }
    }

    public void Statement_No_29()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
            Debug.Log("29");

        }
    }
    // statement 29


    /// USE CURTAIN
    void CurtainTransitionIntro()
    {
        Debug.Log("Kurtyna Intro");
        GameObject square = GameObject.Find("Square");
        Animator squareAnimator = square.GetComponent<Animator>();
        squareAnimator.SetBool("RunRight", true);
        TriggerAnimation.startTransition = false;
    }

    void CurtainTransitionOutro()
    {
        Debug.Log("Kurtyna Outro");
        GameObject square = GameObject.Find("Square");
        Animator squareAnimator = square.GetComponent<Animator>();
        squareAnimator.SetBool("RunLeft", true);
        squareAnimator.SetBool("RunRight", false);
    }
    /// USE CURTAIN

    /// USE DOOR 
    public IEnumerator OpenDoorAnimation(Animator animator)
    {
        if (TriggerAnimation.runAnimation == true && TriggerAnimation.runAgain == true)
        {
            switch (AnswerHandler.index)
            {
                case 7:
                    playerDirectionDisplayHandler.DisablePLayersCollider();
                    PlayerMovement.canMove = false;
                    break;
                default:
                    break;
            }

            TriggerAnimation.runAgain = false;
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandler.Get_Animator(), "DoorLeftOpening"));
            PlayerPathFollowerStatement(AnswerHandler.index);

            switch (AnswerHandler.index)
            {
                case 1:
                    animator.SetBool("Outro", false);
                    animator.SetBool("Intro", true); // parametr odpalający animacje 
                    break;
                case 7:
                    yield return new WaitForSeconds(7f);
                    PlayerPathFollowerStatement(701);
                    break;
                default:
                    break;
            }
            Debug.Log("Otwórz Drzwi");
        }
    }

    public IEnumerator CloseDoorAnimation(Animator animator)
    {
        if (TriggerAnimation.runAnimation == false && TriggerAnimation.runAgain == true)
        {
            TriggerAnimation.runAgain = false;
            animator.SetBool("Intro", false);
            animator.SetBool("Outro", true);
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
            doorHandler.CloseDoor();
            TriggerAnimation.startTransition = true;
            Debug.Log("Zamnknij Drzwi");
        }
    }

    public void PlayerPathFollowerStatement(int index)
    {

        PlayerPathFollower.statementPosition = index; // wybór statement
        PlayerPathFollower.playerCanChangePosition = true; // podążanie po wyznaczonej ścieżce
        PlayerMovement.canMove = false; // wyłączenie chodzenia gracza
    }
    /// USE DOOR 

}
