using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSInteractableButtons : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++){
            for (int j = 0; j < gameObject.transform.GetChild(i).transform.childCount; j++){
                if(j == 0){
                    gameObject.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(true);
                }
                else{
                    gameObject.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
    }

    public void ClickedButton(string PlayerChoice){
        switch(PlayerChoice){
            case "Rock":
                gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "Paper":
                gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "Scissors":
                gameObject.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).transform.GetChild(2).gameObject.SetActive(true);
                break;
        }
    }
}
