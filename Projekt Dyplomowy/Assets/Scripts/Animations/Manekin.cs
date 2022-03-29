using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manekin : MonoBehaviour
{
    public enum ManekinStates
    {
        Manekin,
        Manekin_HAT_1,
        Manekin_HAT_2,
        Manekin_JACKET_1,
        Manekin_JACKET_2,
        Manekin_PANTS_1,
        Manekin_PANTS_2,
        Manekin_TSHIRT_1,
        Manekin_TSHIRT_2,
        Manekin_UMBRELLA_1,
        Manekin_UMBRELLA_2,

        //Left Side
        PANTS_1,
        PANTS_2,
        TSHIRT_1,
        TSHIRT_2,
        UMBRELLA_1,

        //Right Side
        HAT_1,
        HAT_2,
        JACKET_1,
        JACKET_2,
        UMBRELLA_2,
        END_GAME
    };

    public ManekinStates currentState;

    public GameObject hat1OnManekin;
    public GameObject hat2OnManekin;
    public GameObject jacket1OnManekin;
    public GameObject jacket2OnManekin;
    public GameObject pants1OnManekin;
    public GameObject pants2OnManekin;
    public GameObject tshirt1OnManekin;
    public GameObject tshirt2OnManekin;
    public GameObject umbrella1OnManekin;
    public GameObject umbrella2OnManekin;

    public GameObject pants1OnHanger;
    public GameObject pants2OnHanger;
    public GameObject tshirt1OnHanger;
    public GameObject tshirt2OnHanger;
    public GameObject umbrella1OnHanger;

    public GameObject hat1OnHanger;
    public GameObject hat2OnHanger;
    public GameObject jacket1OnHanger;
    public GameObject jacket2OnHanger;
    public GameObject umbrella2OnHanger;

    public GameObject zatwierdz;

    void Awake()
    {
        currentState = ManekinStates.Manekin;
    }

    public void StartGame(Animator animator)
    {
        switch (currentState)
        {
            case ManekinStates.Manekin:
                //GameObject.Find("MIDDLE MANEKIN").transform.Find("MAN CZAPA 1").gameObject.SetActive(false);
                hat1OnManekin.SetActive(false);
                hat2OnManekin.SetActive(false);
                hat1OnHanger.SetActive(true);
                hat2OnHanger.SetActive(true);

                jacket1OnManekin.SetActive(false);
                jacket2OnManekin.SetActive(false);
                jacket1OnHanger.SetActive(true);
                jacket2OnHanger.SetActive(true);

                pants1OnManekin.SetActive(false);
                pants2OnManekin.SetActive(false);
                pants1OnHanger.SetActive(true);
                pants2OnHanger.SetActive(true);

                tshirt1OnManekin.SetActive(false);
                tshirt2OnManekin.SetActive(false);
                tshirt1OnHanger.SetActive(true);
                tshirt2OnHanger.SetActive(true);

                umbrella1OnManekin.SetActive(false);
                umbrella2OnManekin.SetActive(false);
                umbrella1OnHanger.SetActive(true);
                umbrella2OnHanger.SetActive(true);

                zatwierdz.SetActive(false);
                break;
            case ManekinStates.Manekin_HAT_1:
                hat1OnManekin.SetActive(true);
                hat2OnManekin.SetActive(false);
                hat1OnHanger.SetActive(false);
                hat2OnHanger.SetActive(true);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.Manekin_HAT_2:
                hat1OnManekin.SetActive(false);
                hat2OnManekin.SetActive(true);
                hat1OnHanger.SetActive(true);
                hat2OnHanger.SetActive(false);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.Manekin_JACKET_1:
                jacket1OnManekin.SetActive(true);
                jacket2OnManekin.SetActive(false);
                jacket1OnHanger.SetActive(false);
                jacket2OnHanger.SetActive(true);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.Manekin_JACKET_2:
                jacket1OnManekin.SetActive(false);
                jacket2OnManekin.SetActive(true);
                jacket1OnHanger.SetActive(true);
                jacket2OnHanger.SetActive(false);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.Manekin_PANTS_1:
                pants1OnManekin.SetActive(true);
                pants2OnManekin.SetActive(false);
                pants1OnHanger.SetActive(false);
                pants2OnHanger.SetActive(true);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.Manekin_PANTS_2:
                pants1OnManekin.SetActive(false);
                pants2OnManekin.SetActive(true);
                pants1OnHanger.SetActive(true);
                pants2OnHanger.SetActive(false);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.Manekin_TSHIRT_1:
                tshirt1OnManekin.SetActive(true);
                tshirt2OnManekin.SetActive(false);
                tshirt1OnHanger.SetActive(false);
                tshirt2OnHanger.SetActive(true);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.Manekin_TSHIRT_2:
                tshirt1OnManekin.SetActive(false);
                tshirt2OnManekin.SetActive(true);
                tshirt1OnHanger.SetActive(true);
                tshirt2OnHanger.SetActive(false);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.Manekin_UMBRELLA_1:
                umbrella1OnManekin.SetActive(true);
                umbrella2OnManekin.SetActive(false);
                umbrella1OnHanger.SetActive(false);
                umbrella2OnHanger.SetActive(true);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.Manekin_UMBRELLA_2:
                umbrella1OnManekin.SetActive(false);
                umbrella2OnManekin.SetActive(true);
                umbrella1OnHanger.SetActive(true);
                umbrella2OnHanger.SetActive(false);
                zatwierdz.SetActive(true);
                break;
            case ManekinStates.PANTS_1:
                pants1OnManekin.SetActive(false);
                pants2OnManekin.SetActive(false);
                pants1OnHanger.SetActive(true);
                pants2OnHanger.SetActive(true);
                break;
            case ManekinStates.PANTS_2:
                pants1OnManekin.SetActive(false);
                pants2OnManekin.SetActive(false);
                pants1OnHanger.SetActive(true);
                pants2OnHanger.SetActive(true);
                break;
            case ManekinStates.TSHIRT_1:
                tshirt1OnManekin.SetActive(false);
                tshirt2OnManekin.SetActive(false);
                tshirt1OnHanger.SetActive(true);
                tshirt2OnHanger.SetActive(true);
                break;
            case ManekinStates.TSHIRT_2:
                tshirt1OnManekin.SetActive(false);
                tshirt2OnManekin.SetActive(false);
                tshirt1OnHanger.SetActive(true);
                tshirt2OnHanger.SetActive(true);
                break;
            case ManekinStates.UMBRELLA_1:
                umbrella1OnManekin.SetActive(false);
                umbrella2OnManekin.SetActive(false);
                umbrella1OnHanger.SetActive(true);
                umbrella2OnHanger.SetActive(true);
                break;


            case ManekinStates.HAT_1:
                hat1OnManekin.SetActive(false);
                hat2OnManekin.SetActive(false);
                hat1OnHanger.SetActive(true);
                hat2OnHanger.SetActive(true);
                break;
            case ManekinStates.HAT_2:
                hat1OnManekin.SetActive(false);
                hat2OnManekin.SetActive(false);
                hat1OnHanger.SetActive(true);
                hat2OnHanger.SetActive(true);
                break;
            case ManekinStates.JACKET_1:
                jacket1OnManekin.SetActive(false);
                jacket2OnManekin.SetActive(false);
                jacket1OnHanger.SetActive(true);
                jacket2OnHanger.SetActive(true);
                break;
            case ManekinStates.JACKET_2:
                jacket1OnManekin.SetActive(false);
                jacket2OnManekin.SetActive(false);
                jacket1OnHanger.SetActive(true);
                jacket2OnHanger.SetActive(true);
                break;
            case ManekinStates.UMBRELLA_2:
                umbrella1OnManekin.SetActive(false);
                umbrella2OnManekin.SetActive(false);
                umbrella1OnHanger.SetActive(true);
                umbrella2OnHanger.SetActive(true);
                break;
            case ManekinStates.END_GAME:
                animator.SetBool("Outro", true);
                break;

        }
    }

    public void putHat1OnManekin()
    {
        currentState = ManekinStates.Manekin_HAT_1;
    }

    public void putHat2OnManekin()
    {
        currentState = ManekinStates.Manekin_HAT_2;
    }

    public void putJacket1OnManekin()
    {
        currentState = ManekinStates.Manekin_JACKET_1;
    }

    public void putJacket2OnManekin()
    {
        currentState = ManekinStates.Manekin_JACKET_2;
    }

    public void putPants1OnManekin()
    {
        currentState = ManekinStates.Manekin_PANTS_1;
    }

    public void putPants2OnManekin()
    {
        currentState = ManekinStates.Manekin_PANTS_2;
    }

    public void putTshirt1OnManekin()
    {
        currentState = ManekinStates.Manekin_TSHIRT_1;
    }

    public void putTshirt2OnManekin()
    {
        currentState = ManekinStates.Manekin_TSHIRT_2;
    }

    public void putUmbrella1OnManekin()
    {
        currentState = ManekinStates.Manekin_UMBRELLA_1;
    }

    public void putUmbrella2OnManekin()
    {
        currentState = ManekinStates.Manekin_UMBRELLA_2;
    }


    public void putPants1OnHanger()
    {
        currentState = ManekinStates.PANTS_1;
    }

    public void putPants2OnHanger()
    {
        currentState = ManekinStates.PANTS_2;
    }

    public void putTshirt1OnHanger()
    {
        currentState = ManekinStates.TSHIRT_1;
    }

    public void putTshirt2OnHanger()
    {
        currentState = ManekinStates.TSHIRT_2;
    }

    public void putUmbrella1OnHanger()
    {
        currentState = ManekinStates.UMBRELLA_1;
    }


    public void putHat1OnHanger()
    {
        currentState = ManekinStates.HAT_1;
    }

    public void putHat2OnHanger()
    {
        currentState = ManekinStates.HAT_2;
    }

    public void putJacket1OnHanger()
    {
        currentState = ManekinStates.JACKET_1;
    }

    public void putJacket2OnHanger()
    {
        currentState = ManekinStates.JACKET_2;
    }

    public void putUmbrella2OnHanger()
    {
        currentState = ManekinStates.UMBRELLA_2;
    }

    public void endGame()
    {
        currentState = ManekinStates.END_GAME;
    }
}
