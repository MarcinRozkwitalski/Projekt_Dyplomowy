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
        Options,
        Profile,
        Tutorial1,
        Tutorial2,
        Tutorial3,
        Tutorial4
    };

    public MenuStates currentState;

    public GameObject mainMenu;
    public GameObject registration;
    public GameObject login;
    public GameObject options;
    public GameObject profile;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4;


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
                profile.SetActive(false);

                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                break;
            case MenuStates.Registration:
                mainMenu.SetActive(false);
                registration.SetActive(true);
                login.SetActive(false);
                options.SetActive(false);
                profile.SetActive(false);

                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                break;
            case MenuStates.Login:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(true);
                options.SetActive(false);
                profile.SetActive(false);

                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                break;
            case MenuStates.Options:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(false);
                options.SetActive(true);
                profile.SetActive(false);

                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                break;
            case MenuStates.Profile:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(false);
                options.SetActive(false);
                profile.SetActive(true);

                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                break;
            case MenuStates.Tutorial1:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(false);
                options.SetActive(false);
                profile.SetActive(false);

                tutorial1.SetActive(true);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                break;
            case MenuStates.Tutorial2:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(false);
                options.SetActive(false);
                profile.SetActive(false);

                tutorial1.SetActive(false);
                tutorial2.SetActive(true);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                break;
            case MenuStates.Tutorial3:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(false);
                options.SetActive(false);
                profile.SetActive(false);

                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(true);
                tutorial4.SetActive(false);
                break;
            case MenuStates.Tutorial4:
                mainMenu.SetActive(false);
                registration.SetActive(false);
                login.SetActive(false);
                options.SetActive(false);
                profile.SetActive(false);

                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(true);
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
    public void goToProfile()
    {
        currentState = MenuStates.Profile;
    }
    public void goToTutorial1()
    {
        currentState = MenuStates.Tutorial1;
    }
    public void goToTutorial2()
    {
        currentState = MenuStates.Tutorial2;
    }
    public void goToTutorial3()
    {
        currentState = MenuStates.Tutorial3;
    }
    public void goToTutorial4()
    {
        currentState = MenuStates.Tutorial4;
    }

}
