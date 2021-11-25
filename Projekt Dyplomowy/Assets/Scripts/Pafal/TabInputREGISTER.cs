using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabInputREGISTER : MonoBehaviour
{
    public TMP_InputField UsernameInput; // 0
    public TMP_InputField EmailInput; // 1
    public TMP_InputField PasswordInput; // 2

    public int InputSelected;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift)) {
            InputSelected--;
            if (InputSelected < 0) InputSelected = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Tab)){
            InputSelected++;
            if (InputSelected > 2) InputSelected = 0;
            //Select
        }

        void SelectInputField() {
            switch(InputSelected) {
                 case 0: UsernameInput.Select();
                    break;
                case 1: PasswordInput.Select();
                    break;
                case 2: EmailInput.Select();
                    break;
            }
        }
    }

    public void UsernameSelected() => InputSelected = 0;
    public void PasswordSelected() => InputSelected = 1;
    public void EmailSelected() => InputSelected = 2;
}
