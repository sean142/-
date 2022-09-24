using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class EventHandler 
{
   public static event Action<ItemDetails,int>UpdateUIEvent;

   public static void CallUpdateUIEvent(ItemDetails itemDetails, int index){
        UpdateUIEvent?.Invoke(itemDetails,index);
   }

   public static event Action BeforeSceneUnloadEvent;

   public static void CallBefofeSceneUnloadUIEvent(){
        BeforeSceneUnloadEvent?.Invoke();
   }

   public static event Action AfterSceneLoadedEvent;

   public static void CallAfterSceneLoadedEvent(){
        AfterSceneLoadedEvent?.Invoke();
   }
}
