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
    public static bool moveSpace = true;
    ArrayList usedObjects = new ArrayList();
    Ray ray;
    RaycastHit2D hit;
    //public AnswerHandler script; // nie działa



    public string getSentence = "Null";
    public Text text;
    public static int index;

    public void LoadNewSentence()
    {
        Debug.Log("Category = " + (SentenceHandler.number % 6 + 1));
        GettingRandomStatement(SentenceHandler.number);
        SentenceHandler.number++;
    }

    public void GettingRandomStatement(int category)
    {
        int random;
        bool status = true;
        do
        {
            random = Random.Range(0, 15);
            index = category % 6 + 1 + random * 6;
            status = ReturningStatement(index);
            Debug.Log("index = " + index);
        } while (status);
    }

    public bool ReturningStatement(int index)
    {
        if ((string)SentenceHandler.hashTableStatements[index] != null)
        {
            text.text = (string)SentenceHandler.hashTableStatements[index];
            SentenceHandler.hashTableStatements.Remove(index);

            // information about hashTableAnswers
            Debug.Log("Number of answers = " + SentenceHandler.hashTableAnswers.Count);
            foreach (DictionaryEntry entry in SentenceHandler.hashTableAnswers)
            {
                Debug.Log(" [" + entry.Key + "] = " + entry.Value);
            }
            // Debug.Log("Yes");
            return false;
        }
        else
        {
            // Debug.Log("None");
            return true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canClickObject = true;
        otherString = other.name;
        // if (clickedObject == other.name)
        // {
        //     interactableObject = other.name;
        //     Debug.Log("Name of the object -> ");
        //     Debug.Log("Set object for interaction = " + interactableObject);
        // }
        Debug.Log("I see object  " + interactableObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("I cant see you");
        canClickObject = false;
        interactableObject = "none";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpace = false;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        moveSpace = true;
    }

    void ClickWithCollisionOn(){
        if (clickedObject == otherString && usedObjects.Contains(clickedObject) == false)
        {
            interactableObject = otherString;
            Debug.Log("Name of the object -> ");
            Debug.Log("Set object for interaction = " + interactableObject);
        }
    }
    
    void Start(){

    }

    void Update()
    {
        if (canClickObject)ClickWithCollisionOn();
        if (Input.GetMouseButtonDown(0))
        {
            DoorHandler.doorStatus += 1; // zmienna do otwierania drzwi
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
                    Debug.Log("You click -> " + hit.collider.name);
                    clickedObject = hit.collider.name;
                }
               
            }
            else 
            {
                Debug.Log("No interaction");
                clickedObject = "";
            }

        }
        if (clickedObject == interactableObject && usedObjects.Contains(clickedObject) == false)
        {
            Debug.Log("We used = " + clickedObject);
            Debug.Log("RUN ANIMATION ");
            interactableObject = "none";
            usedObjects.Add(clickedObject);
            // wybranie stwierdzenia id 2 
            //animator.Play("fromthebottom");
            // książka i pocja 1 i 2....blur w tle
            // schowanie książki po odpowiedzi

            LoadNewSentence();
        }
        else
        {
            // Debug.Log("We cant use that object");
        }
        moveSpace = true;
    }

}
