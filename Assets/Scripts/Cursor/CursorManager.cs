using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
    private bool canClick;
    private void Update() {
        canClick = ObjectAtMousePosition();

        if(canClick&&Input.GetMouseButtonDown(0))
        {
            //檢測鼠標互動情況
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }

    private void ClickAction(GameObject clickObject){
        switch (clickObject.tag){
            case "Teleport":
                var teleport = clickObject.GetComponent<Teleport>();
                teleport?.TeleportTOScene();
                break;
        }
    }

    //檢測鼠標點擊範圍的碰撞體
    private Collider2D ObjectAtMousePosition(){
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}