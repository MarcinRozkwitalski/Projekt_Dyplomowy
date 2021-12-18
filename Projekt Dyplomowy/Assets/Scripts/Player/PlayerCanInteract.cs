using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCanInteract : MonoBehaviour
{
    // Start is called before the first frame update
    bool canClickObject = false;
    string clickedObject = "nothing has been clicked";
    string interactableObject = "none";
    string otherString = "";
    string tagName = "";
    string tagAnswer = "";
    public static bool moveSpace = true;
    public static bool canChangeIndex = false;
    public static bool playerCanPlay = true;
    ArrayList usedObjects = new ArrayList();
    ArrayList interactableObjects = new ArrayList();
    Ray ray;
    RaycastHit2D hit;
    AnswerHandler answerHandler;
    RockPaperScissors rockPaperScissors;

    private void OnTriggerEnter2D(Collider2D other)
    {
        canClickObject = true;
        interactableObjects.Add(other.name);
        foreach (string entry in interactableObjects)
        {
            Debug.Log(entry);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("I cant see you");
        canClickObject = false;
        interactableObjects.Remove(other.name);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpace = false;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        moveSpace = true;
    }

    void Start()
    {
        answerHandler = GameObject.Find("IndexHandler").GetComponent<AnswerHandler>();
        rockPaperScissors = GameObject.Find("11RockPaperScissors").GetComponent<RockPaperScissors>();
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
                else if (hit.collider.name != "")
                {
                    Debug.Log("You click -> " + hit.collider.tag);
                    tagName = hit.collider.tag;
                    if (hit.collider.transform.childCount > 0)
                    {
                        GameObject child = hit.collider.transform.GetChild(0).gameObject;
                        tagAnswer = child.tag;
                    }
                    clickedObject = hit.collider.name;
                }

            }
            else
            {
                Debug.Log("No interaction");
                clickedObject = "";
                tagName = "";
            }

        }
        if (interactableObjects.Contains(clickedObject) && usedObjects.Contains(clickedObject) == false && tagName == "CanLoadIndex" && canChangeIndex == true)
        {
            canChangeIndex = false; // zapobiega ładowaniu nowych indeksów w czasie decyzji 
            Debug.Log("We used = " + clickedObject);
            Debug.Log("RUN ANIMATION ");
            interactableObject = "none";
            usedObjects.Add(clickedObject);
            // DoorHandler.doorStatus += 1; // zmienna do otwierania drzwi
            answerHandler.LoadNewSentence();
        }
        else if (tagName == "Decision" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            TriggerAnimation.runAnimation = false;
            TriggerAnimation.runAgain = true;
            Debug.Log("TAG = " + tagAnswer + ",  Index =" + AnswerHandler.index);
            if (tagAnswer == "True") answerHandler.AnswerYes();
            if (tagAnswer == "False") answerHandler.AnswerNo();
            answerHandler.ReturningStatement(AnswerHandler.index);// test
        }
        else if (tagName == "RPSButton" && Input.GetMouseButtonDown(0) && playerCanPlay == true)
        {
            tagName = "";
            Debug.Log("RPS: " + clickedObject);
            playerCanPlay = false;
            StartCoroutine(rockPaperScissors.PlayRound(clickedObject));
        }

        else
        {
            // Debug.Log("We cant use that object");
        }
        moveSpace = true;
    }

}
