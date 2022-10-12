using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeController : MonoBehaviour
{
  public DialogueData_SO dialogeEmpty;
  public DialogueData_SO dialogeFinish;
  private Stack<string> dialogeEmptyStack;
  private Stack<string> dialogeFinishStack;
  private bool isTalking;

  private void Awake() {
    FillDialogeStack();
  }

  private void FillDialogeStack()
  {
    dialogeEmptyStack = new Stack<string>();
    dialogeFinishStack = new Stack<string>();

    for (int i  = dialogeEmpty.dialogeList.Count -1 ; i>-1; i--){
        dialogeEmptyStack.Push(dialogeEmpty.dialogeList[i]);
    }
    for (int i  = dialogeFinish.dialogeList.Count -1 ; i>-1; i--){
        dialogeFinishStack.Push(dialogeFinish .dialogeList[i]);
    }
  }
  
  public void ShowDialogeEmpty(){
    if(!isTalking)
        StartCoroutine(DialogeRoutine(dialogeEmptyStack));
  }
  public void ShowDialogeFinish(){
    if(!isTalking)
        StartCoroutine(DialogeRoutine(dialogeFinishStack)); 
  }

  private IEnumerator DialogeRoutine(Stack<string> data)
  {
    isTalking = true;
    if(data.TryPop(out string result))
    {
        EventHandler.CallShowDialogeEvent(result);
        yield return null;
        isTalking = false;
    }
    else 
    {
        EventHandler.CallShowDialogeEvent(string.Empty);
        FillDialogeStack();
        isTalking = false;
    }
  }
}
