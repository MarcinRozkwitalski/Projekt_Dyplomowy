using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPathFollower : MonoBehaviour
{
    public Vector2 playerDestination = new Vector2(-2, -8);
    public Vector2 currentPlayerPosition;
    public static bool playerCanChangePosition = false;
    public static int statementPosition = 0;




    // Nie możemy tu ustawić canMove na true bo gracz będzie mógł sam chodzić po pokoju

    void Update()
    {

        // aktywacja zmiany pozycji gracza 
        if (playerCanChangePosition)
        {
            Debug.Log("playerCanChangePosition = true");
            switch (statementPosition)
            {
                case 1:
                    Statement_1_Active();
                    break;
                default:
                    break;

            }
        }
        // wyłaczenie jeśli dotarł do pozycji
        if (playerDestination == currentPlayerPosition)
        {
            playerCanChangePosition = false;
            // kiedy przywracamy canMove na true dostajemy starą zmienną z kliknięcia przez co nasza postać biega w "lewo a potem w prawo"
            //PlayerMovement.canMove = true;
        }
    }
    public void Statement_1_Active()
    {
        Active_Player_Movement_And_Get_Last_Position();
        float step = PlayerMovement.walkspeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, playerDestination, step);

    }

    public void Active_Player_Movement_And_Get_Last_Position()
    {
        playerDestination = new Vector2(2, -6);
        currentPlayerPosition = gameObject.transform.position;
        Debug.Log("current position" + currentPlayerPosition);
        PlayerMovement.moving = true; // zmienna aktywacji animacji chodzenia
    }



}
