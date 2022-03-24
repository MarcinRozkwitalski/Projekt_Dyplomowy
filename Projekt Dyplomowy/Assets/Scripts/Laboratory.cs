using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laboratory : MonoBehaviour
{

    public static bool gameEnded = false;
    public GameState currentState;

    public enum GameState
    {
        StartGame,
        Sample_1,
        Sample_2,
        Sample_3,
        Sample_4,
        EndGame
    }
    public GameObject sample_1_answer_x, sample_2_answer_x, sample_3_answer_x, sample_4_answer_x;
    public GameObject sample_1_answer_o, sample_2_answer_o, sample_3_answer_o, sample_4_answer_o;
    public GameObject sample_1_answer_t, sample_2_answer_t, sample_3_answer_t, sample_4_answer_t;
    public GameObject sample_1_answer_k, sample_2_answer_k, sample_3_answer_k, sample_4_answer_k;

    void StartGame()
    {

    }

    void Start()
    {
        currentState = GameState.StartGame;
    }

    public void Gameplay(Animator animator)
    {
        switch (currentState)
        {
            case GameState.StartGame:
                animator.SetInteger("Sample", 0);
                break;
            case GameState.Sample_1:
                animator.SetInteger("Sample", 1);
                break;
            case GameState.Sample_2:
                animator.SetInteger("Sample", 2);
                break;
            case GameState.Sample_3:
                animator.SetInteger("Sample", 3);
                break;
            case GameState.Sample_4:
                animator.SetInteger("Sample", 4);
                break;
            case GameState.EndGame:
                animator.SetBool("Game", false);
                break;
            default:
                break;
        }
        if (sample_1_answer_x.activeSelf && sample_2_answer_k.activeSelf && sample_3_answer_o.activeSelf && sample_4_answer_t.activeSelf) currentState = GameState.EndGame;
    }

    // metody zmieniające currentstate

    public void StartGameState(string answer)
    {
        SampleSetAnswer(answer);
        currentState = GameState.StartGame;
    }
    public void Sample_1()
    {
        currentState = GameState.Sample_1;
    }
    public void Sample_2()
    {
        currentState = GameState.Sample_2;
    }
    public void Sample_3()
    {
        currentState = GameState.Sample_3;
    }
    public void Sample_4()
    {
        currentState = GameState.Sample_4;
    }

    public void SampleSetAnswer(string answer)
    {
        switch (currentState)
        {
            case GameState.Sample_1:
                Sample_1_Answer(answer);
                break;
            case GameState.Sample_2:
                Sample_2_Answer(answer);
                break;
            case GameState.Sample_3:
                Sample_3_Answer(answer);
                break;
            case GameState.Sample_4:
                Sample_4_Answer(answer);
                break;
            default:
                break;
        }
    }
    public void Sample_1_Answer(string answer)
    {
        switch (answer)
        {
            case "x":
                sample_1_answer_x.SetActive(true);
                sample_1_answer_o.SetActive(false);
                sample_1_answer_t.SetActive(false);
                sample_1_answer_k.SetActive(false);
                break;
            case "o":
                sample_1_answer_x.SetActive(false);
                sample_1_answer_o.SetActive(true);
                sample_1_answer_t.SetActive(false);
                sample_1_answer_k.SetActive(false);
                break;
            case "t":
                sample_1_answer_x.SetActive(false);
                sample_1_answer_o.SetActive(false);
                sample_1_answer_t.SetActive(true);
                sample_1_answer_k.SetActive(false);
                break;
            case "k":
                sample_1_answer_x.SetActive(false);
                sample_1_answer_o.SetActive(false);
                sample_1_answer_t.SetActive(false);
                sample_1_answer_k.SetActive(true);
                break;
            default:
                break;

        }
    }

    public void Sample_2_Answer(string answer)
    {
        switch (answer)
        {
            case "x":
                sample_2_answer_x.SetActive(true);
                sample_2_answer_o.SetActive(false);
                sample_2_answer_t.SetActive(false);
                sample_2_answer_k.SetActive(false);
                break;
            case "o":
                sample_2_answer_x.SetActive(false);
                sample_2_answer_o.SetActive(true);
                sample_2_answer_t.SetActive(false);
                sample_2_answer_k.SetActive(false);
                break;
            case "t":
                sample_2_answer_x.SetActive(false);
                sample_2_answer_o.SetActive(false);
                sample_2_answer_t.SetActive(true);
                sample_2_answer_k.SetActive(false);
                break;
            case "k":
                sample_2_answer_x.SetActive(false);
                sample_2_answer_o.SetActive(false);
                sample_2_answer_t.SetActive(false);
                sample_2_answer_k.SetActive(true);
                break;
            default:
                break;

        }
    }

    public void Sample_3_Answer(string answer)
    {
        switch (answer)
        {
            case "x":
                sample_3_answer_x.SetActive(true);
                sample_3_answer_o.SetActive(false);
                sample_3_answer_t.SetActive(false);
                sample_3_answer_k.SetActive(false);
                break;
            case "o":
                sample_3_answer_x.SetActive(false);
                sample_3_answer_o.SetActive(true);
                sample_3_answer_t.SetActive(false);
                sample_3_answer_k.SetActive(false);
                break;
            case "t":
                sample_3_answer_x.SetActive(false);
                sample_3_answer_o.SetActive(false);
                sample_3_answer_t.SetActive(true);
                sample_3_answer_k.SetActive(false);
                break;
            case "k":
                sample_3_answer_x.SetActive(false);
                sample_3_answer_o.SetActive(false);
                sample_3_answer_t.SetActive(false);
                sample_3_answer_k.SetActive(true);
                break;
            default:
                break;

        }
    }

    public void Sample_4_Answer(string answer)
    {
        switch (answer)
        {
            case "x":
                sample_4_answer_x.SetActive(true);
                sample_4_answer_o.SetActive(false);
                sample_4_answer_t.SetActive(false);
                sample_4_answer_k.SetActive(false);
                break;
            case "o":
                sample_4_answer_x.SetActive(false);
                sample_4_answer_o.SetActive(true);
                sample_4_answer_t.SetActive(false);
                sample_4_answer_k.SetActive(false);
                break;
            case "t":
                sample_4_answer_x.SetActive(false);
                sample_4_answer_o.SetActive(false);
                sample_4_answer_t.SetActive(true);
                sample_4_answer_k.SetActive(false);
                break;
            case "k":
                sample_4_answer_x.SetActive(false);
                sample_4_answer_o.SetActive(false);
                sample_4_answer_t.SetActive(false);
                sample_4_answer_k.SetActive(true);
                break;
            default:
                break;

        }
    }
}
