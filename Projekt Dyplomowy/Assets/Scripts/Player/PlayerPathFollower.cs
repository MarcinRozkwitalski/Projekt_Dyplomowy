using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPathFollower : MonoBehaviour
{
    public static Vector2 playerDestination = new Vector2(-2, -8);
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
            PlayerMovement.canMove = true;
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
        PlayerMovement.lastClickedPos = currentPlayerPosition; // ustawia nam pozycje lastClickedPos po to by po zakonczeniu przmieszczania nie potrzebnie znowu się nam pozycja zmieniła
        Debug.Log("current position" + currentPlayerPosition);
        PlayerMovement.moving = true; // zmienna aktywacji animacji chodzenia
    }



}
