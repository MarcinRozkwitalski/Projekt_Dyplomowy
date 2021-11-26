using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visability : MonoBehaviour
{
    public void showIt(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void hideIt(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
