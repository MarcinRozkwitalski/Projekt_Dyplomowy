using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCanInteract : MonoBehaviour
{
    string clickedObject = "nothing has been clicked";
    string tagName = "";
    string tagAnswer = "";
    public static bool moveSpace = true;
    public static bool canChangeIndex = true;
    public static bool playerCanPlay = true;
    public static bool playerCanDecide = true;
    static public bool playerCanClick = true;

    ArrayList usedObjects = new ArrayList();
    ArrayList interactableObjects = new ArrayList();
    Ray ray;
    RaycastHit2D hit;
    AnswerHandler answerHandler;
    RockPaperScissors rockPaperScissors;
    TestScriptForIndex testScriptForIndex;
    Manekin manekin;
    Laboratory laboratory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactableObjects.Add(other.name);
        foreach (string entry in interactableObjects)
        {
            Debug.Log(entry);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
        testScriptForIndex = GameObject.Find("IndexHandler").GetComponent<TestScriptForIndex>();
        manekin = GameObject.Find("MANEKINSCRIPT").GetComponent<Manekin>();
        laboratory = GameObject.Find("Laboratory").GetComponent<Laboratory>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

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
                else
                {
                    clickedObject = "";
                    tagName = "";
                }
            }
            else
            {
                clickedObject = "";
                tagName = "";
            }

        }
        if (interactableObjects.Contains(clickedObject) && usedObjects.Contains(clickedObject) == false && tagName == "CanLoadIndex" && canChangeIndex == true && TestScriptForIndex.stop == true)
        {

            AnswerHandler.index = testScriptForIndex.GetRandomIndex();
            TriggerAnimation.playAnimation = true;
            TriggerAnimation.runAnimation = true;

            canChangeIndex = false;
            usedObjects.Add(clickedObject);
        }
        else if (tagName == "Decision" && Input.GetMouseButtonDown(0) && playerCanDecide == true)
        {
            playerCanDecide = false;
            tagName = "";
            TriggerAnimation.runAnimation = false;
            TriggerAnimation.runAgain = true;
            if (tagAnswer == "True") answerHandler.AnswerYes();
            if (tagAnswer == "False") answerHandler.AnswerNo();
            answerHandler.ReturningStatement(AnswerHandler.index);// test
        }
        else if (tagName == "RPSButton" && Input.GetMouseButtonDown(0) && playerCanPlay == true)
        {
            tagName = "";
            playerCanPlay = false;
            StartCoroutine(rockPaperScissors.PlayRound(clickedObject));
        }
        else if (tagName == "WaitForClick" && Input.GetMouseButtonDown(0) && playerCanClick == true)
        {
            tagName = "";
            playerCanClick = false;
        }
        else if (tagName == "R" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            WaysOfLaunchingTheAnimations.viewStats = 1;
        }
        else if (tagName == "B" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            WaysOfLaunchingTheAnimations.viewStats = 2;
        }
        else if (tagName == "A" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            WaysOfLaunchingTheAnimations.viewStats = 3;
        }
        else if (tagName == "S" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            WaysOfLaunchingTheAnimations.viewStats = 4;
        }
        else if (tagName == "P" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            WaysOfLaunchingTheAnimations.viewStats = 5;
        }
        else if (tagName == "K" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            WaysOfLaunchingTheAnimations.viewStats = 6;
        }
        else if (tagName == "ReturnToStats" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            WaysOfLaunchingTheAnimations.viewStats = 7;
        }
        else if (tagName == "ExitStats" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            WaysOfLaunchingTheAnimations.game = 4;
        }

        //----------------------------- ANIMACJA 14----------------------------------//
        else if (tagName == "Sample_1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            laboratory.Sample_1();
        }
        else if (tagName == "Sample_2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            laboratory.Sample_2();
        }
        else if (tagName == "Sample_3" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            laboratory.Sample_3();
        }
        else if (tagName == "Sample_4" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            laboratory.Sample_4();
        }
        else if (tagName == "StartGame" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            laboratory.StartGameState(tagAnswer);
        }
        //----------------------------- ANIMACJA 14----------------------------------//

        //----------------------------- ANIMACJA 15----------------------------------//
        else if (tagName == "Manekin Koszula 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putTshirt1OnHanger();
        }
        else if (tagName == "Manekin Koszula 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putTshirt2OnHanger();
        }
        else if (tagName == "Manekin Spodnie 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putPants1OnHanger();
        }
        else if (tagName == "Manekin Spodnie 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putPants2OnHanger();
        }
        else if (tagName == "Manekin Czapka 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putHat1OnHanger();
        }
        else if (tagName == "Manekin Czapka 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putHat2OnHanger();
        }
        else if (tagName == "Manekin Kurtka 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putJacket1OnHanger();
        }
        else if (tagName == "Manekin Kurtka 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putJacket2OnHanger();
        }
        else if (tagName == "Manekin Parasol 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putUmbrella1OnHanger();
        }
        else if (tagName == "Manekin Parasol 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putUmbrella2OnHanger();
        }
        else if (tagName == "Koszula 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putTshirt1OnManekin();
        }
        else if (tagName == "Koszula 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putTshirt2OnManekin();
        }
        else if (tagName == "Spodnie 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putPants1OnManekin();
        }
        else if (tagName == "Spodnie 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putPants2OnManekin();
        }
        else if (tagName == "Czapka 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putHat1OnManekin();
        }
        else if (tagName == "Czapka 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putHat2OnManekin();
        }
        else if (tagName == "Kurtka 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putJacket1OnManekin();
        }
        else if (tagName == "Kurtka 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putJacket2OnManekin();
        }
        else if (tagName == "Parasol 1" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putUmbrella1OnManekin();
        }
        else if (tagName == "Parasol 2" && Input.GetMouseButtonDown(0))
        {
            tagName = "";
            manekin.putUmbrella2OnManekin();
        }
        //----------------------------- ANIMACJA 15----------------------------------//
        else
        {
        }
        moveSpace = true;
    }

}
