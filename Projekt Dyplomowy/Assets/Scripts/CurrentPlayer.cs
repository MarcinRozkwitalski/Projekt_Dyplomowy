using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayer : MonoBehaviour
{
    public string Username;
    public string Email;
    public int Score;

    private void Awake() {
        var players = FindObjectsOfType<CurrentPlayer>();
        if(players.Length > 1) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
