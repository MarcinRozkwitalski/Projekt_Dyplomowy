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

    public Animator transition;
    public float transitionTime = 1f;

    // When script starts
    void Awake()
    {
        // Always set main menu as active 
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
                //options.setActive(false);
                break;
            case MenuStates.Registration:
                mainMenu.SetActive(false);
                registration.SetActive(true);
                login.SetActive(false);
                //options.setActive(false);
                break;
            case MenuStates.Login:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(true);
                //options.setActive(false);
                break;
                //case MenuStates.Options:
                //mainMenu.setActive(false);
                //registration.setActive(false);
                //login.setActive(false);
                //options.setActive(true);
                //break;

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
    //----------------------------------------------------------------Options-----------------------------------------------------------------//
    //public void goToOptions()
    //{
    //    currentState = MenuStates.Options;
    //}


}
