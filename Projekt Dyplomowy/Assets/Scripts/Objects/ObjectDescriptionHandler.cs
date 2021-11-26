using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDescriptionHandler : MonoBehaviour
{

    void Start()
    {
        GameObject originalGameObject = GameObject.Find(gameObject.name);
        GameObject child = originalGameObject.transform.GetChild(0).gameObject;
        child.SetActive(false);
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
