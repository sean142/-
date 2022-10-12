using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogeController))]
public class CharacterH2 : Interactive
{
   private DialogeController dialogeController;

   private void Awake() {
        dialogeController = GetComponent<DialogeController>();
   }

    public override void EmptyClicked()
    {
        if(isDone)
            dialogeController.ShowDialogeFinish();
        dialogeController.ShowDialogeEmpty();
    }

    protected override void OnClickedAction()
    {
        dialogeController.ShowDialogeFinish();        
    } 
}
