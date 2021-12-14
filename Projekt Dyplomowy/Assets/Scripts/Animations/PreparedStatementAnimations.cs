using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedStatementAnimations : MonoBehaviour
{
    PlayerStatementAnimations playerStatementAnimations;
    NPCStatementAnimations npcStatementAnimations;
    // Start is called before the first frame update
    void Start()
    {
        playerStatementAnimations = GameObject.Find("Player").GetComponent<PlayerStatementAnimations>();
        npcStatementAnimations = GameObject.Find("NPC").GetComponent<NPCStatementAnimations>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Statement_Yes_11(){
        Start_Yes_11();

        // do{
        //    //gra skrypt
        // }while(true);

    }




    public void Start_Yes_11()
    {
        playerStatementAnimations.Start_Yes_11();
        npcStatementAnimations.Start_Yes_11();
    }

    public void MoveHands_Yes_11()
    {
        playerStatementAnimations.MoveHands_Yes_11();
    }
    public void Start_No_11()
    {

    }
}
