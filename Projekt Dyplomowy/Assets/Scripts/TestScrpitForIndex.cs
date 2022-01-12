using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestScrpitForIndex : MonoBehaviour
{

    public static int index = 0;
    int randomIndex = 0;
    public static List<int> indexList = new List<int>();
    public static int[] stats = new int[91];
    List<int> usedIndexList = new List<int>();
    public static bool stop = true;
    void Start()
    {
        // indexList.Add(1);// FIN
        // indexList.Add(2);
        // indexList.Add(3);// FIN
        // indexList.Add(4);// FIN
        // indexList.Add(7);
        // indexList.Add(8); // NOT FINISHED
        // indexList.Add(10); // NOT FINISHED
        // indexList.Add(11); // FIN
        // indexList.Add(21); // NOT FINISHED 
        // indexList.Add(24); // FIN
        // indexList.Add(29); // FIN
        

        for (int i = 1; i <= 90; i++)
        {
            stats[i] = 0;
        }
    }

    public int GetRandomIndex()
    {
        bool status = true;
        Debug.Log("ile = " + indexList.Count);

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
        if (usedIndexList.Count == indexList.Count) stop = false;
        Debug.Log("stop = " + stop);
        return index;
    }

}
