using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SentenceHandler : MonoBehaviour
{
    public static string[] descriptionlist;
    public static int number;
    public static Hashtable hashTableStatements;
    public static Hashtable hashTableAnswers;

    public void Button()
    {
        StartCoroutine(GetTesting());
    }

    IEnumerator GetTesting()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/test.php");
        yield return webRequest.SendWebRequest();
        GetDescription(webRequest.downloadHandler.text);
        number = Random.Range(0, 6);
    }

    public void GetDescription(string text)
    {
        hashTableStatements = new Hashtable();
        hashTableAnswers = new Hashtable();
        string newline = text;
        descriptionlist = newline.Split('.');
        for (int i = 1; i <= 90; i++)
        {
            hashTableStatements.Add(i, descriptionlist[i - 1]);
        }
    }
}
