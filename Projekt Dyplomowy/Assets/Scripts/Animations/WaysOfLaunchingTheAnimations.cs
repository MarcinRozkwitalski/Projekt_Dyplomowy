using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaysOfLaunchingTheAnimations : MonoBehaviour
{
    PlayerDirectionDisplayHandler playerDirectionDisplayHandler;
    PreparedStatementAnimations preparedStatementAnimations;
    PlayerPathFollower playerPathFollower;
    AnimationTime animationtime;
    DoorHandler doorHandler, doorHandlerStats;
    int Game = 1;
    Animator roomAnimator, rBarAnimator, bBarAnimator, aBarAnimator, sBarAnimator, pBarAnimator, kBarAnimator, rNumberAnimator, bNumberAnimator, aNumberAnimator, sNumberAnimator, pNumberAnimator, kNumberAnimator;

    void Start()
    {
        playerDirectionDisplayHandler = GameObject.Find("Player").GetComponent<PlayerDirectionDisplayHandler>();
        playerPathFollower = GameObject.Find("Player").GetComponent<PlayerPathFollower>();
        preparedStatementAnimations = GameObject.Find("AnimationHandler").GetComponent<PreparedStatementAnimations>();
        animationtime = GameObject.Find("AnimationHandler").GetComponent<AnimationTime>();
        doorHandler = GameObject.Find("DoorLeft").GetComponent<DoorHandler>();
        doorHandlerStats = GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("DoorLeftStats").GetComponent<DoorHandler>();

        GameObject statsObject = GameObject.Find("Stats");
        rBarAnimator = statsObject.transform.Find("Bars").transform.Find("R-Bar-BackWallBlank").GetComponent<Animator>();
        bBarAnimator = statsObject.transform.Find("Bars").transform.Find("B-Bar-BackWallBlank").GetComponent<Animator>();
        aBarAnimator = statsObject.transform.Find("Bars").transform.Find("A-Bar-BackWallBlank").GetComponent<Animator>();
        sBarAnimator = statsObject.transform.Find("Bars").transform.Find("S-Bar-BackWallBlank").GetComponent<Animator>();
        pBarAnimator = statsObject.transform.Find("Bars").transform.Find("P-Bar-BackWallBlank").GetComponent<Animator>();
        kBarAnimator = statsObject.transform.Find("Bars").transform.Find("K-Bar-BackWallBlank").GetComponent<Animator>();

        rNumberAnimator = statsObject.transform.Find("NumbersR").GetComponent<Animator>();
        bNumberAnimator = statsObject.transform.Find("NumbersB").GetComponent<Animator>();
        aNumberAnimator = statsObject.transform.Find("NumbersA").GetComponent<Animator>();
        sNumberAnimator = statsObject.transform.Find("NumbersS").GetComponent<Animator>();
        pNumberAnimator = statsObject.transform.Find("NumbersP").GetComponent<Animator>();
        kNumberAnimator = statsObject.transform.Find("NumbersK").GetComponent<Animator>();

        GameObject room = GameObject.Find("Room");
        roomAnimator = room.GetComponent<Animator>();
    }

    public IEnumerator StartGame()
    {

        if (Game == 1)
        {
            Game++;
            playerDirectionDisplayHandler.PlayerSetStartGame();
            playerDirectionDisplayHandler.DisablePLayersCollider();
            PlayerMovement.canMove = false;
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandler.Get_Animator(), "DoorLeftOpening"));
            PlayerPathFollower.statementPosition = AnswerHandler.index; // wybór statement
            PlayerPathFollower.playerCanChangePosition = true; // podążanie po wyznaczonej ścieżce
            yield return new WaitForSeconds(4f);
            playerDirectionDisplayHandler.EnablePLayersCollider();
            doorHandler.CloseDoor();
            PlayerMovement.canMove = true;
            // Debug.Log("Game 1");
        }
    }

    public IEnumerator EndGame()
    {

        if (Game == 2)
        {
            Game++;

            playerDirectionDisplayHandler.DisablePLayersCollider();
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandler.Get_Animator(), "DoorLeftOpening"));
            PlayerPathFollower.statementPosition = AnswerHandler.index; // wybór statement
            PlayerPathFollower.playerCanChangePosition = true; // podążanie po wyznaczonej ścieżce
            yield return new WaitForSeconds(3f);
            doorHandler.CloseDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandler.Get_Animator(), "DoorLeftClosing"));
            roomAnimator.SetBool("Intro", true);
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(roomAnimator, "Intro") + 3f);
            doorHandlerStats.OpenDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandlerStats.Get_Animator(), "DoorLeftClosing"));
            TriggerAnimation.something = false; // allows player to move
            PlayerPathFollower.statementPosition = 92;
            PlayerPathFollower.playerCanChangePosition = true;
            yield return new WaitForSeconds(4f);
            doorHandlerStats.CloseDoor();
            Debug.Log("PlayerMovement = " + PlayerMovement.canMove);
            Stats();

            // playerDirectionDisplayHandler.EnablePLayersCollider();
            // PlayerMovement.canMove = true;
        }
    }

    public void Stats()
    {
        Debug.Log("Number of answers = " + SentenceHandler.hashTableAnswers.Count);
        foreach (DictionaryEntry entry in SentenceHandler.hashTableAnswers)
        {
            Debug.Log(" [" + entry.Key + "] = " + entry.Value);
            if (entry.Value.Equals("true"))
            {
                switch (int.Parse(entry.Key.ToString()) % 6)
                {
                    case 1:
                        TestScrpitForIndex.stats[1] += 1;
                        break;
                    case 2:
                        TestScrpitForIndex.stats[2] += 1;
                        break;
                    case 3:
                        TestScrpitForIndex.stats[3] += 1;
                        break;
                    case 4:
                        TestScrpitForIndex.stats[4] += 1;
                        break;
                    case 5:
                        TestScrpitForIndex.stats[5] += 1;
                        break;
                    case 0:
                        TestScrpitForIndex.stats[6] += 1;
                        break;
                    default:
                        break;
                }
            }
        }
        Debug.Log("R = " + TestScrpitForIndex.stats[1]);
        Debug.Log("B = " + TestScrpitForIndex.stats[2]);
        Debug.Log("A = " + TestScrpitForIndex.stats[3]);
        Debug.Log("S = " + TestScrpitForIndex.stats[4]);
        Debug.Log("P = " + TestScrpitForIndex.stats[5]);
        Debug.Log("K = " + TestScrpitForIndex.stats[6]);

        GameObject.Find("Stats").transform.Find("Bars").gameObject.SetActive(true);
        rBarAnimator.SetInteger("Stats", TestScrpitForIndex.stats[1]);
        bBarAnimator.SetInteger("Stats", TestScrpitForIndex.stats[2]);
        aBarAnimator.SetInteger("Stats", TestScrpitForIndex.stats[3]);
        sBarAnimator.SetInteger("Stats", TestScrpitForIndex.stats[4]);
        pBarAnimator.SetInteger("Stats", TestScrpitForIndex.stats[5]);
        kBarAnimator.SetInteger("Stats", TestScrpitForIndex.stats[6]);

        GameObject.Find("Stats").transform.Find("NumbersR").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersB").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersA").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersS").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersP").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersK").gameObject.SetActive(true);

        GameObject.Find("Stats").transform.Find("NumbersR").transform.Find(TestScrpitForIndex.stats[1].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersB").transform.Find(TestScrpitForIndex.stats[2].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersA").transform.Find(TestScrpitForIndex.stats[3].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersS").transform.Find(TestScrpitForIndex.stats[4].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersP").transform.Find(TestScrpitForIndex.stats[5].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersK").transform.Find(TestScrpitForIndex.stats[6].ToString() + "-stat").gameObject.SetActive(true);

        rNumberAnimator.SetInteger("Stats", TestScrpitForIndex.stats[1]);
        bNumberAnimator.SetInteger("Stats", TestScrpitForIndex.stats[2]);
        aNumberAnimator.SetInteger("Stats", TestScrpitForIndex.stats[3]);
        sNumberAnimator.SetInteger("Stats", TestScrpitForIndex.stats[4]);
        pNumberAnimator.SetInteger("Stats", TestScrpitForIndex.stats[5]);
        kNumberAnimator.SetInteger("Stats", TestScrpitForIndex.stats[6]);


    }


    public IEnumerator Animation(Animator animator, string tag)
    {
        if (TriggerAnimation.playAnimation == true && tag != "UseDoor" && tag != "WaitForClick")
        {
            SetActive_False_Object(AnswerHandler.index); // test - wyłączenie obiektów
            PlayerMovement.canMove = false;
            playerDirectionDisplayHandler.DisablePLayersCollider();
            animator.SetBool("Intro", true);
            yield return new WaitForSeconds(1f);
            animator.SetBool("Intro", false);
            TriggerAnimation.playAnimation = false;
            Debug.Log("Anim 1 if");

        }
        else if (tag == "UseDoor" && SentenceHandler.hashTableAnswers[AnswerHandler.index] == null)
        {
            StartCoroutine(preparedStatementAnimations.OpenDoorAnimation(animator));
            // Debug.Log("run anim = " + TriggerAnimation.runAnimation + "   runAgain = " + TriggerAnimation.runAgain);
            // Debug.Log("Anim UseDoor");
        }
        else if (tag == "WaitForClick" && TriggerAnimation.playAnimation == true && SentenceHandler.hashTableAnswers[AnswerHandler.index] == null)
        {
            // Debug.Log("WAITFORCLICK DZIAŁA");
            if (PlayerMovement.canMove == true)
            {
                PlayerMovement.canMove = false;
                playerDirectionDisplayHandler.DisablePLayersCollider();
                animator.SetBool("Intro", true);
            }
            if (PlayerCanInteract.playerCanClick == false)
            {
                Debug.Log("playerClick = " + PlayerCanInteract.playerCanClick);
                animator.SetInteger("Decision", 1);
                PlayerCanInteract.playerCanClick = true;
                TriggerAnimation.playAnimation = false;
                
            }
        }
        else
        {
            if (SentenceHandler.hashTableAnswers[AnswerHandler.index] != null)
            {
                if (SentenceHandler.hashTableAnswers[AnswerHandler.index].Equals("true"))
                {
                    switch (AnswerHandler.index)
                    {
                        case 1:
                            StartCoroutine(preparedStatementAnimations.CloseDoorAnimation(animator));
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_1());
                            break;
                        case 2:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            preparedStatementAnimations.Statement_Yes_2();
                            break;
                        case 3:
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_3(animator));
                            break;
                        case 4:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_Yes_4();
                            break;
                        case 7:
                            animator.SetBool("Outro", true);
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_7());
                            break;
                        case 11:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_11());
                            break;
                        case 24:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_Yes_24();
                            break;
                        case 29:
                            animator.SetBool("Outro", true);
                            // czas potrzebny byu użyć playerCanDecide
                            preparedStatementAnimations.Statement_Yes_29();
                            break;
                        default:
                            Debug.Log("Something went wrong with choosing statement animation");
                            break;

                    }
                }
                else
                {
                    switch (AnswerHandler.index)
                    {
                        case 1:
                            StartCoroutine(preparedStatementAnimations.CloseDoorAnimation(animator));
                            StartCoroutine(preparedStatementAnimations.Statement_No_1());
                            break;
                        case 2:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            preparedStatementAnimations.Statement_No_2();
                            break;
                        case 3:
                            GameObject.Find("Computer").transform.Find("Computer - Speaker").gameObject.SetActive(true);
                            animator.SetBool("Outro", true);
                            StartCoroutine(preparedStatementAnimations.Statement_No_3(animator));
                            break;
                        case 4:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_No_4();
                            break;
                        case 7:
                            animator.SetBool("Outro", true);
                            StartCoroutine(preparedStatementAnimations.Statement_No_7());
                            break;
                        case 11:
                            animator.SetBool("Outro", true);
                            //yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            StartCoroutine(preparedStatementAnimations.Statement_No_11());
                            break;
                        case 24:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_No_24();
                            break;
                        case 29:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_No_29();
                            break;
                        default:
                            Debug.Log("Something went wrong with choosing statement animation");
                            break;

                    }
                }
            }
            else
            {
            }
        }

    }
    // Wyłączania obiektów 
    public void SetActive_False_Object(int index)
    {
        if (index == 3 && GameObject.Find("Computer - Speaker") != null)
        {
            GameObject.Find("Computer - Speaker").SetActive(false);
        }
    }

}

