using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requireName;

    public bool isDone;

    public void ClickItem(ItemName itemName){
        if(itemName == requireName && !isDone){
            isDone = true;
            //使用這個物品，移除物品
            OnClickedAction();
            EventHandler.CallItemUsedEvent(itemName);
        }
    }

    protected virtual void OnClickedAction(){

    }

    public virtual void EmptyClicked(){
        Debug.Log("空點");
    }
}
