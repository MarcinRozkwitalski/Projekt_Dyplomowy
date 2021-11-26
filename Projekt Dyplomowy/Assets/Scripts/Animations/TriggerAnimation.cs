using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//sources
//https://stackoverflow.com/questions/40752083/how-to-find-child-of-a-gameobject-or-the-script-attached-to-child-gameobject-via

public class TriggerAnimation : MonoBehaviour
{

    Animator animator;
    public static bool runAnimation = true;
    public static bool runAgain = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //(AnswerHandler.index != int.Parse(gameObject.name))
        //podmienić to na dole :)
        // PlayerCanInteract.index
        if (1 != int.Parse(gameObject.name))
        {
            GameObject originalGameObject = GameObject.Find(gameObject.name);
            if (originalGameObject.GetComponent<Renderer>().enabled) originalGameObject.GetComponent<Renderer>().enabled = !originalGameObject.GetComponent<Renderer>().enabled;

            for (int i = 0; i < originalGameObject.transform.childCount; i++)
            {
                GameObject child = originalGameObject.transform.GetChild(i).gameObject; // dziecko
                //Debug.Log("Rodzic " + originalGameObject.name + " Dziecko " + child.name);
                child.SetActive(false);
            }

        }
        else
        {
            GameObject originalGameObject = GameObject.Find(gameObject.name);
            if (originalGameObject.GetComponent<Renderer>().enabled == false) originalGameObject.GetComponent<Renderer>().enabled = !originalGameObject.GetComponent<Renderer>().enabled;

            for (int i = 0; i < originalGameObject.transform.childCount; i++)
            {
                GameObject child = originalGameObject.transform.GetChild(i).gameObject; // dziecko
                //Debug.Log("Rodzic " + originalGameObject.name + " Dziecko " + child.name);
                child.SetActive(true);
            }
            StartCoroutine(Time());
        }
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(0f);

        if (gameObject.tag == "UseDoor")
        {
            if (runAnimation == true && runAgain == true)
            {
                runAgain = false;
                OpenDoor();
                yield return new WaitForSeconds(1f);
                animator.SetBool("isIndexCorrect", true);
                Debug.Log("Otwórz Drzwi");
            }
            if (runAnimation == false && runAgain == true)
            {
                runAgain = false;
                animator.SetBool("isIndexCorrect", false);
                yield return new WaitForSeconds(1f);
                CloseDoor();
                Debug.Log("Zamnknij Drzwi");
            }
        }




        if (gameObject.tag == "PlayerCantMove") PlayerMovement.canMove = false;
        else PlayerMovement.canMove = true;
    }

    void OpenDoor()
    {
        DoorHandler.doorStatus = 0;
    }
    void CloseDoor()
    {
        DoorHandler.doorStatus = 1;
    }
}
