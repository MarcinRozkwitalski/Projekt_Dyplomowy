using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AnswerHandler : MonoBehaviour
{
    public Text text;
    public static int index = 0;

   public void LoadNewSentence()
    {
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
        } while (status);
    }

   public bool ReturningStatement(int index)
    {
        if ((string)SentenceHandler.hashTableStatements[index] != null)
        {
          //  text.text = (string)SentenceHandler.hashTableStatements[index];
            SentenceHandler.hashTableStatements.Remove(index);

            foreach (DictionaryEntry entry in SentenceHandler.hashTableAnswers)
            {
                Debug.Log(" [" + entry.Key + "] = " + entry.Value);
            }
            return false;
        }
        else
        {
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
