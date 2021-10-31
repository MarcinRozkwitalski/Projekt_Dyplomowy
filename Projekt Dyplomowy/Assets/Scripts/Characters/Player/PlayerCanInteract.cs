using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanInteract : MonoBehaviour
{
    // Start is called before the first frame update
    bool canClickObject = false;
    string clickedObject = "";
    public static bool moveSpace = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I see object");
        canClickObject = true;
        //  player.collider.isTrigger = false;
        // GetComponent<Collider>().isTrigger = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("I cant see you");
        canClickObject = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpace = false;
        Debug.Log("przestan");
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        moveSpace = true;
        Debug.Log("dobrze");
    }

    void Update()
    {
        if (canClickObject)
        {
            // Debug.Log("You can click" + canClickObject);
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
                if (hit.collider.name == "Player")
                {
                    // brak interakcji z postacią
                    Debug.Log("You click -> " + hit.collider.name);
                }
                else if (hit)
                {
                    Debug.Log("You click -> " + hit.collider.name);
                }
                else
                {
                    Debug.Log("No interaction");
                }


            }
        }
        moveSpace = true;
    }

}
