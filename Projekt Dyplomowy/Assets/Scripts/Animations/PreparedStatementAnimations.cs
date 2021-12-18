using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedStatementAnimations : MonoBehaviour
{
    PlayerStatementAnimations playerStatementAnimations;
    NPCStatementAnimations npcStatementAnimations;
    RockPaperScissors rockPaperScissors;
    AnimationTime animationtime;
    // Start is called before the first frame update
    bool animationFinished = false;
    void Start()
    {
        playerStatementAnimations = GameObject.Find("Player").GetComponent<PlayerStatementAnimations>();
        npcStatementAnimations = GameObject.Find("NPC").GetComponent<NPCStatementAnimations>();
        rockPaperScissors = GameObject.Find("11RockPaperScissors").GetComponent<RockPaperScissors>();
        animationtime = GameObject.Find("AnimationHandler").GetComponent<AnimationTime>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Statement_Yes_11()
    {

        Start_Yes_11();
        //wchodzą Judo wojownicy, po animacji startowej Judo (poza, przywitanie, "gotowość walki")
        // wchodzi cały HUD oraz losowanie wyborów znaku w Scoreboard
        if(!RockPaperScissors.HasGameEnded);

    }




    public void Start_Yes_11()
    {
        playerStatementAnimations.Start_Yes_11();
        npcStatementAnimations.Start_Yes_11();
    }

    public float MoveHands_Yes_11()
    {
        playerStatementAnimations.MoveHands_Yes_11();
        return animationtime.GetAnimationTimeFromName(playerStatementAnimations.Player_Get_Animator_Yes_11(), playerStatementAnimations.MoveHands_Get_Name_11());

    }
    public void MoveHands_No_11()
    {
        playerStatementAnimations.MoveHands_No_11();
    }
    public void Start_No_11()
    {

    }
}
