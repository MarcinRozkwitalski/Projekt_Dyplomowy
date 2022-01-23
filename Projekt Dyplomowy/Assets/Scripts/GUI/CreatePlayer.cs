using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class CreatePlayer : MonoBehaviour
{
    Visability visability;
    public InputField usernameInput;
    public InputField passwordInput;
    public InputField emailInput;

    public Button RegisterButton;
    public Text RegisterButtonText;

    public void RegisterNewPlayer()
    {
        RegisterButton.interactable = false;

        if (usernameInput.text.Length < 5)
        {
            ErrorMessage("Nazwa Użytkownika jest za krótka");
        }
        else if (passwordInput.text.Length < 5)
        {
            ErrorMessage("Hasło jest za krótkie");
        }
        else if (emailInput.text.Length < 5)
        {
            ErrorMessage("Email jest nieprawidłowy");
        }
        else
        {
            SetButtonToSending();
            StartCoroutine(CreatePlayerPostRequest());
        }
    }

    public void ErrorMessage(string message)
    {
        RegisterButtonText.text = message;
        RegisterButtonText.fontSize = 30;
    }

    public void ResetRegisterButton()
    {
        RegisterButton.interactable = true;
        RegisterButtonText.text = "Zarejestruj";
        RegisterButtonText.fontSize = 30;
    }

    public void SetButtonToSending()
    {
        RegisterButtonText.text = "Przetwarzanie...";
        RegisterButtonText.fontSize = 30;
    }
    public void SetButtonToSucces()
    {
        RegisterButtonText.text = "Stworzone";
        RegisterButtonText.fontSize = 30;
    }

    IEnumerator CreatePlayerPostRequest()
    {
        WWWForm newPlayerInfo = new WWWForm();

        newPlayerInfo.AddField("username", usernameInput.text);
        newPlayerInfo.AddField("password", passwordInput.text);
        newPlayerInfo.AddField("email", emailInput.text);

        newPlayerInfo.AddField("apppassword", "kodApki123");

        UnityWebRequest CreatePostRequest = UnityWebRequest.Post("http://localhost/cruds/newplayer.php", newPlayerInfo);
        yield return CreatePostRequest.SendWebRequest();

        if (CreatePostRequest.error == null)
        {
            string response = CreatePostRequest.downloadHandler.text;
            Debug.Log(response);
            if (response == "1" || response == "2" || response == "4" || response == "6")
            {
                ErrorMessage("Error w Serwerze ");
            }
            else if (response == "3")
            {
                ErrorMessage("Nazwa Użytkownika istnieje");
            }
            else if (response == "5")
            {
                ErrorMessage("E-mail już istnieje, proszę wybrać inny.");
            }
            else
            {
                SetButtonToSucces();

            }
        }
        else
        {
            Debug.Log(CreatePostRequest.error);
        }
    }
}
