using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanInteract : MonoBehaviour
{
    // Start is called before the first frame update
    bool canClickObject = false;
    string clickedObject = "nothing has been clicked";
    string interactableObject = "none";
    public static bool moveSpace = true;
    ArrayList usedObjects = new ArrayList();
    Ray ray;
    RaycastHit2D hit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        canClickObject = true;
        if (clickedObject == other.name)
        {
            interactableObject = other.name;
            Debug.Log("Name of the object -> ");
            Debug.Log("Set object for interaction = " + interactableObject);
        }
        Debug.Log("I see object  " + interactableObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("I cant see you");
        canClickObject = false;
        interactableObject = "";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpace = false;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        moveSpace = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            // https://answers.unity.com/questions/464954/raycast-tag-null-reference-exception.html - problem null 
            if (Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity))
            {
                if (hit.collider.name == "Player")
                {
                    Debug.Log("You click -> " + hit.collider.name);
                }
                else if (hit)
                {
                    Debug.Log("You click -> " + hit.collider.name);
                    clickedObject = hit.collider.name;
                }
                else
                {
                    Debug.Log("No interaction");
                    clickedObject = "";
                }
            }

        }
        if (clickedObject == interactableObject && usedObjects.Contains(clickedObject) == false)
        {
            Debug.Log("We used = " + clickedObject);
            Debug.Log("RUN ANIMATION ");
            interactableObject = "none";
            usedObjects.Add(clickedObject);
        }
        else
        {
            // Debug.Log("We cant use that object");
        }
        moveSpace = true;
    }

}
