using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    public Button leftButton,rightButton;
    public SlotUI slotUI;
    public int currentIndex;

    private void OnEnable() {
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable() {
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    private void OnUpdateUIEvent(ItemDetails itemDetails, int index){
        if (itemDetails==null){
            slotUI.SetEmpty();
            currentIndex = -1;
            leftButton.interactable = false;
            rightButton.interactable = false; 
        }
        else{
            currentIndex = index;
            slotUI.SetItem(itemDetails);
            
            if(index>0)
                leftButton.interactable = true;
            if(index==-1)
            {
                leftButton.interactable = false;
                rightButton.interactable = false;
            }
            
        }
    }
    //左右按鈕vent事件 
    public void SwitchItem(int amount){
        var index = currentIndex + amount;

        if(index <currentIndex){
            leftButton.interactable = false;
            rightButton.interactable = true; 
        }

        else if(index>currentIndex){
            leftButton.interactable = true;
            rightButton.interactable = false; 
        }
        else {
            leftButton.interactable = true;
            rightButton.interactable = true; 
        }
        EventHandler.CallChangItemEvemt(index);
    }
}
