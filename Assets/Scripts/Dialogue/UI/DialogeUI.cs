using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogeUI : MonoBehaviour
{
    public  GameObject panel;
    public Text dialogeText;

    private void OnEnable() {
        EventHandler.ShowDialogeEvent += ShowDialoge;
    }

    private void OnDisable() {
        EventHandler.ShowDialogeEvent -= ShowDialoge;
    }
    private void ShowDialoge(string dialoge){
        if(dialoge != string.Empty)
            panel.SetActive(false);
        else 
            panel.SetActive(true);
        dialogeText.text = dialoge;
    }
}
