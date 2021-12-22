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
    // Start is called before the first frame update
    bool animationFinished = false;
    void Start()
    {
        playerDirectionDisplayHandler = GameObject.Find("Player").GetComponent<PlayerDirectionDisplayHandler>();
        playerStatementAnimations = GameObject.Find("Player").GetComponent<PlayerStatementAnimations>();
        npcStatementAnimations = GameObject.Find("NPC").GetComponent<NPCStatementAnimations>();
        rockPaperScissors = GameObject.Find("11RockPaperScissors").GetComponent<RockPaperScissors>();
        rpsAnimations = GameObject.Find("11RockPaperScissors").GetComponent<RPSAnimations>();
        animationtime = GameObject.Find("AnimationHandler").GetComponent<AnimationTime>();

    }


    // Update is called once per frame
    void Update()
    {

    }

    
    public IEnumerator Statement_Yes_11()
    {
        
        if(PlayerCanInteract.canChangeIndex == false) // dopóki nie można zmienić indexu rozgrywaj scenariusz
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
            else if(RockPaperScissors.HasGameEnded == false)
            {
                Start_Yes_11();
                yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), playerStatementAnimations.PlayerSideLeftJudoPose_Get_Name_11()) + animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), playerStatementAnimations.PlayerSideLeftJudoStandingBow_Get_Name_11()) + animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), playerStatementAnimations.PlayerSideLeftJudoGettingReady_Get_Name_11()) - 2f);
                rpsAnimations.Intro();
                if(RockPaperScissors.doRandomization == true){
                    StartCoroutine(rockPaperScissors.RandomiseChoicesOnScoreboard(RockPaperScissors.stopRandomisingPlayerChoice, "Player"));
                    StartCoroutine(rockPaperScissors.RandomiseChoicesOnScoreboard(RockPaperScissors.stopRandomisingAIChoice, "AI"));
                    RockPaperScissors.doRandomization = false;
                }

                

                //wchodzi cały HUD
                //losowanie wyborów znaku w Scoreboard i wyświetlanie 

            }
        }

    }

    public IEnumerator Statement_No_11()
    {

        if(PlayerCanInteract.canChangeIndex == false)
        {

            if (!playerStatementAnimations.Player_Get_Bool_PlayerSideLeft_Animator_is11False() && PlayerMovement.canMove == false && playerStatementAnimations.No_11_Helper == true)
            {
                Debug.Log("Koniec 11 Fałsz");
                //rpsAnimations.Outro(); // HMM 

                //BŁAD BO UŻYTE DWA RAZY JEST KIEDY NOWY INDEX ????????????CHYBA 
                // tranzycja spada głaz potem wciągnięty na linie 
                // przywrócenie gracza wraz z kliakniem obiektów
                npcStatementAnimations.SetActive_False_Object_Yes_11();
                playerStatementAnimations.SetActive_False_Object_Yes_11();
                playerDirectionDisplayHandler.Player.transform.position = new Vector3(-0.789f, -3.616f, 0);
                playerDirectionDisplayHandler.EnablePLayersCollider();
                playerDirectionDisplayHandler.HideAllPlayerPerspectives();
                playerDirectionDisplayHandler.PlayerSideLeft.SetActive(true);
                PlayerCanInteract.canChangeIndex = true; // włączenie możliwości generowania nowego indexu - playerCanInteract.cs w tym pliku jest to wyłączane
                PlayerMovement.canMove = true; // Włączenie chodzenia gracza
                PlayerCanInteract.playerCanDecide = true; // Gracz może znowu dokonywac wyboru
                TriggerAnimation.runAnimation = true; // drzwi przypadek 1
                TriggerAnimation.runAgain = true; // drzwi przypadek 1
                // wyłaczenie ostatniego kliknięcia
            }
            else if(!playerStatementAnimations.Player_Get_Bool_PlayerSideLeft_Animator_is11False())
            {
                Debug.Log("Początek 11 Fałsz");
                Start_No_11();
                yield return new WaitForSeconds(
                    animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_No_11(), 
                    playerStatementAnimations.PlayerSideSittingInArmchair_Get_Name_No_11()) + 1.8f);

                Debug.Log("Czas trwania animacji Armchair: " + animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_No_11(), 
                    playerStatementAnimations.PlayerSideSittingInArmchair_Get_Name_No_11()));

                // yield return new WaitForSeconds(
                //     animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), 
                //     playerStatementAnimations.PlayerSideLeftJudoPose_Get_Name_11()) + 
                //     animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), 
                //     playerStatementAnimations.PlayerSideLeftJudoStandingBow_Get_Name_11()) + 
                //     animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), 
                //     playerStatementAnimations.PlayerSideLeftJudoGettingReady_Get_Name_11()) - 2f);



                Debug.Log("koniec animacji no_11");
                End_No_11();
                 

                //End_No_11();

                    // + 

                    // animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), 
                    // playerStatementAnimations.PlayerSideLeftJudoStandingBow_Get_Name_11()) 
                    
                    // + 

                    // animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), 
                    // playerStatementAnimations.PlayerSideLeftJudoGettingReady_Get_Name_11()) - 2f);

                // rpsAnimations.Intro();
                // if(RockPaperScissors.doRandomization == true){
                //     StartCoroutine(rockPaperScissors.RandomiseChoicesOnScoreboard(RockPaperScissors.stopRandomisingPlayerChoice, "Player"));
                //     StartCoroutine(rockPaperScissors.RandomiseChoicesOnScoreboard(RockPaperScissors.stopRandomisingAIChoice, "AI"));
                //     RockPaperScissors.doRandomization = false;
                // }
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
        return animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), playerStatementAnimations.MoveHands_Get_Name_11());

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
}
