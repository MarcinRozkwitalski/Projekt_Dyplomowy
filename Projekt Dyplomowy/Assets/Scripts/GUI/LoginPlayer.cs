using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoginPlayer : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public Text loginButtonText;
    public GameObject currentPlayerObject;

    private void Awake()
    {
        var CurrentPlayers = GameObject.FindGameObjectsWithTag("CurrentPlayer");
        foreach (var currentPlayer in CurrentPlayers)
        {
            Destroy(currentPlayer);
        }
    }

    public void Login()
    {
        loginButton.interactable = false;
        loginButtonText.text = "Wysyła....";

        if (usernameInput.text.Length < 5)
        {
            ErrorOnLoginMessage("Sprawdż nazwę użytkownika");
        }
        else if (passwordInput.text.Length < 5)
        {
            ErrorOnLoginMessage("Sprawdż hasło");
        }
        else
        {
            StartCoroutine(SendLoginForm());
        }
    }

    public void ErrorOnLoginMessage(string message)
    {
        loginButtonText.text = message;
        loginButtonText.fontSize = 60;
    }

    public void ResetLoginButton()
    {
        loginButtonText.text = "Login";
        loginButtonText.fontSize = 60;
        loginButton.interactable = true;
    }

    IEnumerator SendLoginForm()
    {
        WWWForm LoginInfo = new WWWForm();
        LoginInfo.AddField("apppassword", "kodApki123");
        LoginInfo.AddField("username", usernameInput.text);
        LoginInfo.AddField("password", passwordInput.text);

        UnityWebRequest loginRequest = UnityWebRequest.Post("http://localhost/cruds/loginplayer.php", LoginInfo);
        yield return loginRequest.SendWebRequest();
        if (loginRequest.error == null)
        {
            string result = loginRequest.downloadHandler.text;
            Debug.Log(result);
            if (result == "1" || result == "2" || result == "5")
            {
                ErrorOnLoginMessage("Error Serwerowy");
            }
            else if (result == "3")
            {
                ErrorOnLoginMessage("Sprawdż nazwę Użytkownika");
            }
            else if (result == "4")
            {
                ErrorOnLoginMessage("Sprawdż hasło");
            }
            else
            {
                var currentPlayer = Instantiate(currentPlayerObject, new Vector3(0, 0, 0), Quaternion.identity);
                currentPlayer.GetComponent<CurrentPlayer>().Username = result.Split(':')[0];
                currentPlayer.GetComponent<CurrentPlayer>().Score = int.Parse(result.Split(':')[1]);

                loginButton.GetComponent<Image>().color = Color.green;
                loginButtonText.text = "Zalogowano";
                //sceneLoader.LoadPlayerSceneScene();
            }
        }
        else
        {
            Debug.Log(loginRequest.error);
        }
    }
}
