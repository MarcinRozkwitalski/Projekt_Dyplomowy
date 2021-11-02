using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChange : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D cursorEye;

    void Start()
    {
        Cursor.SetCursor(cursorArrow,Vector2.zero,CursorMode.ForceSoftware);
    }

    void OnMouseEnter(){
        Cursor.SetCursor(cursorEye,Vector2.zero,CursorMode.ForceSoftware);
    }

    void OnMouseExit(){
        Cursor.SetCursor(cursorArrow,Vector2.zero,CursorMode.ForceSoftware);
    }

}
