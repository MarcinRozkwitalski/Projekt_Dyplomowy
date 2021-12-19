using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissors : MonoBehaviour
{
    public int PlayerScore = 0, AIScore = 0, ScoreNeededToWin = 3;

    public static bool HasGameEnded = false, stopRandomisingPlayerChoice = false, stopRandomisingAIChoice = false;

    public Text Result;
    public string PlayerCurrentChoice, AICurrentChoice;

    public string[] Choices = { "Rock", "Paper", "Scissors" };

    public Sprite RockDefault, PaperDefault, ScissorsDefault,
                RockHover, PaperHover, ScissorsHover,
                RockChosen, PaperChosen, ScissorsChosen,
                PlayerChoice_Rock, PlayerChoice_Paper, PlayerChoice_Scissors,
                AIChoice_Rock, AIChoice_Paper, AIChoice_Scissors;

    GameObject playerScoreParent, AIScoreParent, playerChoiceParent, AIChoiceParent;

    RPSInteractableButtons rpsInteractableButtons;
    PreparedStatementAnimations preparedStatementAnimations;

    public IEnumerator PlayRound(string PlayerChoice)
    {
        string AIRandomChoice = Choices[Random.Range(0, Choices.Length)];
        rpsInteractableButtons.ClickedButton(PlayerChoice);
        //zatrzymanie losowania PlayerChoice
        //setbool stopRandomisingChoice to true
        stopRandomisingPlayerChoice = true;
        ViewChoiceOnScoreboard(PlayerChoice, "Player");
        
        yield return new WaitForSeconds(preparedStatementAnimations.MoveHands_Yes_11()-0.30f);
        //zatrzymanie losowanie AIChoice
        stopRandomisingAIChoice = true;
        ViewChoiceOnScoreboard(AIRandomChoice, "AI");
        preparedStatementAnimations.MoveHands_No_11();
        yield return new WaitForSeconds(2.0f);
        PlayerCanInteract.playerCanPlay = true;
        //setbool StopRandomisingChoice to false
        stopRandomisingPlayerChoice = false;
        stopRandomisingAIChoice = false;

        switch (AIRandomChoice)
        {
            case "Rock":
                switch (PlayerChoice)
                {
                    case "Paper":
                        Win();
                        break;
                    case "Scissors":
                        Lose();
                        break;
                    case "Rock":
                        Tie();
                        break;
                }
                break;
            case "Paper":
                switch (PlayerChoice)
                {
                    case "Scissors":
                        Win();
                        break;
                    case "Rock":
                        Lose();
                        break;
                    case "Paper":
                        Tie();
                        break;
                }
                break;
            case "Scissors":
                switch (PlayerChoice)
                {
                    case "Rock":
                        Win();
                        break;
                    case "Paper":
                        Lose();
                        break;
                    case "Scissors":
                        Tie();
                        break;
                }
                break;
        }
    }

    public void UpdateScoreboard()
    {
        SetActiveFalseScoreboard();
        switch (PlayerScore)
        {
            case 0:
                playerScoreParent.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                playerScoreParent.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                playerScoreParent.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:
                playerScoreParent.transform.GetChild(3).gameObject.SetActive(true);
                break;
        }

        switch (AIScore)
        {
            case 0:
                AIScoreParent.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                AIScoreParent.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                AIScoreParent.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:
                AIScoreParent.transform.GetChild(3).gameObject.SetActive(true);
                break;
        }
    }

    public void ViewChoiceOnScoreboard(string choice, string whichSide)
    {
        SetDisactiveChoicesOnScoreboard();
        switch(choice)
        {
            case "Rock":
                if (whichSide == "Player")
                {
                    playerChoiceParent.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (whichSide == "AI")
                {
                    AIChoiceParent.transform.GetChild(0).gameObject.SetActive(true);
                }
                break;
            case "Paper":
                if (whichSide == "Player")
                {
                    playerChoiceParent.transform.GetChild(1).gameObject.SetActive(true);
                }
                else if (whichSide == "AI")
                {
                    AIChoiceParent.transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
            case "Scissors":
                if (whichSide == "Player")
                {
                    playerChoiceParent.transform.GetChild(2).gameObject.SetActive(true);
                }
                else if (whichSide == "AI")
                {
                    AIChoiceParent.transform.GetChild(2).gameObject.SetActive(true);
                }
                break;
        }
    }

    public void SetDisactiveChoicesOnScoreboard()
    {
        for (int i = 0; i < playerChoiceParent.transform.childCount; i++)
        {
            playerChoiceParent.transform.GetChild(i).gameObject.SetActive(false);
            AIChoiceParent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public IEnumerator RandomiseChoicesOnScoreboard(bool randomiseChoice, string whichSide)
    {
        SetDisactiveChoicesOnScoreboard();
        if(randomiseChoice == false)
        {
            string RandomChoice = Choices[Random.Range(0, Choices.Length)];
            switch(RandomChoice)
            {
                case "Rock":
                    if (whichSide == "Player")
                    {
                        playerChoiceParent.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else if (whichSide == "AI")
                    {
                        AIChoiceParent.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    break;
                case "Paper":
                    if (whichSide == "Player")
                    {
                        playerChoiceParent.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    else if (whichSide == "AI")
                    {
                        AIChoiceParent.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    break;
                case "Scissors":
                    if (whichSide == "Player")
                    {
                        playerChoiceParent.transform.GetChild(2).gameObject.SetActive(true);
                    }
                    else if (whichSide == "AI")
                    {
                        AIChoiceParent.transform.GetChild(2).gameObject.SetActive(true);
                    }
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SetActiveFalseScoreboard()
    {
        for (int i = 0; i < playerScoreParent.transform.childCount; i++)
        {
            playerScoreParent.transform.GetChild(i).gameObject.SetActive(false);
            AIScoreParent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void Win()
    {
        Result.text = "Wygrana!";
        PlayerScore++;
        UpdateScoreboard();
        CheckWinCondition();
    }

    public void Lose()
    {
        Result.text = "Przegrana...";
        AIScore++;
        UpdateScoreboard();
        CheckWinCondition();
    }

    public void Tie()
    {
        Result.text = "Remis";
    }

    public void CheckWinCondition()
    {
        if (PlayerScore == 3)
        {
            Result.text = "Wygrałeś grę w papier kamień nożyce!";
            HasGameEnded = true;
        }
        if (AIScore == 3)
        {
            Result.text = "Przegrałeś grę w papier kamień nożyce!";
            HasGameEnded = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScoreParent = GameObject.Find("PlayerScore");
        AIScoreParent = GameObject.Find("AIScore");
        playerChoiceParent = GameObject.Find("PlayerChoice");
        AIChoiceParent = GameObject.Find("AIChoice");
        rpsInteractableButtons = GameObject.Find("InteractableButtons").GetComponent<RPSInteractableButtons>();
        preparedStatementAnimations = GameObject.Find("AnimationHandler").GetComponent<PreparedStatementAnimations>();
        PlayerScore = 0;
        AIScore = 0;
        HasGameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}