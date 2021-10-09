using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerGameScript : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public Text UserInfoText;

    void Start () { 
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        int CurrentPlayerScore = CurrentPlayer.GetComponent<CurrentPlayer>().Score;

        UserInfoText.text = "Użytkownik: " + CurrentPlayerUsername + " | " + "Point: " + CurrentPlayerScore.ToString();
    }

    public void SignOut() {
        var CurrentPlayers = GameObject.FindGameObjectsWithTag("CurrentPlayer");
        foreach (var currentPlayer in CurrentPlayers) {
            Destroy(currentPlayer);
        }
        sceneLoader.LoadStartScene();

    }
}
