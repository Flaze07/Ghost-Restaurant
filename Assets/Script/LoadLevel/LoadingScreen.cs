using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    // public void aaa(){
    //     Debug.Log("Hi");
    // }
    // public GameObject click;
    // public Slider slide;
    void Start()
    {
        
    }
    public void loadPlace()
    {
        if (PlayerPrefs.HasKey("boolTempat") == false)
        {
            
            PlayerPrefs.SetInt("boolTempat", 1);
            StartCoroutine(LoadAsync("Tutorial"));
            //loadLevel();
        }
        else if(PlayerPrefs.GetInt("boolTempat") == 1)
        {
            //loadLevel();
            // Debug.Log("Clicked");
            StartCoroutine(LoadAsync("Jakarta"));
        }
        else if(PlayerPrefs.GetInt("boolTempat") == 2)
        {
            //loadLevel();
            // Debug.Log("Clicked");
            StartCoroutine(LoadAsync("Palembang"));
        }
        
        // click.gameObject.SetActive(false);
        // slide.gameObject.SetActive(true);
        
    }
    IEnumerator LoadAsync(string nama){
        AsyncOperation operation = SceneManager.LoadSceneAsync(nama);
        
        while(!operation.isDone){
            // float prog = Mathf.Clamp01(operation.progress / .9f);
            // Debug.Log(progress);
            // slide.value = prog;

            yield return null;
        }
    }
}
