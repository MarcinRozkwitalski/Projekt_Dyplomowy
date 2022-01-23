using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSHoverButton : MonoBehaviour
{
    void OnMouseEnter()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }

    void OnMouseExit()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
}
