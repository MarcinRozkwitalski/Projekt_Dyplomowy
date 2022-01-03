using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class CreatePlayer : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public InputField emailInput;

    public Button RegisterButton;
    public Text RegisterButtonText;

    public SceneLoader sceneLoader;

    // Logika GUI
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

    // Czerwony przycisk ( jak coś jest nieprawidłowe )
    public void ErrorMessage(string message)
    {
        //RegisterButton.GetComponent<Image>().color = Color.red;
        RegisterButtonText.text = message;
        RegisterButtonText.fontSize = 50;
    }

    // Biały przycisk ( jak się jest w trakcie edycji )
    public void ResetRegisterButton()
    {
        RegisterButton.interactable = true;
        //RegisterButton.GetComponent<Image>().color = Color.white;
        RegisterButtonText.text = "Zarejestruj";
        RegisterButtonText.fontSize = 50;
    }

    // Szary przycisk ( Dane są w trakcie przetwarzania )
    public void SetButtonToSending()
    {
        //RegisterButton.GetComponent<Image>().color = Color.grey;
        RegisterButtonText.text = "Przetwarzanie...";
        RegisterButtonText.fontSize = 50;
    }

    // Zielony przycisk ( Udało się przesłać )
    public void SetButtonToSucces()
    {
        //RegisterButton.GetComponent<Image>().color = Color.green;
        RegisterButtonText.text = "Stworzone";
        RegisterButtonText.fontSize = 50;
        //sceneLoader.LoadPlayerSceneScene();
    }

    // Przesyłanie Posta do bazy
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
                ErrorMessage("Error w Serwerze, spróbuje ponownie! ");
            }
            else if (response == "3")
            {
                ErrorMessage("Nazwa Użytkownika już istnieje, proszę wybrać inną");
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
