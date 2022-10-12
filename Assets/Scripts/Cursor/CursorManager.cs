using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public RectTransform hand;
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
    private ItemName currentItem;
    private bool canClick;
    private bool holdItem;

    private void OnEnable() {
        EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
        EventHandler.ItemUsedEvent += OnItemUsedEvent;

    }

    private void OnDisable() {
        EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
    }

    private void Update() {
        canClick = ObjectAtMousePosition();

        if(hand.gameObject.activeInHierarchy)
            hand.position = Input.mousePosition;

        if(canClick&&Input.GetMouseButtonDown(0))
        {
            //檢測鼠標互動情況
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }

    private void OnItemUsedEvent(ItemName obj){
        currentItem = ItemName.None;
        holdItem = false;
        hand.gameObject.SetActive(false);
    }

    private void OnItemSelectedEvent(ItemDetails itemDetails,bool isSelected){
        holdItem = isSelected;
        if(isSelected){
            currentItem = itemDetails.itemName;
        }
        hand.gameObject.SetActive(holdItem);
    }

    private void ClickAction(GameObject clickObject){
        switch (clickObject.tag){
            case "Teleport":
                var teleport = clickObject.GetComponent<Teleport>();
                teleport?.TeleportTOScene();
                break;
            case "Item":
                var item = clickObject.GetComponent<Item>();
                item?.ItemClicked();
                break;
            case "Interactive":
                var interactive = clickObject.GetComponent<Interactive>();
                if(holdItem)
                    interactive?.ClickItem(currentItem);
                else
                    interactive?.EmptyClicked();
                break;  
        }
    }

    //檢測鼠標點擊範圍的碰撞體
    private Collider2D ObjectAtMousePosition(){
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
