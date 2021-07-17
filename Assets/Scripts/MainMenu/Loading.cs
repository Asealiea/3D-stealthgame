using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    //reference to progress bar.
    [SerializeField] private Image _progressBar;
    
    void Start()
    {
        //call coroutine to load the main scene
        StartCoroutine(LoadLevelAsync());
    }


    IEnumerator LoadLevelAsync()
    {
        yield return null;

        //starts to load the game scene
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(2);

        //stops  the scene showing till it is finished
        asyncOperation.allowSceneActivation = false;

        //while loading is still in progress, update the loading bar 
        while (!asyncOperation.isDone)
        {
            //update the loading bar
            _progressBar.fillAmount = asyncOperation.progress;

            //checking if the loading has finished
            if (asyncOperation.progress >= 0.9f)
            {
               
                asyncOperation.allowSceneActivation = true;
                
            }
            //wait till end of frame before looping back around
            yield return null;
        }
    }
}
