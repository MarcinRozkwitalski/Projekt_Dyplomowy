using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkspeed = 10f;
    public Rigidbody2D rb;
    float move;
    bool moving, space;
    float newPlayerPosition, lastPlayerPosition;

    Vector2 lastClickedPos;
    private void Update()
    {
        // float direction = Input.GetAxisRaw("Horizontal");
        // rb.velocity = new Vector2(walkspeed * direction * Time.fixedDeltaTime, rb.velocity.y);


        // https://www.youtube.com/watch?v=lCfoU1WoOhI&ab_channel=MuddyWolf
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

            //SKALOWANIE
            // newPlayerPosition = gameObject.transform.position.y;
            // Debug.Log("Scala = " + gameObject.transform.localScale.y);

            // OBSZAR SKALOWANIA JAKO DWIE LINIE KLATKA
            // if (gameObject.transform.position.y >= -1.460f && gameObject.transform.position.y < -0.59f)
            // {
            //     if (lastPlayerPosition < newPlayerPosition && gameObject.transform.localScale.y > 0.90f) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.01f, gameObject.transform.localScale.y - 0.01f, 1);
            //     else if (lastPlayerPosition > newPlayerPosition && gameObject.transform.localScale.y <= 0.99f) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.01f, gameObject.transform.localScale.y + 0.01f, 1);
            // }

            // if (gameObject.transform.position.y > -10.95f && gameObject.transform.position.y < -1.46f)
            // {
            //     if (lastPlayerPosition < newPlayerPosition && gameObject.transform.localScale.y > 0.99f) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.001f, gameObject.transform.localScale.y - 0.001f, 1);
            //     else if (lastPlayerPosition > newPlayerPosition && gameObject.transform.localScale.y < 1.1f) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.001f, gameObject.transform.localScale.y + 0.001f, 1);
            //     else Debug.Log("DZIAŁA");
            // }

            // OBSZAR SKALOWANIA JAKO JEDNA LINIA STOPA
            //  Debug.Log("Scala = " + gameObject.transform.localScale.y);
            // if (gameObject.transform.position.y >= -5.0f && gameObject.transform.position.y < -3.66f)
            // {
            //     if (lastPlayerPosition < newPlayerPosition && gameObject.transform.localScale.y > 0.95f) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.002f, gameObject.transform.localScale.y - 0.002f, 1);
            //     else if (lastPlayerPosition > newPlayerPosition && gameObject.transform.localScale.y <= 1.05f) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.002f, gameObject.transform.localScale.y + 0.002f, 1);
            // }

        }
        else
        {
            moving = false;
        }

        // https://docs.unity3d.com/ScriptReference/Transform-position.html
        if (!PlayerCanInteract.moveSpace)
        {
            float positionJump;

            if (gameObject.transform.position.x > 0) positionJump = -0.1f;
            else positionJump = 0.1f;

            //update the position
            gameObject.transform.position = transform.position + new Vector3(positionJump, -0.1f, 0);

            //output to log the position change
            Debug.Log(transform.position + "horizontal = " + gameObject.transform.position.x + "   positionJump " + positionJump);
        }

    }
}
