using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestScrpitForIndex : MonoBehaviour
{

    public static int index = 0;
    int randomIndex = 0;
    List<int> indexList = new List<int>();
    List<int> usedIndexList = new List<int>();
    public static bool stop = true;
    void Start()
    {
        // indexList.Add(1);
        // indexList.Add(11);
        //indexList.Add(2);
        indexList.Add(3);
    }

    public int GetRandomIndex()
    {
        bool status = true;
        Debug.Log("ile = " + indexList.Count);
        if (usedIndexList.Count == 2) { Debug.Log("KONIEC GRY PANIE"); index = 0; }
        else
        {
            do
            {
                randomIndex = Random.Range(0, 1); //  0 
                if (!usedIndexList.Contains(indexList[randomIndex]))
                {
                    usedIndexList.Add(indexList[randomIndex]);
                    index = indexList[randomIndex];
                    Debug.Log("get index = " + index);
                    status = false;
                }
            } while (status);
        }
        if (usedIndexList.Count == 2)stop = false;
        return index;
    }

}
