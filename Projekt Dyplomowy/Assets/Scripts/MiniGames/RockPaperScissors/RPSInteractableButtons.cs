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
}
