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
    public static int game = 1;
    public static bool exitStats = false;
    public static int viewStats = 0;
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

        if (game == 1)
        {
            game++;
            playerDirectionDisplayHandler.PlayerSetStartGame();
            playerDirectionDisplayHandler.DisablePLayersCollider();
            PlayerMovement.canMove = false;
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandler.Get_Animator(), "DoorLeftOpening"));
            PlayerPathFollower.statementPosition = AnswerHandler.index;
            PlayerPathFollower.playerCanChangePosition = true;
            yield return new WaitForSeconds(4f);
            playerDirectionDisplayHandler.EnablePLayersCollider();
            doorHandler.CloseDoor();
            PlayerMovement.canMove = true;
        }
    }

    public IEnumerator EndGame()
    {

        if (game == 2)
        {
            game++;

            playerDirectionDisplayHandler.DisablePLayersCollider();
            doorHandler.OpenDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandler.Get_Animator(), "DoorLeftOpening"));
            PlayerPathFollower.statementPosition = AnswerHandler.index; 
            PlayerPathFollower.playerCanChangePosition = true; 
            yield return new WaitForSeconds(3f);
            doorHandler.CloseDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandler.Get_Animator(), "DoorLeftClosing"));
            roomAnimator.SetBool("Intro", true);
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(roomAnimator, "Intro") + 3f);
            doorHandlerStats.OpenDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandlerStats.Get_Animator(), "DoorLeftClosing"));
            TriggerAnimation.blockPlayerMovement = false;
            PlayerPathFollower.statementPosition = 92;
            PlayerPathFollower.playerCanChangePosition = true;
            yield return new WaitForSeconds(4f);
            doorHandlerStats.CloseDoor();
            Stats();
            playerDirectionDisplayHandler.EnablePLayersCollider();
        }
        if (viewStats == 1)
        {
            HideStats();
            GameObject.Find("Stats").transform.Find("DescriptionR").gameObject.SetActive(true);
            GameObject.Find("Stats").transform.Find("ReturnToStats").gameObject.SetActive(true);
            viewStats = 0;
        }
        else if (viewStats == 2)
        {
            HideStats();
            GameObject.Find("Stats").transform.Find("DescriptionB").gameObject.SetActive(true);
            GameObject.Find("Stats").transform.Find("ReturnToStats").gameObject.SetActive(true);
            viewStats = 0;
        }
        else if (viewStats == 3)
        {
            HideStats();
            GameObject.Find("Stats").transform.Find("DescriptionA").gameObject.SetActive(true);
            GameObject.Find("Stats").transform.Find("ReturnToStats").gameObject.SetActive(true);
            viewStats = 0;
        }
        else if (viewStats == 4)
        {
            HideStats();
            GameObject.Find("Stats").transform.Find("DescriptionS").gameObject.SetActive(true);
            GameObject.Find("Stats").transform.Find("ReturnToStats").gameObject.SetActive(true);
            viewStats = 0;
        }
        else if (viewStats == 5)
        {
            HideStats();
            GameObject.Find("Stats").transform.Find("DescriptionP").gameObject.SetActive(true);
            GameObject.Find("Stats").transform.Find("ReturnToStats").gameObject.SetActive(true);
            viewStats = 0;
        }
        else if (viewStats == 6)
        {
            HideStats();
            GameObject.Find("Stats").transform.Find("DescriptionK").gameObject.SetActive(true);
            GameObject.Find("Stats").transform.Find("ReturnToStats").gameObject.SetActive(true);
            viewStats = 0;
        }
        else if (viewStats == 7)
        {
            ShowStats();
            viewStats = 0;
        }

        if (game == 4)
        {
            game++;
            PlayerMovement.canMove = false;
            playerDirectionDisplayHandler.DisablePLayersCollider();
            doorHandlerStats.OpenDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandlerStats.Get_Animator(), "DoorLeftOpening"));
            PlayerPathFollower.statementPosition = 91; 
            PlayerPathFollower.playerCanChangePosition = true; 
            yield return new WaitForSeconds(3f);
            doorHandlerStats.CloseDoor();
            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(doorHandlerStats.Get_Animator(), "DoorLeftClosing"));
            exitStats = true;
            PlayerMovement.canMove = true;
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
                        TestScriptForIndex.stats[1] += 1;
                        break;
                    case 2:
                        TestScriptForIndex.stats[2] += 1;
                        break;
                    case 3:
                        TestScriptForIndex.stats[3] += 1;
                        break;
                    case 4:
                        TestScriptForIndex.stats[4] += 1;
                        break;
                    case 5:
                        TestScriptForIndex.stats[5] += 1;
                        break;
                    case 0:
                        TestScriptForIndex.stats[6] += 1;
                        break;
                    default:
                        break;
                }
            }
        }
        Debug.Log("R = " + TestScriptForIndex.stats[1]);
        Debug.Log("B = " + TestScriptForIndex.stats[2]);
        Debug.Log("A = " + TestScriptForIndex.stats[3]);
        Debug.Log("S = " + TestScriptForIndex.stats[4]);
        Debug.Log("P = " + TestScriptForIndex.stats[5]);
        Debug.Log("K = " + TestScriptForIndex.stats[6]);

        GameObject.Find("Stats").transform.Find("Bars").gameObject.SetActive(true);
        rBarAnimator.SetInteger("Stats", TestScriptForIndex.stats[1]);
        bBarAnimator.SetInteger("Stats", TestScriptForIndex.stats[2]);
        aBarAnimator.SetInteger("Stats", TestScriptForIndex.stats[3]);
        sBarAnimator.SetInteger("Stats", TestScriptForIndex.stats[4]);
        pBarAnimator.SetInteger("Stats", TestScriptForIndex.stats[5]);
        kBarAnimator.SetInteger("Stats", TestScriptForIndex.stats[6]);

        GameObject.Find("Stats").transform.Find("NumbersR").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersB").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersA").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersS").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersP").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersK").gameObject.SetActive(true);

        GameObject.Find("Stats").transform.Find("NumbersR").transform.Find(TestScriptForIndex.stats[1].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersB").transform.Find(TestScriptForIndex.stats[2].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersA").transform.Find(TestScriptForIndex.stats[3].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersS").transform.Find(TestScriptForIndex.stats[4].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersP").transform.Find(TestScriptForIndex.stats[5].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersK").transform.Find(TestScriptForIndex.stats[6].ToString() + "-stat").gameObject.SetActive(true);

        rNumberAnimator.SetInteger("Stats", TestScriptForIndex.stats[1]);
        bNumberAnimator.SetInteger("Stats", TestScriptForIndex.stats[2]);
        aNumberAnimator.SetInteger("Stats", TestScriptForIndex.stats[3]);
        sNumberAnimator.SetInteger("Stats", TestScriptForIndex.stats[4]);
        pNumberAnimator.SetInteger("Stats", TestScriptForIndex.stats[5]);
        kNumberAnimator.SetInteger("Stats", TestScriptForIndex.stats[6]);


    }

    void HideStats()
    {

        rBarAnimator.SetBool("Hide", true);
        bBarAnimator.SetBool("Hide", true);
        aBarAnimator.SetBool("Hide", true);
        sBarAnimator.SetBool("Hide", true);
        pBarAnimator.SetBool("Hide", true);
        kBarAnimator.SetBool("Hide", true);

        GameObject.Find("Stats").transform.Find("NumbersR").transform.Find(TestScriptForIndex.stats[1].ToString() + "-stat").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("NumbersB").transform.Find(TestScriptForIndex.stats[2].ToString() + "-stat").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("NumbersA").transform.Find(TestScriptForIndex.stats[3].ToString() + "-stat").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("NumbersS").transform.Find(TestScriptForIndex.stats[4].ToString() + "-stat").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("NumbersP").transform.Find(TestScriptForIndex.stats[5].ToString() + "-stat").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("NumbersK").transform.Find(TestScriptForIndex.stats[6].ToString() + "-stat").gameObject.SetActive(false);

        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("R-BackWallBlank").gameObject.SetActive(false);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("B-BackWallBlank").gameObject.SetActive(false);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("A-BackWallBlank").gameObject.SetActive(false);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("S-BackWallBlank").gameObject.SetActive(false);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("P-BackWallBlank").gameObject.SetActive(false);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("K-BackWallBlank").gameObject.SetActive(false);

    }

    void ShowStats()
    {
        rBarAnimator.SetBool("Hide", false);
        bBarAnimator.SetBool("Hide", false);
        aBarAnimator.SetBool("Hide", false);
        sBarAnimator.SetBool("Hide", false);
        pBarAnimator.SetBool("Hide", false);
        kBarAnimator.SetBool("Hide", false);

        GameObject.Find("Stats").transform.Find("NumbersR").transform.Find(TestScriptForIndex.stats[1].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersB").transform.Find(TestScriptForIndex.stats[2].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersA").transform.Find(TestScriptForIndex.stats[3].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersS").transform.Find(TestScriptForIndex.stats[4].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersP").transform.Find(TestScriptForIndex.stats[5].ToString() + "-stat").gameObject.SetActive(true);
        GameObject.Find("Stats").transform.Find("NumbersK").transform.Find(TestScriptForIndex.stats[6].ToString() + "-stat").gameObject.SetActive(true);

        GameObject.Find("Stats").transform.Find("DescriptionR").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("DescriptionB").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("DescriptionA").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("DescriptionS").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("DescriptionP").gameObject.SetActive(false);
        GameObject.Find("Stats").transform.Find("DescriptionK").gameObject.SetActive(false);

        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("R-BackWallBlank").gameObject.SetActive(true);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("B-BackWallBlank").gameObject.SetActive(true);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("A-BackWallBlank").gameObject.SetActive(true);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("S-BackWallBlank").gameObject.SetActive(true);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("P-BackWallBlank").gameObject.SetActive(true);
        GameObject.Find("Walls").transform.Find("RoomTwo").transform.Find("Symbols").transform.Find("K-BackWallBlank").gameObject.SetActive(true);

        GameObject.Find("Stats").transform.Find("ReturnToStats").gameObject.SetActive(false);

    }


    public IEnumerator Animation(Animator animator, string tag)
    {
        if (TriggerAnimation.playAnimation == true && tag != "UseDoor" && tag != "WaitForClick")
        {
            SetActive_False_Object(AnswerHandler.index);
            PlayerMovement.canMove = false;
            playerDirectionDisplayHandler.DisablePLayersCollider();
            animator.SetBool("Intro", true);
            yield return new WaitForSeconds(1f);
            if (AnswerHandler.index == 21) GameObject.Find("Room").transform.Find("DefaultObjects").transform.Find("DoorWardrobe").gameObject.SetActive(false); // 21 ???
            animator.SetBool("Intro", false);
            TriggerAnimation.playAnimation = false;

        }
        else if (tag == "UseDoor" && SentenceHandler.hashTableAnswers[AnswerHandler.index] == null)
        {
            StartCoroutine(preparedStatementAnimations.OpenDoorAnimation(animator));
        }
        else if (tag == "WaitForClick" && TriggerAnimation.playAnimation == true && SentenceHandler.hashTableAnswers[AnswerHandler.index] == null)
        {
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
                        case 6:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            preparedStatementAnimations.Statement_Yes_6();
                            break;
                        case 7:
                            animator.SetBool("Outro", true);
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_7());
                            break;
                        case 8:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_Yes_8();
                            break;
                        case 10:
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_10(animator));
                            break;
                        case 11:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_11());
                            break;
                        case 18:
                            animator.SetBool("Outro", true);
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_18());
                            break;
                        case 21:
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_21(animator));
                            break;
                        case 23:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_23());
                            break;
                        case 24:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_Yes_24();
                            break;
                        case 29:
                            animator.SetBool("Outro", true);
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
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro")); // inaczej na się odpali PLayerCandecide za szybko 
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
                        case 6:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            preparedStatementAnimations.Statement_No_6();
                            break;
                        case 7:
                            animator.SetBool("Outro", true);
                            StartCoroutine(preparedStatementAnimations.Statement_No_7());
                            break;
                        case 8:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_No_8();
                            break;
                        case 10:
                            // animator.SetBool("Outro", true);
                            StartCoroutine(preparedStatementAnimations.Statement_No_10(animator));
                            break;
                        case 11:
                            animator.SetBool("Outro", true);
                            //yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            StartCoroutine(preparedStatementAnimations.Statement_No_11());
                            break;
                        case 18:
                            animator.SetBool("Outro", true);
                            StartCoroutine(preparedStatementAnimations.Statement_No_18());
                            break;
                        case 21:
                            // animator.SetBool("Outro", true);
                            StartCoroutine(preparedStatementAnimations.Statement_No_21(animator));
                            break;
                        case 23:
                            StartCoroutine(preparedStatementAnimations.Statement_No_23());
                            yield return new WaitForSeconds(2f);
                            animator.SetBool("Outro", true);
                            //yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
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

    public void SetActive_False_Object(int index)
    {
        if (index == 3 && GameObject.Find("Computer - Speaker") != null)
        {
            GameObject.Find("Computer - Speaker").SetActive(false);
        }
    }

}

