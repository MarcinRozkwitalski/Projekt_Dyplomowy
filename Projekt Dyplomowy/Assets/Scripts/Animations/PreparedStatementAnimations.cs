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
    Laboratory laboratory;
    Manekin manekin;
    public GameObject npc7No, playerBackLeft45Chair, playerBackLeft45ChairSeat;

    GameObject NPCFrontFrenchSoldier1, NPCFrontFrenchSoldier2, NPCFrontFrenchSoldier3, NPCSideLeftFrenchSoldier1, NPCSideLeftFrenchSoldier2, NPCSideLeftFrenchSoldier3, PlayerSideLeftNapoleon, PlayerFrontNapoleon, AdditionalPlayer23Y, NPC23Y;
    GameObject AdditionalPlayer18Y, PlayerFrontCleaner, PlayerSideLeftCleaner, PlayerBackCleaner, PlayerSideRightCleaner, AdditionalPlayer18N, PlayerSideLeft18N, Player, PlayerSideLeft, BoxWithChair18N;
    Animator playerSideLeftAnim, npc7NoAnimator, NPCSideLeftFrenchSoldierAnimator, NPC23YAnimator, AdditionalPlayer23YAnimator, NPCSideLeftFrenchSoldier1Animator, NPCSideLeftFrenchSoldier2Animator, NPCSideLeftFrenchSoldier3Animator, PlayerSideLeftNapoleonAnimator;
    Animator AdditionalPlayer18YAnimator, PlayerFrontCleanerAnimator, PlayerSideLeftCleanerAnimator, PlayerBackCleanerAnimator, PlayerSideRightCleanerAnimator, AdditionalPlayer18NAnimator, PlayerSideLeft18NAnimator;
    public Sprite newChairSprite, newPlayerBackLeft45Chair, newPlayerBackLeft45ChairSeat, Chair18N;

    private bool doUpdateForNPCWalk;
    private int whichNPCWalkForS7N;

    void Start()
    {
        playerDirectionDisplayHandler = GameObject.Find("Player").GetComponent<PlayerDirectionDisplayHandler>();
        playerStatementAnimations = GameObject.Find("Player").GetComponent<PlayerStatementAnimations>();
        npcStatementAnimations = GameObject.Find("NPC").GetComponent<NPCStatementAnimations>();
        rockPaperScissors = GameObject.Find("11RockPaperScissors").GetComponent<RockPaperScissors>();
        rpsAnimations = GameObject.Find("11RockPaperScissors").GetComponent<RPSAnimations>();
        animationtime = GameObject.Find("AnimationHandler").GetComponent<AnimationTime>();
        doorHandler = GameObject.Find("DoorLeft").GetComponent<DoorHandler>();
        laboratory = GameObject.Find("Laboratory").GetComponent<Laboratory>();
        manekin = GameObject.Find("MANEKINSCRIPT").GetComponent<Manekin>();
        GameObject.Find("MIDDLEMANEKIN").transform.GetChild(11).gameObject.SetActive(false);
        playerSideLeftAnim = GameObject.Find("Player").transform.Find("PlayerSideLeft").gameObject.transform.GetComponent<Animator>();
        npc7No = GameObject.Find("NPC").transform.Find("7").gameObject;
        npc7NoAnimator = npc7No.GetComponent<Animator>();
        NPCSideLeftFrenchSoldierAnimator = GameObject.Find("NPCSideLeftFrenchSoldier1").GetComponent<Animator>();
        NPC23YAnimator = GameObject.Find("NPC").transform.Find("NPC23Y").GetComponent<Animator>();
        NPC23Y = GameObject.Find("NPC").transform.Find("NPC23Y").gameObject;
        NPCFrontFrenchSoldier1 = GameObject.Find("NPC").transform.Find("NPC23Y").transform.Find("23_1").transform.Find("NPCFrontFrenchSoldier1").gameObject;
        NPCFrontFrenchSoldier2 = GameObject.Find("NPC").transform.Find("NPC23Y").transform.Find("23_2").transform.Find("NPCFrontFrenchSoldier2").gameObject;
        NPCFrontFrenchSoldier3 = GameObject.Find("NPC").transform.Find("NPC23Y").transform.Find("23_3").transform.Find("NPCFrontFrenchSoldier3").gameObject;
        NPCSideLeftFrenchSoldier1 = GameObject.Find("NPC").transform.Find("NPC23Y").transform.Find("23_1").transform.Find("NPCSideLeftFrenchSoldier1").gameObject;
        NPCSideLeftFrenchSoldier2 = GameObject.Find("NPC").transform.Find("NPC23Y").transform.Find("23_2").transform.Find("NPCSideLeftFrenchSoldier2").gameObject;
        NPCSideLeftFrenchSoldier3 = GameObject.Find("NPC").transform.Find("NPC23Y").transform.Find("23_3").transform.Find("NPCSideLeftFrenchSoldier3").gameObject;
        NPCSideLeftFrenchSoldier1Animator = NPCSideLeftFrenchSoldier1.GetComponent<Animator>();
        NPCSideLeftFrenchSoldier2Animator = NPCSideLeftFrenchSoldier2.GetComponent<Animator>();
        NPCSideLeftFrenchSoldier3Animator = NPCSideLeftFrenchSoldier3.GetComponent<Animator>();
        AdditionalPlayer23YAnimator = GameObject.Find("AdditionalPlayer23Y").GetComponent<Animator>();
        AdditionalPlayer23Y = GameObject.Find("AdditionalPlayer23Y").gameObject;
        PlayerSideLeftNapoleon = GameObject.Find("AdditionalPlayer23Y").transform.Find("PlayerSideLeftNapoleon").gameObject;
        PlayerFrontNapoleon = GameObject.Find("AdditionalPlayer23Y").transform.Find("PlayerFrontNapoleon").gameObject;
        PlayerSideLeftNapoleonAnimator = PlayerSideLeftNapoleon.GetComponent<Animator>();
        AdditionalPlayer18Y = GameObject.Find("AdditionalPlayer18Y").gameObject;
        AdditionalPlayer18YAnimator = AdditionalPlayer18Y.GetComponent<Animator>();
        PlayerFrontCleaner = GameObject.Find("AdditionalPlayer18Y").transform.Find("PlayerFrontCleaner").gameObject;
        PlayerSideLeftCleaner = GameObject.Find("AdditionalPlayer18Y").transform.Find("PlayerSideLeftCleaner").gameObject;
        PlayerBackCleaner = GameObject.Find("AdditionalPlayer18Y").transform.Find("PlayerBackCleaner").gameObject;
        PlayerSideRightCleaner = GameObject.Find("AdditionalPlayer18Y").transform.Find("PlayerSideRightCleaner").gameObject;
        PlayerFrontCleanerAnimator = PlayerFrontCleaner.GetComponent<Animator>();
        PlayerSideLeftCleanerAnimator = PlayerSideLeftCleaner.GetComponent<Animator>();
        PlayerBackCleanerAnimator = PlayerBackCleaner.GetComponent<Animator>();
        PlayerSideRightCleanerAnimator = PlayerSideRightCleaner.GetComponent<Animator>();
        AdditionalPlayer18N = GameObject.Find("AdditionalPlayer18N").gameObject;
        AdditionalPlayer18NAnimator = AdditionalPlayer18N.GetComponent<Animator>();
        PlayerSideLeft18N = GameObject.Find("AdditionalPlayer18N").transform.Find("PlayerSideLeft18N").gameObject;
        PlayerSideLeft18NAnimator = PlayerSideLeft18N.GetComponent<Animator>();
        Player = GameObject.Find("Player").gameObject;
        PlayerSideLeft = GameObject.Find("Player").transform.Find("PlayerSideLeft").gameObject;
        BoxWithChair18N = GameObject.Find("Room").transform.Find("ObjectsBeforeChoiceHandler").transform.Find("18N").transform.Find("BoxWithChair").gameObject;

        AdditionalPlayer18N.SetActive(false);
        AdditionalPlayer18Y.SetActive(false);
        AdditionalPlayer23Y.SetActive(false);
        NPC23Y.SetActive(false);
    }

    void Update()
    {
        float step = 3f * Time.deltaTime;
        if (doUpdateForNPCWalk)
        {
            switch (whichNPCWalkForS7N)
            {
                case 1:
                    StartCoroutine(MoveNPC(npc7No.transform, new Vector3(-0.47f, -3.47f, 0f), step));
                    break;
                case 2:
                    StartCoroutine(MoveNPC(npc7No.transform, new Vector3(-10f, -3.76f, 0f), step));
                    break;
                default:
                    Debug.Log("Missing number for which NPC walk S7N!");
                    break;
            }
        }
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
            playerDirectionDisplayHandler.EnablePLayersCollider();

        }
    }

    public void Statement_No_2()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();

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

    // statement 6

    public void Statement_Yes_6()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }

    public void Statement_No_6()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }

    // statement 6

    // statement 7
    public IEnumerator Statement_Yes_7()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.PlayerFrontAnim.SetBool("defaultStatement7", false);
            yield return new WaitForSeconds(3.5f);
            playerStatementAnimations.Start_Yes_7();
            yield return new WaitForSeconds(
                    animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_7(),
                    "PlayerSideCrouchCreateCloud") - 3.5f);
            playerStatementAnimations.Player_Get_Animator_Yes_7().SetBool("doCCC", false);
            GameObject boxWithChair = GameObject.Find("ObjectsBeforeChoiceHandler").transform.Find("7").transform.Find("BoxWithChair").gameObject;
            boxWithChair.SetActive(false);
            GameObject chair = GameObject.Find("Room").transform.Find("DefaultObjects").transform.Find("Chair").gameObject;
            chair.transform.position = new Vector3(1.562f, -2.403f, 0);
            chair.GetComponent<SpriteRenderer>().sprite = newChairSprite;
            playerBackLeft45Chair.GetComponent<SpriteRenderer>().sprite = newPlayerBackLeft45Chair;
            playerBackLeft45ChairSeat.GetComponent<SpriteRenderer>().sprite = newPlayerBackLeft45ChairSeat;
            yield return new WaitForSeconds(1f);
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }

    public IEnumerator Statement_No_7()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.PlayerFrontAnim.SetBool("defaultStatement7", false);
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(2f);
            npc7No.SetActive(true);
            npc7NoAnimator.SetBool("isMoving", true);
            yield return new WaitForSeconds(0.5f);
            whichNPCWalkForS7N = 1;
            doUpdateForNPCWalk = true;
            yield return new WaitForSeconds(2.3f);
            doUpdateForNPCWalk = false;
            npc7NoAnimator.SetBool("isMoving", false);
            yield return new WaitForSeconds(1f);
            npc7NoAnimator.SetBool("doCCC", true);
            yield return new WaitForSeconds(
                    animationtime.GetAnimationTimeFromName(npcStatementAnimations.Npc_Get_Animator_No_7(),
                    "NPCSideLeftHatCrouchCreateCloud") - 3.5f);
            npc7NoAnimator.SetBool("doCCC", false);
            GameObject boxWithChair = GameObject.Find("ObjectsBeforeChoiceHandler").transform.Find("7").transform.Find("BoxWithChair").gameObject;
            boxWithChair.SetActive(false);
            GameObject chair = GameObject.Find("Room").transform.Find("DefaultObjects").transform.Find("Chair").gameObject;
            chair.transform.position = new Vector3(1.562f, -2.403f, 0);
            chair.GetComponent<SpriteRenderer>().sprite = newChairSprite;
            yield return new WaitForSeconds(4f);
            playerBackLeft45Chair.GetComponent<SpriteRenderer>().sprite = newPlayerBackLeft45Chair;
            playerBackLeft45ChairSeat.GetComponent<SpriteRenderer>().sprite = newPlayerBackLeft45ChairSeat;
            if (npc7No.transform.eulerAngles.y == 180) npc7No.transform.Rotate(0, -180, 0);
            yield return new WaitForSeconds(0.5f);
            npc7NoAnimator.SetBool("isMoving", true);
            whichNPCWalkForS7N = 2;
            doUpdateForNPCWalk = true;
            yield return new WaitForSeconds(3f);
            doUpdateForNPCWalk = false;
            npc7NoAnimator.SetBool("isMoving", false);
            doorHandler.CloseDoor();
            npc7No.SetActive(false);
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }

    // statement 7

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
            animator.SetInteger("Decision", 3);
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
            animator.SetInteger("Decision", 3);
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



    // statement 14
    public IEnumerator Statement_Yes_14(Animator animator)
    {
        animator.SetInteger("Decision", 2);
        animator.SetBool("Game", true);
        laboratory.Gameplay(animator);

        if (animator.GetBool("Game") == false) yield return new WaitForSeconds(2.6f);

        if (PlayerCanInteract.playerCanDecide == false && animator.GetBool("Game") == false)
        {

            PlayerCanInteract.playerCanDecide = true;
            GameObject.Find("Room").transform.Find("DefaultObjects").transform.Find("DoorWardrobe").gameObject.SetActive(true);
            playerDirectionDisplayHandler.EnablePLayersCollider();
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
        }
    }

    public IEnumerator Statement_No_14(Animator animator)
    {
        animator.SetInteger("Decision", 1);
        animator.SetBool("Game", true);
        yield return new WaitForSeconds(2.3f);
        GameObject.Find("AdditionalPlayers").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("AdditionalPlayers").transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Start", true);
        yield return new WaitForSeconds(5f);
        animator.SetBool("Game", false);
        yield return new WaitForSeconds(7.6f);

        if (PlayerCanInteract.playerCanDecide == false && animator.GetBool("Game") == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            GameObject.Find("Room").transform.Find("DefaultObjects").transform.Find("DoorWardrobe").gameObject.SetActive(true);
            GameObject.Find("AdditionalPlayers").transform.GetChild(0).gameObject.SetActive(false);
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }
    // statement 14

    // statement 15
    public IEnumerator Statement_Yes_15(Animator animator)
    {
        animator.SetInteger("Decision", 2);
        manekin.StartGame(animator);
        if (animator.GetBool("Outro") == true) yield return new WaitForSeconds(1f);
        if (PlayerCanInteract.playerCanDecide == false && animator.GetBool("Outro") == true)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }

    public IEnumerator Statement_No_15(Animator animator)
    {
        animator.SetInteger("Decision", 1);
        yield return new WaitForSeconds(5.5f);
        GameObject.Find("15").transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("15").transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).transform.GetChild(2).gameObject.SetActive(true);
        GameObject.Find("15").transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).transform.GetChild(4).gameObject.SetActive(true);
        GameObject.Find("15").transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).transform.GetChild(7).gameObject.SetActive(true);
        GameObject.Find("15").transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).transform.GetChild(8).gameObject.SetActive(true);
        GameObject.Find("15").transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).transform.GetChild(10).gameObject.SetActive(true);
        GameObject.Find("15").transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).transform.GetChild(11).gameObject.SetActive(false);
        yield return new WaitForSeconds(4f);

        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            PlayerCanInteract.playerCanDecide = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();

        }
    }
    // statement 15



    // statement 18

    public IEnumerator Statement_Yes_18()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(2f);
            PlayerPathFollowerStatement(18);
            yield return new WaitForSeconds(7f);
            AdditionalPlayer18Y.SetActive(true);
            playerDirectionDisplayHandler.EnablePLayersCollider();
            AdditionalPlayer18YAnimator.SetBool("Start", true);
            PlayerSideRightCleanerAnimator.SetBool("isMoving", true);
            yield return new WaitForSeconds(2f);
            doorHandler.CloseDoor();
            PlayerSideRightCleaner.SetActive(false);
            PlayerBackCleaner.SetActive(true);
            PlayerSideRightCleanerAnimator.SetBool("isMoving", false);
            PlayerBackCleanerAnimator.SetBool("isMoving", true);
            yield return new WaitForSeconds(0.5f);
            PlayerBackCleanerAnimator.SetBool("isMoving", false);
            yield return new WaitForSeconds(1f);
            PlayerBackCleaner.SetActive(false);
            PlayerSideLeftCleaner.SetActive(true);
            yield return new WaitForSeconds(1f);
            PlayerSideLeftCleanerAnimator.SetBool("isCleaning", true);
            yield return new WaitForSeconds(2.1f);
            PlayerSideLeftCleanerAnimator.SetBool("isCleaning", false);
            yield return new WaitForSeconds(1f);
            PlayerSideLeftCleaner.SetActive(false);
            PlayerFrontCleaner.SetActive(true);
            yield return new WaitForSeconds(1f);
            PlayerFrontCleaner.SetActive(false);
            PlayerSideRightCleaner.SetActive(true);
            PlayerSideRightCleanerAnimator.SetBool("isMoving", true);
            yield return new WaitForSeconds(2f);
            PlayerSideRightCleanerAnimator.SetBool("isMoving", false);
            yield return new WaitForSeconds(1f);
            PlayerSideRightCleanerAnimator.SetBool("isCleaning", true);
            yield return new WaitForSeconds(2.1f);
            PlayerSideRightCleanerAnimator.SetBool("isCleaning", false);
            yield return new WaitForSeconds(1f);
            PlayerSideRightCleanerAnimator.SetBool("isMoving", true);
            yield return new WaitForSeconds(3f);
            PlayerSideRightCleanerAnimator.SetBool("isMoving", false);
            yield return new WaitForSeconds(1f);
            PlayerSideRightCleanerAnimator.SetBool("isCleaning", true);
            yield return new WaitForSeconds(2.1f);
            PlayerSideRightCleanerAnimator.SetBool("isCleaning", false);
            yield return new WaitForSeconds(1f);
            PlayerSideRightCleaner.SetActive(false);
            PlayerFrontCleaner.SetActive(true);
            yield return new WaitForSeconds(1f);
            PlayerFrontCleaner.SetActive(false);
            PlayerSideLeftCleaner.SetActive(true);
            PlayerSideLeftCleanerAnimator.SetBool("isMoving", true);
            yield return new WaitForSeconds(1f);
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(7f);
            playerDirectionDisplayHandler.DisablePLayersCollider();
            PlayerPathFollowerStatement(1801);
            Destroy(AdditionalPlayer18Y);
            yield return new WaitForSeconds(2f);
            doorHandler.CloseDoor();
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }
    public IEnumerator Statement_No_18()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(2f);
            PlayerPathFollowerStatement(18);
            yield return new WaitForSeconds(7f);
            AdditionalPlayer18N.SetActive(true);
            doorHandler.CloseDoor();
            Player.transform.position = new Vector3(-15.06f, -3.78f, 0);
            playerDirectionDisplayHandler.EnablePLayersCollider();
            AdditionalPlayer18NAnimator.SetBool("Start", true);
            PlayerSideLeft18NAnimator.SetBool("is18False", true);
            yield return new WaitForSeconds(4f);
            PlayerSideLeft18NAnimator.SetBool("is18False2", true);
            yield return new WaitForSeconds(3.9f);
            BoxWithChair18N.SetActive(true);
            PlayerSideLeft18NAnimator.SetBool("is18False", false);
            yield return new WaitForSeconds(1.1f);
            PlayerSideLeft18NAnimator.SetBool("is18False2", false);
            yield return new WaitForSeconds(0.5f);
            PlayerSideLeft18NAnimator.SetBool("doCCC18N", true);
            yield return new WaitForSeconds(4f);
            BoxWithChair18N.SetActive(false);
            yield return new WaitForSeconds(9.5f);
            Player.transform.position = new Vector3(2.171f, -4.52f, 0);
            if (PlayerSideLeft.transform.eulerAngles.y == 0) PlayerSideLeft.transform.Rotate(0, 180, 0);
            Destroy(AdditionalPlayer18N);
            yield return new WaitForSeconds(1f);
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }
    // statement 18

    // statement 21
    public IEnumerator Statement_Yes_21(Animator animator)
    {
        animator.SetInteger("Decision", 2);
        yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "AnswerYes") + 3);

        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            GameObject.Find("Room").transform.Find("DefaultObjects").transform.Find("DoorWardrobe").gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }

    public IEnumerator Statement_No_21(Animator animator)
    {
        animator.SetInteger("Decision", 1);
        yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "AnswerNo") + 3);

        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            GameObject.Find("Room").transform.Find("DefaultObjects").transform.Find("DoorWardrobe").gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }
    // statement 21

    // statement 23

    public IEnumerator Statement_Yes_23()
    {
        if (PlayerCanInteract.playerCanDecide == false)
        {
            PlayerCanInteract.playerCanDecide = true;
            PlayerMovement.canMove = false;
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(2f);
            PlayerPathFollowerStatement(23);
            yield return new WaitForSeconds(7f);
            AdditionalPlayer23Y.SetActive(true);
            NPC23Y.SetActive(true);
            AdditionalPlayer23YAnimator.SetBool("Start", true);
            PlayerSideLeftNapoleonAnimator.SetBool("isMoving", true);
            yield return new WaitForSeconds(2f);
            PlayerSideLeftNapoleonAnimator.SetBool("isMoving", false);
            yield return new WaitForSeconds(1f);
            PlayerSideLeftNapoleon.SetActive(false);
            PlayerFrontNapoleon.SetActive(true);

            NPC23YAnimator.SetBool("Start", true);
            NPCSideLeftFrenchSoldier1Animator.SetBool("isMoving", true);
            NPCSideLeftFrenchSoldier2Animator.SetBool("isMoving", true);
            NPCSideLeftFrenchSoldier3Animator.SetBool("isMoving", true);

            yield return new WaitForSeconds(5f);
            NPCSideLeftFrenchSoldier1Animator.SetBool("isMoving", false);
            NPCSideLeftFrenchSoldier2Animator.SetBool("isMoving", false);
            NPCSideLeftFrenchSoldier3Animator.SetBool("isMoving", false);

            yield return new WaitForSeconds(2f);

            yield return new WaitForSeconds(0.5f);
            NPCSideLeftFrenchSoldier1.SetActive(false);
            NPCFrontFrenchSoldier1.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            NPCSideLeftFrenchSoldier2.SetActive(false);
            NPCFrontFrenchSoldier2.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            NPCSideLeftFrenchSoldier3.SetActive(false);
            NPCFrontFrenchSoldier3.SetActive(true);

            yield return new WaitForSeconds(1f);

            if (NPCSideLeftFrenchSoldier1.transform.eulerAngles.y == 180) NPCSideLeftFrenchSoldier1.transform.Rotate(0, -180, 0);
            if (NPCSideLeftFrenchSoldier2.transform.eulerAngles.y == 180) NPCSideLeftFrenchSoldier2.transform.Rotate(0, -180, 0);
            if (NPCSideLeftFrenchSoldier3.transform.eulerAngles.y == 180) NPCSideLeftFrenchSoldier3.transform.Rotate(0, -180, 0);

            yield return new WaitForSeconds(0.5f);
            NPCFrontFrenchSoldier1.SetActive(false);
            NPCSideLeftFrenchSoldier1.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            NPCFrontFrenchSoldier2.SetActive(false);
            NPCSideLeftFrenchSoldier2.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            NPCFrontFrenchSoldier3.SetActive(false);
            NPCSideLeftFrenchSoldier3.SetActive(true);

            yield return new WaitForSeconds(2f);
            NPCSideLeftFrenchSoldier1Animator.SetBool("isMoving", true);
            NPCSideLeftFrenchSoldier2Animator.SetBool("isMoving", true);
            NPCSideLeftFrenchSoldier3Animator.SetBool("isMoving", true);

            yield return new WaitForSeconds(3f);

            PlayerFrontNapoleon.SetActive(false);
            if (PlayerSideLeftNapoleon.transform.eulerAngles.y == 180) PlayerSideLeftNapoleon.transform.Rotate(0, -180, 0);
            PlayerSideLeftNapoleon.SetActive(true);
            PlayerSideLeftNapoleonAnimator.SetBool("isMoving", true);

            yield return new WaitForSeconds(2.5f);

            PlayerPathFollowerStatement(2301);
            Destroy(NPC23Y);
            Destroy(AdditionalPlayer23Y);
            yield return new WaitForSeconds(2f);
            doorHandler.CloseDoor();

            PlayerCanInteract.canChangeIndex = true;
            PlayerMovement.canMove = true;
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
    }

    public IEnumerator Statement_No_23()
    {
        if (PlayerCanInteract.canChangeIndex == false)
        {
            if (!playerStatementAnimations.Player_Get_Bool_PlayerSideLeft_Animator_is23False() && PlayerMovement.canMove == false && playerStatementAnimations.No_23_Helper == true)
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
            else if (!playerStatementAnimations.Player_Get_Bool_PlayerSideLeft_Animator_is23False())
            {
                Debug.Log("Początek 23 Fałsz");
                Start_No_23();
                yield return new WaitForSeconds(
                    animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_No_23(),
                    "PlayerSideSittingInArmchairS23F") + 1.8f);
                End_No_23();
            }
        }
    }

    public void Start_No_23()
    {
        playerStatementAnimations.Start_No_23();
    }

    public void End_No_23()
    {
        playerStatementAnimations.End_No_23();
    }

    // statement 23

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
                    yield return new WaitForSeconds(0.35f);
                    doorHandler.CloseDoor();
                    yield return new WaitForSeconds(7f);
                    playerSideLeftAnim.SetBool("defaultStatement7", false);
                    GameObject BoxWithChair = GameObject.Find("ObjectsBeforeChoiceHandler").transform.Find("7").gameObject.transform.Find("BoxWithChair").gameObject;
                    BoxWithChair.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    PlayerPathFollowerStatement(702);
                    yield return new WaitForSeconds(0.65f);
                    PlayerPathFollowerStatement(703);
                    yield return new WaitForSeconds(1.3f);
                    playerDirectionDisplayHandler.HideAllPlayerPerspectives();
                    playerDirectionDisplayHandler.PlayerFront.SetActive(true);
                    Animator statement7Choice = GameObject.Find("AnimationHandler").transform.Find("7").GetComponent<Animator>();
                    statement7Choice.SetBool("Intro", true);
                    Animator playerFrontAnim = GameObject.Find("Player").transform.Find("PlayerFront").GetComponent<Animator>();
                    playerFrontAnim.SetBool("defaultStatement7", true);
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
    public IEnumerator MoveNPC(Transform NPC, Vector3 endPosition, float time)
    {
        while (NPC.position != endPosition)
        {
            NPC.position = Vector2.MoveTowards(NPC.position, endPosition, time * Time.deltaTime);
            yield return null;
        }
    }

}
