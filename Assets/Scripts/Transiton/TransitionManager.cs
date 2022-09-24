using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionManager : Singleton<TransitionManager>
{
    [SceneName] public string startScene;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration; 
    private bool isFade;

    private void Start() {
        StartCoroutine(TransitionToScence(string.Empty,startScene));
    }

   public void Transition(string from,string to)
   {
        if(!isFade)
            StartCoroutine(TransitionToScence(from,to));
   }

    private IEnumerator TransitionToScence(string from,string to)
    {
        yield return Fade(1);
        if(from != string.Empty){
         EventHandler.CallBefofeSceneUnloadUIEvent();
        //卸載場景
         yield return SceneManager.UnloadSceneAsync(from);
        }
        //重新載入場景
        yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);

        //設置新場景為激活場景
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount-1);
        SceneManager.SetActiveScene(newScene);    

        EventHandler.CallAfterSceneLoadedEvent();
        yield return Fade(0);    
    }  

    //淡入淡出場景
    private IEnumerator Fade (float targetAlpha)
    {
        isFade = true;
        
        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha-targetAlpha)/fadeDuration;
        
        while(!Mathf.Approximately(fadeCanvasGroup.alpha,targetAlpha)){
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha,targetAlpha,speed*Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;
    }
}
