using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanInteract : MonoBehaviour
{
    // Start is called before the first frame update
    ObjectSeePlayer objectToUse;
    bool canClickObject = false;
    string clickedObject = "nothing has been clicked";
    string interactableObject = "none";
    public static bool moveSpace = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        canClickObject = true;
        if (clickedObject == other.name)
        {
            interactableObject = other.name;
            // https://www.youtube.com/watch?v=ZHr3v8Ewxc0&ab_channel=GameDevTraum
            // objectToUse = GameObject.Find(other.name);
            objectToUse = GameObject.FindGameObjectWithTag(other.name).GetComponent<ObjectSeePlayer>();
            Debug.Log("Name of the object -> " + objectToUse.youCanUseMe);
            Debug.Log("Set object for interaction = " + interactableObject);
        }
        Debug.Log("I see object  " + interactableObject);
        //  player.collider.isTrigger = false;
        // GetComponent<Collider>().isTrigger = false;
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

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
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
        if (clickedObject == interactableObject)//&& objectToUse.GetComponent<ObjectSeePlayer>().youCanUseMe == true)
        {
            Debug.Log("We used = " + clickedObject);
            Debug.Log("RUN ANIMATION ");
            interactableObject = "none";
            objectToUse.useObject();
        }
        moveSpace = true;
    }

}
