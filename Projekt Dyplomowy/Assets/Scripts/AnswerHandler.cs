using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AnswerHandler : MonoBehaviour
{
    public string getSentence = "Null";
    public Text text;
    public static int index = 11;

   public void LoadNewSentence()
    {
        Debug.Log("Category = " + (SentenceHandler.number % 6 + 1));
        GettingRandomStatement(SentenceHandler.number);
        SentenceHandler.number++;
    }

    public void GettingRandomStatement(int category)
    {
        int random;
        bool status = true;
        do
        {
            random = Random.Range(0, 15);
            index = category % 6 + 1 + random * 6;
            status = ReturningStatement(index);
            Debug.Log("index = " + index);
        } while (status);
    }

   public bool ReturningStatement(int index)
    {
        if ((string)SentenceHandler.hashTableStatements[index] != null)
        {
            text.text = (string)SentenceHandler.hashTableStatements[index];
            SentenceHandler.hashTableStatements.Remove(index);

            // information about hashTableAnswers
            Debug.Log("Number of answers = " + SentenceHandler.hashTableAnswers.Count);
            foreach (DictionaryEntry entry in SentenceHandler.hashTableAnswers)
            {
                Debug.Log(" [" + entry.Key + "] = " + entry.Value);
            }
            // Debug.Log("Yes");
            return false;
        }
        else
        {
            // Debug.Log("None");
            return true;
        }
    }
    public void AnswerYes()
    {
        SentenceHandler.hashTableAnswers.Add(index, "true");
        Debug.Log("Sentence : " + SentenceHandler.hashTableStatements[index] + "\n Answer : " + SentenceHandler.hashTableAnswers[index]);
    }
    public void AnswerNo()
    {
        SentenceHandler.hashTableAnswers.Add(index, "false");
        Debug.Log("Sentence : " + SentenceHandler.hashTableStatements[index] + "\n Answer : " + SentenceHandler.hashTableAnswers[index]);
    }

}
