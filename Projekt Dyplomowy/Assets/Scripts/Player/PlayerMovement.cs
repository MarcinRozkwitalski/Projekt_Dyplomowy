using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float walkspeed = 3f;
    public static bool moving, canMove = true;
    public static float lastPlayerPosition;

    public static Vector2 lastClickedPos;
    private void Update()
    {

        if (canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
            }

            if (moving && (Vector2)transform.position != lastClickedPos && PlayerCanInteract.moveSpace == true)
            {
                lastPlayerPosition = gameObject.transform.position.y;
                float step = walkspeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
            }
            else
            {
                moving = false;
            }

            if (!PlayerCanInteract.moveSpace)
            {
                float positionJump;
                if (gameObject.transform.position.x > 0) positionJump = -0.1f;
                else positionJump = 0.1f;
                gameObject.transform.position = transform.position + new Vector3(positionJump, -0.1f, 0);
            }
        }
        else
        {
            moving = false;
        }
    }
}
