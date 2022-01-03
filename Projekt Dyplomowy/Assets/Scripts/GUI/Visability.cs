using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visability : MonoBehaviour
{
    public enum MenuStates
    {
        Main,
        Registration,
        Login,
        Options
    };
    public MenuStates currentState;

    public GameObject mainMenu;
    public GameObject registration;
    public GameObject login;
    public GameObject options;

    public Animator transition;
    public float transitionTime = 1f;

    // When script starts
    void Awake()
    {
        currentState = MenuStates.Main;
    }

    void Update()
    {
        switch (currentState)
        {
            case MenuStates.Main:
                mainMenu.SetActive(true);
                registration.SetActive(false);
                login.SetActive(false);
                options.SetActive(false);
                break;
            case MenuStates.Registration:
                mainMenu.SetActive(false);
                registration.SetActive(true);
                login.SetActive(false);
                options.SetActive(false);
                break;
            case MenuStates.Login:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(true);
                options.SetActive(false);
                break;
            case MenuStates.Options:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(false);
                options.SetActive(true);
                break;

        }
    }

    public void goToMainMenu()
    {
        currentState = MenuStates.Main;
    }

    public void goToRegistration()
    {
        currentState = MenuStates.Registration;
    }
    public void goToLogin()
    {
        currentState = MenuStates.Login;
    }
    public void goToOptions()
    {
        currentState = MenuStates.Options;
    }
}
