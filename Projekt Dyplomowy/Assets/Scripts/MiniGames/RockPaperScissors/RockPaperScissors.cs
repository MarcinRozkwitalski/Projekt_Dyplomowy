using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissors : MonoBehaviour
{
    public int PlayerScore = 0, AIScore = 0, ScoreNeededToWin = 3;

    public bool HasGameEnded = false;

    public Text Result;
    public string PlayerCurrentChoice, AICurrentChoice;

    public string[] Choices = {"Rock", "Paper", "Scissors"};

    public Sprite RockDefault, PaperDefault, ScissorsDefault,
                RockHover, PaperHover, ScissorsHover,
                RockChosen, PaperChosen, ScissorsChosen,
                PlayerChoice_Rock, PlayerChoice_Paper, PlayerChoice_Scissors,
                AIChoice_Rock, AIChoice_Paper, AIChoice_Scissors;

    public void PlayRound(string PlayerChoice){
        string AIRandomChoice = Choices[Random.Range(0, Choices.Length)];

        switch(AIRandomChoice){
            case "Rock":
                switch(PlayerChoice){
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
                switch(PlayerChoice){
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
                switch(PlayerChoice){
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

    public void Win(){
        Result.text = "Wygrana!";
        PlayerScore++;
    }

    public void Lose(){
        Result.text = "Przegrana...";
        AIScore++;
    }

    public void Tie(){
        Result.text = "Remis";
    }

    public void CheckWinCondition(){
        if(PlayerScore == 3){
            Result.text = "Wygrałeś grę w papier kamień nożyce!";
            HasGameEnded = true;
        }
        if(AIScore == 3){
            Result.text = "Przegrałeś grę w papier kamień nożyce!";
            HasGameEnded = true;
        }
    }

    void OnMouseEnter()
    {
        GameObject originalGameObject = GameObject.Find(gameObject.name);
        GameObject child = originalGameObject.transform.GetChild(0).gameObject;
        child.SetActive(true);
    }

    void OnMouseExit()
    {
        GameObject originalGameObject = GameObject.Find(gameObject.name);
        GameObject child = originalGameObject.transform.GetChild(0).gameObject;
        child.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
        AIScore = 0;
        HasGameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
