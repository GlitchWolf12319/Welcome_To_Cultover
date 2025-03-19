using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMouseCursor : MonoBehaviour
{
    public Texture2D mouseCursor;

    public Texture2D ClickedCursor;

    Vector2 hotSpot = new Vector2(0,0);
    CursorMode cursorMode = CursorMode.Auto;

    private void Start()
    {        
        Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
    }



     void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if(Input.GetMouseButtonDown(0)){
            Cursor.SetCursor(ClickedCursor, hotSpot, cursorMode);
           
        }
        else if(Input.GetMouseButtonUp(0)){
             Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
        }
        
    }
}