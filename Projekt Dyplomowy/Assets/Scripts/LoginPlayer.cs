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

    public void Login()
    {
        loginButton.interactable = false;
        loginButtonText.text = "Wysyła....";

        if (usernameInput.text.Length < 5)
        {
            ErrorOnLoginMessage("Sprawdż Nazwę Użytkownika");
        } else if (passwordInput.text.Length < 5)
        {
            ErrorOnLoginMessage("Sprawdż Hasło");
        } else
        {
            StartCoroutine(SendLoginForm());
        }
    }

    public void ErrorOnLoginMessage(string message)
    {
        loginButton.GetComponent<Image>().color = Color.red;
        loginButtonText.text = message;
        loginButtonText.fontSize = 60;
    }

    public void ResetLoginButton()
    {
        loginButton.GetComponent<Image>().color = Color.white;
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
            } else if ( result == "3")
            {
                ErrorOnLoginMessage("Sprawdż nazwę Użytkownika");
            } else
            {
                var currentPlayer = Instantiate(currentPlayerObject, new Vector3(0, 0, 0), Quaternion.identity);
                Debug.Log("UDAŁO SIĘ ZALOGOWAC");
                loginButton.GetComponent<Image>().color = Color.green;
                loginButtonText.text = "Zalogowano";
                loginButtonText.fontSize = 60;
            }
            Debug.Log(result);
        } else
        {
            Debug.Log(loginRequest.error);
        }
    }
}
