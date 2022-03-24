using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestScriptForIndex : MonoBehaviour
{

    public static int index = 0;
    int randomIndex = 0;
    public static List<int> indexList = new List<int>();
    public static int[] stats = new int[91];
    List<int> usedIndexList = new List<int>();
    public static bool stop = true;
    void Start()
    {

        //     indexList.Add(1);
        //     indexList.Add(2);
        //     indexList.Add(3);
        //     indexList.Add(4);
        //     indexList.Add(6);
        // indexList.Add(7);
        //     indexList.Add(8);
        //     indexList.Add(10);
        //     indexList.Add(11);
        indexList.Add(14);
        // indexList.Add(15);
        //indexList.Add(18);
        //     indexList.Add(21);
        //indexList.Add(23);
        //     indexList.Add(24);
        //     indexList.Add(29);


        for (int i = 1; i <= 90; i++)
        {
            stats[i] = 0;
        }
    }

    public int GetRandomIndex()
    {
        bool status = true;
        do
        {
            randomIndex = Random.Range(0, 1);
            if (!usedIndexList.Contains(indexList[randomIndex]))
            {
                usedIndexList.Add(indexList[randomIndex]);
                index = indexList[randomIndex];
                status = false;
            }
        } while (status);
        if (usedIndexList.Count == indexList.Count) stop = false;
        return index;
    }

}
