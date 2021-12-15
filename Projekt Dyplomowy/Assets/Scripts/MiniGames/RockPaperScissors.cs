using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissors : MonoBehaviour
{
    public int PlayerScore = 0, AIScore = 0, ScoreNeededToWin = 3;

    public Text Result;
    public Sprite PlayerChoice, AIChoice;

    public string[] Choices = {"Rock", "Paper", "Scissors"};

    public Sprite RockDefault, PaperDefault, ScissorsDefault,
                RockHover, PaperHover, ScissorsHover,
                RockChosen, PaperChosen, ScissorsChosen;

    public void Play(string PlayerChoice){
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

    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
        AIScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
