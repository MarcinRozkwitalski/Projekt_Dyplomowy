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
    ArrayList usedObjects = new ArrayList();
    ArrayList interactableObjects = new ArrayList();
    Ray ray;
    RaycastHit2D hit;
    //public AnswerHandler script; // nie działa


    /////////////////////////////////////////////////////////////////////// osobny kod od stwierdzeń
    public string getSentence = "Null";
    public Text text;
    public static int index = 1;

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
    public void AnswerYes()
    {
        SentenceHandler.hashTableAnswers.Add(index, "true");
        Debug.Log("Sentence : " + SentenceHandler.hashTableStatements[index] + "\n Answer : " + SentenceHandler.hashTableAnswers[index]);
    }
    public void AnswerNo()
    {
        SentenceHandler.hashTableAnswers.Add(index, "false");
        Debug.Log("Sentence : " + SentenceHandler.hashTableStatements[index] + "\n Answer : " + SentenceHandler.hashTableAnswers[index]);
    }

    ////////////////////////////////////////////////////////////////// Interakcja z colliderami
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
                    GameObject child = hit.collider.transform.GetChild(0).gameObject;
                    tagAnswer = child.tag;
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
        if (interactableObjects.Contains(clickedObject) && usedObjects.Contains(clickedObject) == false && tagName == "CanLoadIndex")
        {
            Debug.Log("We used = " + clickedObject);
            Debug.Log("RUN ANIMATION ");
            interactableObject = "none";
            usedObjects.Add(clickedObject);
            // DoorHandler.doorStatus += 1; // zmienna do otwierania drzwi
            LoadNewSentence();
        }
        else if (tagName == "Decision" && Input.GetMouseButtonDown(0))
        {
            TriggerAnimation.runAnimation = false;
            TriggerAnimation.runAgain = true;
            // Debug.Log("TAG = " + tagAnswer + ",  Index =" + index);
            ReturningStatement(index);// test
            if (tagAnswer == "True") AnswerYes();
            if (tagAnswer == "False") AnswerNo();
        }
        else
        {
            // Debug.Log("We cant use that object");
        }
        moveSpace = true;
    }

}
